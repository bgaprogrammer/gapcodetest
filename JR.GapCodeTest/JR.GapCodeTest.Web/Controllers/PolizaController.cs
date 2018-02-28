using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JR.GapCodeTest.Web.Controllers
{
    [Authorize]
    public class PolizaController : Controller
    {
        private readonly ICiudad _ciudadService;
        private readonly IAgencia _agenciaService;
        private readonly ICliente _clienteService;
        private readonly IPoliza _polizaService;

        public PolizaController(ICiudad ciudadService, IAgencia agenciaService, ICliente clienteService, IPoliza polizaService)
        {
            _ciudadService = ciudadService;
            _agenciaService = agenciaService;
            _clienteService = clienteService;
            _polizaService = polizaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/[controller]/ciudad")]
        [HttpGet]
        public async Task<IActionResult> ObtenerCiudades()
        {
            var result = await _ciudadService.ObtenerCiudades();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [Route("api/[controller]/agencia")]
        [HttpGet]
        public async Task<IActionResult> ObtenerAgencias()
        {
            var result = await _agenciaService.ObtenerAgencias();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [Route("api/[controller]/tipocubrimiento")]
        [HttpGet]
        public async Task<IActionResult> ObtenerTiposCubrimiento()
        {
            var result = await _polizaService.ObtenerTiposCubrimiento();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [Route("api/[controller]/tiporiesgo")]
        [HttpGet]
        public async Task<IActionResult> ObtenerTiposRiesgo()
        {
            var result = await _polizaService.ObtenerTiposRiesgo();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }

        [Route("api/[controller]/clientes")]
        [HttpGet]
        public async Task<IActionResult> ObtenerClientes()
        {
            var result = await _clienteService.ObtenerClientes();

            if (!result.Any())
                return NotFound();

            return Ok(result);
        }
    }
}