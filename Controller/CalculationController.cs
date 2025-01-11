using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forward_Solutions_Test_BE.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Forward_Solutions_Test_BE.DTO;


namespace Forward_Solutions_Test_BE.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly CalculationService _calculationService;
        public CalculationController(CalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        [HttpPost("newCalculation")]
        public async Task<IActionResult> NewCalculation([FromBody] NumbersRequest request)
        {
            var result = await _calculationService.AddAndSaveAsync(request.FirstNumber, request.SecondNumber);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllCalculations()
        {
            var calculations = await _calculationService.GetCalculationsAsync();
            if(calculations == null || !calculations.Any())
                return NotFound(new { message = "No calculations found."});
            
            return Ok(calculations);
        }
    }
}