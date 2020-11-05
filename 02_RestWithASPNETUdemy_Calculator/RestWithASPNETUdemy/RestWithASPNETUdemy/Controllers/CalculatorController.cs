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
        public IActionResult Somar(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var retorno = ConvertDecimal(firstNumber) + ConvertDecimal(secondNumber);
                return Ok(retorno.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("subtrair/{firstNumber}/{secondNumber}")]
        public IActionResult Subtrair(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var sum = ConvertDecimal(firstNumber) - ConvertDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("multiplicar/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicar(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var retorno = ConvertDecimal(firstNumber) * ConvertDecimal(secondNumber);
                return Ok(retorno.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("dividir/{firstNumber}/{secondNumber}")]
        public IActionResult Dividir(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                if (ConvertDecimal(secondNumber) == 0)
                    return BadRequest("Não existe divisão por zero!");
                
                var retorno = ConvertDecimal(firstNumber) / ConvertDecimal(secondNumber);
                return Ok(retorno.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {
                var retorno = (ConvertDecimal(firstNumber) / ConvertDecimal(secondNumber)) / 2;
                return Ok(retorno.ToString());
            }
            return BadRequest("Entrada inválida");
        }

        [HttpGet("raiz/{firstNumber}")]
        public IActionResult Raiz(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var retorno = Math.Sqrt((double)ConvertDecimal(firstNumber));
                return Ok(retorno.ToString());
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
