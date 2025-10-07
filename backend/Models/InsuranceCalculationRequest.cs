namespace LifeInsuranceAPI.Models;

public class InsuranceCalculationRequest
{
    public int Age { get; set; }
    public decimal AnnualIncome { get; set; }
    public decimal CurrentDebts { get; set; }
    public decimal MortgageBalance { get; set; }
    public int NumberOfDependents { get; set; }
    public int YearsOfIncomeReplacement { get; set; }
    public decimal ExistingLifeInsurance { get; set; }
    public decimal FuneralExpenses { get; set; }
    public decimal EducationFundNeeded { get; set; }
}
