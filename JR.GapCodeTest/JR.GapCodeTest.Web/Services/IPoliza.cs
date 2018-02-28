using System;
using System.Collections.Generic;
using JR.GapCodeTest.Web.Models.Dto;

namespace JR.GapCodeTest.Web.Services
{
    public interface IPoliza
    {
        List<TipoCubrimientoDto> ObtenerTiposCubrimiento();
        List<TipoRiesgoDto> ObtenerTiposRiesgo();
        PolizaDto CrearPoliza(PolizaDto p);
        PolizaDto ObtenerPoliza(int id);
        PolizaDto ActualizarPoliza(PolizaDto p);
        void EliminarPoliza(int id);
    }
}