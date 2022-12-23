using LixiBanff.Domain.IServices;
using LixiBanff.Domain.Models;
using LixiBanff.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LixiBanff.DTO;
using Amazon.DynamoDBv2;
using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using System.Linq;

namespace LixiBanff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DynamoDBController : ControllerBase
    {
        private readonly IDynamoDBContext _dynamoDBContext;
        private readonly INodoService _nodoService;

        public DynamoDBController(INodoService service, IDynamoDBContext dynamoDBContext)
        {
            _dynamoDBContext = dynamoDBContext;
            _nodoService = service;
        }

        [Route("FiltrarPorNodo")]
        [HttpGet]
        public async Task<IActionResult> GetDynamoDB(DateTime from, DateTime to, int nodoId)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                var clienteId = JwtConfigurator.GetTokenIdCliente(identity);
                List<ScanCondition> conditions = new List<ScanCondition>();

                var macNodo = await _nodoService.GetById(nodoId);

                // From To
                if (from != null)
                {
                    conditions.Add(new ScanCondition
                        (
                        nameof(tabla_datos_lora.Time),
                        ScanOperator.Between,
                        Utiles.DateTimeToEpoch(from),
                        Utiles.DateTimeToEpoch(to)
                        ));
                }               

                // Nodo
                conditions.Add(new ScanCondition
                        (
                        nameof(tabla_datos_lora.devEui),
                        ScanOperator.Equal,
                        macNodo.Mac
                        ));

                var search = _dynamoDBContext.ScanAsync<tabla_datos_lora>(conditions);
                var result = await search.GetRemainingAsync();

                var final_result = result.Select(x => new
                {
                    fecha = Utiles.EpochToDatetime(x.Time),
                    nodo = x.datos_decodificados.nnodo,
                    sensor = x.datos_decodificados.sensor,
                    valor = x.datos_decodificados.value
                });
                return Ok(JsonConvert.SerializeObject(final_result));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
