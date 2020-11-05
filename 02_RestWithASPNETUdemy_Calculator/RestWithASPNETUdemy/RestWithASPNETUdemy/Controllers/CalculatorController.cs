using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sum = ConvertDecimal(firstNumber) + ConvertDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("subtrair/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtrair(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sum = ConvertDecimal(firstNumber) - ConvertDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("multiplicar/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplicar(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sum = ConvertDecimal(firstNumber) * ConvertDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("dividir/{firstNumber}/{secondNumber}")]
        public IActionResult GetDividir(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                if (ConvertDecimal(secondNumber) == 0)
                    return BadRequest("Não existe divisão por zero!");
                
                var sum = ConvertDecimal(firstNumber) / ConvertDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }
        private decimal ConvertDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
                return decimalValue;
            return 0;
        }
    }
}
