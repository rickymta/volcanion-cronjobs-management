namespace CronjobWorker.Services.Abstractions;

public interface IMathEvaluatorProvider
{
    /// <summary>
    /// Evaluate a formula with given variables
    /// </summary>
    /// <param name="formula"></param>
    /// <param name="variables"></param>
    /// <returns></returns>
    Task<double?> EvaluateFormula(string formula, Dictionary<string, double> variables);
}
