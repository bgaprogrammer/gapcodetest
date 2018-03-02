using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JR.GapCodeTest.Web.Models.Dto;
using JR.GapCodeTest.Web.Services.Definition;

namespace JR.GapCodeTest.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PolizaController : Controller
    {
        private readonly IPolizaService _polizaService;

        public PolizaController(IPolizaService polizaService)
        {
            _polizaService = polizaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPolizas()
        {
            var result = await _polizaService.ObtenerPolizas();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPoliza([FromBody]PolizaDto p)
        {
            var result = await _polizaService.CrearPoliza(p);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarPoliza([FromBody]PolizaDto p)
        {
            var result = await _polizaService.EliminarPoliza(p);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> ActualizarPoliza([FromBody]PolizaDto p)
        {
            var result = await _polizaService.ActualizarPoliza(p);

            return Ok(result);
        }

        [HttpGet("agencia")]
        public async Task<IActionResult> ObtenerAgencias()
        {
            var result = await _polizaService.ObtenerAgencias();

            return Ok(result);
        }

        [HttpGet("tipocubrimiento")]
        public async Task<IActionResult> ObtenerTiposCubrimiento()
        {
            var result = await _polizaService.ObtenerTiposCubrimiento();

            return Ok(result);
        }

        [HttpGet("tiporiesgo")]
        public async Task<IActionResult> ObtenerTiposRiesgo()
        {
            var result = await _polizaService.ObtenerTiposRiesgo();

            return Ok(result);
        }

        [HttpGet("cliente")]
        public async Task<IActionResult> ObtenerClientes()
        {
            var result = await _polizaService.ObtenerClientes();

            return Ok(result);
        }
    }
}