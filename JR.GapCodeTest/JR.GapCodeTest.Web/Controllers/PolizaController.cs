using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JR.GapCodeTest.Web.Controllers
{
    [Authorize]
    public class PolizaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("api/[controller]/ciudad")]
        [HttpGet]
        public IActionResult ObtenerCiudades()
        {
            return Ok();
        }

        [Route("api/[controller]/agencia")]
        [HttpGet]
        public IActionResult ObtenerAgencias()
        {
            return Ok();
        }
    }
}