using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LixiBanff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        private string identity = "cliente";
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [Route("GetList")]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var listResponse = await _service.GetList();
                return Ok(listResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetSelect")]
        [HttpGet]
        public async Task<IActionResult> GetSelect()
        {
            try
            {
                var listResponse = await _service.GetSelect();
                return Ok(listResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Route("Create")]
        [HttpPost]
        
        public async Task<IActionResult> Create([FromBody] Cliente _obj)
        {
            try
            {         
                var validateExistence = await _service.ValidateExistence(_obj, "nombre");
                if (validateExistence)
                {
                    return BadRequest(new { message = "El " + identity + " " + _obj.NombreCliente + " ya existe." });
                }
                await _service.Create(_obj);
                return Ok(new { message = identity + " creado con éxito" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Save")]
        [HttpPost]        
        public async Task<IActionResult> Save([FromBody] Cliente _obj)
        {
            try
            {
                //var identity = HttpContext.User.Identity as ClaimsIdentity;
                //int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var validateExistence = await _service.ValidateExistence(_obj, "id");
                if (validateExistence)
                {
                    await _service.Save(_obj);
                    return Ok(new { message = identity + " modificado con éxito" });
                }
                return BadRequest(new { message = "El " + identity + " " + _obj.NombreCliente + " no existe." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Delete")]
        [HttpPost]     
        public async Task<IActionResult> Delete([FromBody] int identity_id)
        {
            try
            {
                await _service.Delete(identity_id);
                return Ok(new { message = identity + " eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
