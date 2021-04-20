using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculadora.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstnumber}/{secondnumber}")]
        public IActionResult GetSum(string firstnumber, string secondnumber) 
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber)) 
            {
                var sum = ConvertToDecimal(firstnumber) + ConvertToDecimal(secondnumber);

                return Ok(sum.ToString());
            }

            return BadRequest();
        }

        [HttpGet("subtraction/{firstnumber}/{secondnumber}")]
        public IActionResult GetSub(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var sum = ConvertToDecimal(firstnumber) - ConvertToDecimal(secondnumber);

                return Ok(sum.ToString());
            }

            return BadRequest();
        }

        [HttpGet("multiplication/{firstnumber}/{secondnumber}")]
        public IActionResult Getmult(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var sum = ConvertToDecimal(firstnumber) * ConvertToDecimal(secondnumber);

                return Ok(sum.ToString());
            }

            return BadRequest();
        }

        [HttpGet("division/{firstnumber}/{secondnumber}")]
        public IActionResult Getdiv(string firstnumber, string secondnumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
            {
                var sum = ConvertToDecimal(firstnumber) / ConvertToDecimal(secondnumber);

                return Ok(sum.ToString());
            }

            return BadRequest();
        }

        [HttpGet("SquareRoot/{firstnumber}")]
        public IActionResult GetSquare(string firstnumber)
        {
            if (IsNumeric(firstnumber) )
            {
                var square = Math.Sqrt((double)ConvertToDecimal(firstnumber));

                return Ok(square.ToString());
            }

            return BadRequest();
        }

        private decimal ConvertToDecimal(string strnumber)
        {
            decimal decimalValue;

            if (decimal.TryParse(strnumber, out decimalValue)) 
            {
                return decimalValue;
            }

            return 0;
        }

        private bool IsNumeric(string strnumber)
        {
            double number;

            bool isnumber = double.TryParse(strnumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isnumber;
        }
    }
}
