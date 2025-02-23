using CronjobWorker.Services.Models.Enums;
using System.Collections;

namespace CronjobWorker.Services.Abstractions;

/// <summary>
/// Rest provider
/// </summary>
public interface IRestProvider
{
    /// <summary>
    /// Call json async
    /// </summary>
    /// <param name="url"></param>
    /// <param name="httpMethod"></param>
    /// <param name="body"></param>
    /// <param name="queries"></param>
    /// <param name="headers"></param>
    /// <param name="contentType"></param>
    /// <param name="recall"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    Task<HttpResponseMessage> CallJsonAsync(
        string url,
        HttpMethod httpMethod,
        object? body = null,
        object? queries = null,
        IDictionary? headers = null,
        ContentType? contentType = ContentType.Json,
        bool? recall = true,
        int? timeout = 60);

    /// <summary>
    /// Convert object to string
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    List<string> ConvertObjectToList(object data);

    /// <summary>
    /// Convert object to key value pair
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    IList<KeyValuePair<string, string>> ConvertObjectToKeyValuePair(dynamic obj);

    /// <summary>
    /// Convert HttpResponseMessage to object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="response"></param>
    /// <returns></returns>
    Task<T> ConvertHttpResponseMessageToObject<T>(HttpResponseMessage response);
}
