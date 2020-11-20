using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController
    {
        private ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        public IActionResult Siginin([FromBody] UserVO user)
        {

            if (user == null) return BadRequest("Invalid client request");
            
            return Ok(token);
        }
    }
}
