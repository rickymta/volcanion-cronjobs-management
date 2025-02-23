using CronjobWorker.Services.Abstractions;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CronjobWorker.Services.Implementations;

/// <inheritdoc />
public class MathEvaluatorProvider : IMathEvaluatorProvider
{
    /// <summary>
    /// Logger instance
    /// </summary>
    private readonly ILogger<MathEvaluatorProvider> _logger;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    public MathEvaluatorProvider(ILogger<MathEvaluatorProvider> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task<double?> EvaluateFormula(string formula, Dictionary<string, double> variables)
    {
        try
        {
            // Kiểm tra công thức không được để trống
            if (string.IsNullOrWhiteSpace(formula))
            {
                throw new ArgumentException("Công thức không được để trống.");
            }

            // Kiểm tra công thức có chứa ký tự không hợp lệ
            if (!Regex.IsMatch(formula, @"^[\d\+\-\*\/\^\(\)\{\}\s\w\.\,]+$"))
            {
                throw new ArgumentException("Công thức chứa ký tự không hợp lệ.");
            }

            // Kiểm tra công thức có chứa biến không tồn tại
            var matches = Regex.Matches(formula, @"\{(\w+)\}");
            // Lấy danh sách biến cần thiết
            var requiredVars = matches.Cast<Match>().Select(m => m.Groups[1].Value).ToHashSet();
            // Kiểm tra xem các biến cần thiết đã được cung cấp chưa
            foreach (var varName in requiredVars)
            {
                // Nếu biến không tồn tại trong danh sách biến cung cấp
                if (!variables.ContainsKey(varName))
                {
                    throw new ArgumentException($"Thiếu giá trị cho biến '{varName}'.");
                }
            }

            // Thay thế các biến vào công thức
            var formattedExpression = formula;
            foreach (var pair in variables)
            {
                formattedExpression = formattedExpression.Replace($"{{{pair.Key}}}", pair.Value.ToString(CultureInfo.InvariantCulture));
            }

            // Thay thế các hàm toán học cơ bản thành hàm của lớp Math
            var replacements = new Dictionary<string, string>
            {
                { @"(\d+)\s*\^\s*(\d+)", "Math.Pow($1, $2)" },
                { @"\bsqrt\(([^)]+)\)", "Math.Sqrt($1)" },
                { @"\bsin\(([^)]+)\)", "Math.Sin($1)" },
                { @"\bcos\(([^)]+)\)", "Math.Cos($1)" },
                { @"\btan\(([^)]+)\)", "Math.Tan($1)" },
                { @"\blog\(([^)]+)\)", "Math.Log($1)" },
                { @"\bexp\(([^)]+)\)", "Math.Exp($1)" },
                { @"\babs\(([^)]+)\)", "Math.Abs($1)" },
                { @"\bround\(([^)]+)\)", "Math.Round($1)" },
                { @"\bceil\(([^)]+)\)", "Math.Ceiling($1)" },
                { @"\bfloor\(([^)]+)\)", "Math.Floor($1)" },
                { @"\bmin\(([^,]+),([^)]+)\)", "Math.Min($1, $2)" },
                { @"\bmax\(([^,]+),([^)]+)\)", "Math.Max($1, $2)" },
                { @"\bpi\b", "Math.PI" },
                { @"\be\b", "Math.E" }
            };

            foreach (var replacement in replacements)
            {
                formattedExpression = Regex.Replace(formattedExpression, replacement.Key, replacement.Value);
            }

            // Thêm tham chiếu đến assembly System.Runtime
            var options = Microsoft.CodeAnalysis.Scripting.ScriptOptions.Default
                .AddReferences(typeof(Math).Assembly)    // Thêm tham chiếu đến assembly chứa lớp Math
                .AddImports("System");                          // Thêm namespace System vào script

            // Đánh giá biểu thức toán học
            var result = await CSharpScript.EvaluateAsync<double>(formattedExpression, options);
            // Trả về kết quả dưới dạng double
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Lỗi: {ex.Message}");
            return null;
        }
    }
}
