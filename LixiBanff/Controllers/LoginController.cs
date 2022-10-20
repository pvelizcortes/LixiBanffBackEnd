using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using LixiBanff.DTO.Login;
using LixiBanff.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LixiBanff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;
        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            _config = config;
        }

        [Route("Validate")]
        [HttpPost]
        public async Task<IActionResult> Validate([FromBody] UsuarioLoginDTO usuario)
        {
            try
            {
                usuario.password = Encriptar.EncriptarPassword(usuario.password);
                var user = await _loginService.ValidateUser(usuario);
                if(user == null)
                {
                    return BadRequest(new { message = "Usuario o contraseña invalidos" });
                }
                string tokenString = JwtConfigurator.GetToken(user, _config);
                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
