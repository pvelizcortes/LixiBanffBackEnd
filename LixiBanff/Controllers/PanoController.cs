using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using LixiBanff.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LixiBanff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PanoController : ControllerBase
    {
        private readonly IPanoService _service;
        private string identity_name = "Pano";
        public PanoController(IPanoService service)
        {
            _service = service;
        }

        [Route("GetList")]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var clienteId = JwtConfigurator.GetTokenIdCliente(identity);

                var listResponse = await _service.GetList(clienteId);
                return Ok(listResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Route("GetSelect")]
        [HttpGet]
        public async Task<IActionResult> GetSelect()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var clienteId = JwtConfigurator.GetTokenIdCliente(identity);

                var listResponse = await _service.GetSelect(clienteId);
                return Ok(listResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Route("Create")]
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Pano _obj)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _obj.ClienteId = JwtConfigurator.GetTokenIdCliente(identity);

                var validateExistence = await _service.ValidateExistence(_obj, "codigo");
                if (validateExistence)
                {
                    return BadRequest(new { message = "El " + identity_name + " " + _obj.NombrePano + " ya existe.", level = "warning" });
                }
                await _service.Create(_obj);
                return Ok(new { message = identity_name + " creado con éxito" });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Pano _obj)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                _obj.ClienteId = JwtConfigurator.GetTokenIdCliente(identity);

                var validateExistence = await _service.ValidateExistence(_obj, "id");
                if (validateExistence)
                {
                    await _service.Save(_obj);
                    return Ok(new { message = identity_name + " modificado con éxito" });
                }
                return BadRequest(new { message = "El " + identity_name + " " + _obj.NombrePano + " no existe.", level = "warning" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Route("Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int identity_id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var ClienteId = JwtConfigurator.GetTokenIdCliente(identity);

                await _service.Delete(identity_id, ClienteId);
                return Ok(new { message = identity_name + " eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
