using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JR.GapCodeTest.Web.Models.Dto;

namespace JR.GapCodeTest.Web.Services
{
    public interface IPoliza
    {
        Task<List<TipoCubrimientoDto>> ObtenerTiposCubrimiento();
        Task<List<TipoRiesgoDto>> ObtenerTiposRiesgo();
        Task<PolizaDto> CrearPoliza(PolizaDto p);
        Task<List<PolizaDto>> ObtenerPolizas();
        Task<PolizaDto> ActualizarPoliza(PolizaDto p);
        void EliminarPoliza(PolizaDto p);
    }
}