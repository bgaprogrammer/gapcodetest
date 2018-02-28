using System;
using System.Collections.Generic;
using JR.GapCodeTest.Web.Models.Dto;

namespace JR.GapCodeTest.Web.Services
{
    public interface IAgencia
    {
        List<AgenciaDto> ObtenerAgencias();
    }
}