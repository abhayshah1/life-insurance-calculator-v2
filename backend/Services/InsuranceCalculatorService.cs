using LifeInsuranceAPI.Models;

namespace LifeInsuranceAPI.Services;

public class InsuranceCalculatorService
{
    public InsuranceCalculationResponse CalculateInsuranceNeeds(InsuranceCalculationRequest request)
    {
        var response = new InsuranceCalculationResponse
        {
            CalculationMethod = "DIME Method (Debt, Income, Mortgage, Education)"
        };

        // Calculate income replacement (Income x Years)
        response.IncomeReplacement = request.AnnualIncome * request.YearsOfIncomeReplacement;

        // Add debt coverage
        response.DebtCoverage = request.CurrentDebts + request.MortgageBalance;

        // Add funeral expenses
        response.FuneralExpenses = request.FuneralExpenses > 0 ? request.FuneralExpenses : 15000; // Default $15k

        // Add education fund
        response.EducationFund = request.EducationFundNeeded;

        // Calculate total coverage needed
        response.RecommendedCoverage = response.IncomeReplacement +
                                       response.DebtCoverage +
                                       response.FuneralExpenses +
                                       response.EducationFund;

        // Subtract existing coverage
        response.ExistingCoverage = request.ExistingLifeInsurance;
        response.NetInsuranceNeeded = Math.Max(0, response.RecommendedCoverage - response.ExistingCoverage);

        // Generate recommendations
        response.Recommendations = GenerateRecommendations(request, response);

        return response;
    }

    private List<string> GenerateRecommendations(InsuranceCalculationRequest request, InsuranceCalculationResponse response)
    {
        var recommendations = new List<string>();

        if (response.NetInsuranceNeeded > 0)
        {
            recommendations.Add($"You need ${response.NetInsuranceNeeded:N0} in additional life insurance coverage.");
        }
        else
        {
            recommendations.Add("Your current life insurance coverage appears adequate based on the information provided.");
        }

        if (request.NumberOfDependents > 0)
        {
            recommendations.Add($"With {request.NumberOfDependents} dependent(s), consider term life insurance for income replacement.");
        }

        if (request.Age < 40)
        {
            recommendations.Add("At your age, term life insurance is typically the most cost-effective option.");
        }
        else if (request.Age >= 40 && request.Age < 55)
        {
            recommendations.Add("Consider a mix of term and permanent life insurance for flexibility.");
        }
        else
        {
            recommendations.Add("Evaluate both term and whole life insurance options based on your estate planning needs.");
        }

        if (request.MortgageBalance > 0)
        {
            recommendations.Add($"Your coverage includes ${request.MortgageBalance:N0} for mortgage protection.");
        }

        if (request.EducationFundNeeded > 0)
        {
            recommendations.Add($"Educational funding of ${request.EducationFundNeeded:N0} is included for your dependents.");
        }

        return recommendations;
    }
}
