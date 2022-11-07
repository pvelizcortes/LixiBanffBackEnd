using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using LixiBanff.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LixiBanff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [Route("GetListClient")]
        [HttpGet]
        public async Task<IActionResult> GetListClient()
        {
            try
            {
                var listResponse = await _clienteService.GetListClients();
                return Ok(listResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("CreateClient")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateClient([FromBody] Cliente cliente)
        {
            try
            {
                //var identity = HttpContext.User.Identity as ClaimsIdentity;
                //int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var validateExistence = await _clienteService.ValidateExistence(cliente, "nombre");
                if (validateExistence)
                {
                    return BadRequest(new { message = "El cliente " + cliente.NombreCliente + " ya existe." });
                }

                await _clienteService.CreateCliente(cliente);
                return Ok(new { message = "Cliente creado con éxito" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("SaveClient")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> SaveClient([FromBody] Cliente cliente)
        {
            try
            {
                //var identity = HttpContext.User.Identity as ClaimsIdentity;
                //int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var validateExistence = await _clienteService.ValidateExistence(cliente, "id");
                if (validateExistence)
                {
                    await _clienteService.SaveCliente(cliente);
                    return Ok(new { message = "Cliente modificado con éxito" });
                }
                return BadRequest(new { message = "El cliente " + cliente.NombreCliente + " no existe." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteClient")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteClient([FromBody] int clienteId)
        {
            try
            {
                await _clienteService.DeleteCliente(clienteId);
                return Ok(new { message = "Cliente eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
