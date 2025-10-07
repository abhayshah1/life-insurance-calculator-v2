namespace LifeInsuranceAPI.Models;

public class InsuranceCalculationResponse
{
    public decimal RecommendedCoverage { get; set; }
    public decimal IncomeReplacement { get; set; }
    public decimal DebtCoverage { get; set; }
    public decimal FuneralExpenses { get; set; }
    public decimal EducationFund { get; set; }
    public decimal ExistingCoverage { get; set; }
    public decimal NetInsuranceNeeded { get; set; }
    public string CalculationMethod { get; set; } = string.Empty;
    public List<string> Recommendations { get; set; } = new();
}
