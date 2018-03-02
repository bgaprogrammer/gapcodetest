using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JR.GapCodeTest.Web.Models.Dto;

namespace JR.GapCodeTest.Web.Services.Definition
{
    public interface IPolizaService
    {
        Task<List<AgenciaDto>> ObtenerAgencias();
        Task<List<CiudadDto>> ObtenerCiudades();
        Task<List<ClienteDto>> ObtenerClientes();
        Task<List<TipoCubrimientoDto>> ObtenerTiposCubrimiento();
        Task<List<TipoRiesgoDto>> ObtenerTiposRiesgo();
        Task<PolizaDto> CrearPoliza(PolizaDto p);
        Task<List<PolizaDto>> ObtenerPolizas();
        Task<PolizaDto> ActualizarPoliza(PolizaDto p);
        Task<PolizaDto> EliminarPoliza(PolizaDto p);
    }
}