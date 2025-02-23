using CronjobWorker.Services.Abstractions;
using CronjobWorker.Services.Models.Enums;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
using Volcanion.Core.Common.Implementations;
using Volcanion.Core.Common.Providers;

namespace CronjobWorker.Services.Implementations;

/// <inheritdoc />
internal class RestProvider : IRestProvider
{
    /// <summary>
    /// HttpClientHandler instance
    /// </summary>
    private readonly HttpClientHandler _handler;

    /// <summary>
    /// HttpClient instance
    /// </summary>
    private readonly HttpClient _client;

    /// <summary>
    /// Flag to run first time
    /// </summary>
    private bool _runFirstFlag;

    /// <summary>
    /// Logger instance
    /// </summary>
    private readonly ILogger<RestProvider> _logger;

    /// <summary>
    /// String provider instance
    /// </summary>
    private readonly IStringProvider _stringProvider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="stringProvider"></param>
    public RestProvider(ILogger<RestProvider> logger, IStringProvider stringProvider)
    {
        _logger = logger;
        _handler = new HttpClientHandler { UseCookies = false, AllowAutoRedirect = false };
        _client = new HttpClient(_handler);
        _runFirstFlag = true;
        _stringProvider = stringProvider;
    }

    /// <inheritdoc />
    public async Task<HttpResponseMessage> CallJsonAsync(
        string url, 
        HttpMethod httpMethod, 
        object? body = null, 
        object? queries = null, 
        IDictionary? headers = null, 
        ContentType? contentType = ContentType.Json, 
        bool? recall = true, 
        int? timeout = 60)
    {
        if (_runFirstFlag)
        {
            _client.Timeout = TimeSpan.FromSeconds(600);
            _runFirstFlag = false;
        }
        int count = 0;
        bool continueCall = true;
        // thử gọi lại nếu có lỗi
        var result = new HttpResponseMessage();

        while (continueCall)
        {
            try
            {
                using var httpRequestMessage = new HttpRequestMessage();
                var contentTypeHeader = "application/json";

                if (contentType != ContentType.Json)
                {
                    if (contentType == ContentType.Form)
                    {
                        contentTypeHeader = "application/x-www-form-urlencoded";

                        if (body != null)
                        {
                            var nameValueCollection = ConvertObjectToKeyValuePair(body);
                            httpRequestMessage.Content = new FormUrlEncodedContent(nameValueCollection);
                        }
                    }
                }
                else
                {
                    if (body != null)
                    {
                        httpRequestMessage.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, contentTypeHeader);
                    }
                }

                if (queries != null)
                {
                    List<string> strArr = ConvertObjectToList(queries);
                    string firstChar = url.Contains("?") ? "&" : "?";
                    if (strArr.Count > 0)
                    {
                        url += firstChar + string.Join("&", strArr);
                    }
                }

                // add content-type and accept application/json hoặc application/x-www-form-urlencoded
                httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(contentTypeHeader));
                httpRequestMessage.Method = httpMethod;
                httpRequestMessage.RequestUri = new Uri(url);

                if (headers != null && headers.Count > 0)
                {
                    foreach (DictionaryEntry item in headers)
                    {
                        httpRequestMessage.Headers.Add(item.Key.ToString(), item.Value.ToString());
                    }
                }

                var cts = new CancellationTokenSource();
                // time out
                timeout ??= 60;
                cts.CancelAfter(TimeSpan.FromSeconds(timeout.Value));

                result = await _client.SendAsync(httpRequestMessage, cts.Token);
                // thoát vòng lặp
                continueCall = false;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("error", $"CallAPI url {url} queries {_stringProvider.SerializeUtf8(queries)} method {httpMethod}");
                // gọi lại nếu có lỗi
                recall ??= true;
                if (count < 3 && recall.Value)
                {
                    count++;
                    queries = null;
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        return result;
    }

    /// <inheritdoc />
    public List<string> ConvertObjectToList(object data)
    {
        var result = new List<string>();

        if (data == null)
        {
            return result;
        }

        foreach (var item in data.GetType().GetProperties())
        {
            var val = item.GetValue(data);
            var name = item.Name;

            switch (val)
            {
                case null:
                    continue;
                case DateTime time:
                    var dateTime = time;
                    result.Add(name + "=" + dateTime.ToString("yyyy-MM-ddTHH:mm:ss.ffff"));
                    break;
                default:
                    val = HttpUtility.UrlEncode(val.ToString());
                    result.Add(name + "=" + val);
                    break;
            }
        }

        return result;
    }

    /// <inheritdoc />
    public IList<KeyValuePair<string, string>> ConvertObjectToKeyValuePair(dynamic obj)
    {
        var result = new List<KeyValuePair<string, string>>();

        foreach (KeyValuePair<string, object> kvp in obj)
        {
            result.Add(new KeyValuePair<string, string>(kvp.Key, kvp.Value.ToString()));
        }

        return result;
    }

    /// <inheritdoc />
    public async Task<T> ConvertHttpResponseMessageToObject<T>(HttpResponseMessage response)
    {
        var responseBody = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<T>(responseBody);
        return result;
    }
}
