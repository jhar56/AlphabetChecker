using Microsoft.AspNetCore.Mvc;
using AlphabetChecker.Service;
using AlphabetChecker.Domain.Models;
using AlphabetChecker.Service.Interface;

namespace AlphabetChecker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlphabetController : ControllerBase
    {
        private readonly IAlphabetCheckerService _alphabetCheckerService;

        public AlphabetController(IAlphabetCheckerService alphabetCheckerService)
        {
            _alphabetCheckerService = alphabetCheckerService;
        }

        [HttpPost("check")]
        public IActionResult CheckString([FromBody] StringInput input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.Input))
            {
                return BadRequest("Invalid input");
            }

            var result = _alphabetCheckerService.ContainsAllLetters(input.Input);
            return Ok(new { containsAllLetters = result });
        }
    }
}
