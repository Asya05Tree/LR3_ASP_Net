using lr3ASPnet.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace lr3ASPnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcController : ControllerBase
    {
        private readonly CalcService _calcService;
        private readonly TimeService _timeService;
        private const int MaxValue = 10000;
        private const int MinValue = -10000;

        public CalcController(CalcService calcService, TimeService timeService)
        {
            _calcService = calcService;
            _timeService = timeService;
        }

        [HttpGet("add/{a}/{b}")]
        public IActionResult Add([Range(int.MinValue, MaxValue)] int a, [Range(int.MinValue, MaxValue)] int b)
        {
            if (!ValidateInput(a) || !ValidateInput(b))
                return BadRequest("Введені значення повинні бути цілими числами не більше " + MaxValue);

            return Ok($"Результат: {_calcService.Add(a, b)}. {_timeService.GetTimeOfDay()}");
        }

        [HttpGet("subtract/{a}/{b}")]
        public IActionResult Subtract([Range(int.MinValue, MaxValue)] int a, [Range(int.MinValue, MaxValue)] int b)
        {
            if (!ValidateInput(a) || !ValidateInput(b))
                return BadRequest("Введені значення повинні бути цілими числами не більше " + MaxValue);

            return Ok($"Результат: {_calcService.Subtract(a, b)}. {_timeService.GetTimeOfDay()}");
        }

        [HttpGet("multiply/{a}/{b}")]
        public IActionResult Multiply([Range(int.MinValue, MaxValue)] int a, [Range(int.MinValue, MaxValue)] int b)
        {
            if (!ValidateInput(a) || !ValidateInput(b))
                return BadRequest("Введені значення повинні бути цілими числами не більше " + MaxValue);

            return Ok($"Результат: {_calcService.Multiply(a, b)}. {_timeService.GetTimeOfDay()}");
        }

        [HttpGet("divide/{a}/{b}")]
        public IActionResult Divide([Range(int.MinValue, MaxValue)] int a, [Range(int.MinValue, MaxValue)] int b)
        {
            if (!ValidateInput(a) || !ValidateInput(b))
                return BadRequest("Введені значення повинні бути цілими числами не більше " + MaxValue);

            if (b == 0)
                return BadRequest("Ділення на нуль неможливе.");

            return Ok($"Результат: {_calcService.Divide(a, b)}. {_timeService.GetTimeOfDay()}");
        }

        private bool ValidateInput(int value)
        {
            return value >= MinValue && value <= MaxValue;
        }
    }
}
