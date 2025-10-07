using Microsoft.AspNetCore.Mvc;
using LifeInsuranceAPI.Models;
using LifeInsuranceAPI.Services;

namespace LifeInsuranceAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsuranceController : ControllerBase
{
    private readonly InsuranceCalculatorService _calculatorService;
    private readonly ILogger<InsuranceController> _logger;

    public InsuranceController(ILogger<InsuranceController> logger)
    {
        _logger = logger;
        _calculatorService = new InsuranceCalculatorService();
    }

    [HttpPost("calculate")]
    public ActionResult<InsuranceCalculationResponse> Calculate([FromBody] InsuranceCalculationRequest request)
    {
        try
        {
            // Validate request
            if (request.Age < 18 || request.Age > 100)
            {
                return BadRequest("Age must be between 18 and 100.");
            }

            if (request.AnnualIncome < 0)
            {
                return BadRequest("Annual income cannot be negative.");
            }

            var result = _calculatorService.CalculateInsuranceNeeds(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error calculating insurance needs");
            return StatusCode(500, "An error occurred while calculating insurance needs.");
        }
    }

    [HttpGet("health")]
    public ActionResult<object> Health()
    {
        return Ok(new { status = "healthy", timestamp = DateTime.UtcNow });
    }
}
