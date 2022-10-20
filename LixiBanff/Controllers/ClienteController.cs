using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using LixiBanff.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

        private async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                var validateExistence = await _clienteService.ValidateExistence(cliente);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El cliente " + cliente.NombreCliente + " ya existe." });
                }
                
                await _clienteService.SaveCliente(cliente);
                return Ok(new { message = "Cliente registrado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
