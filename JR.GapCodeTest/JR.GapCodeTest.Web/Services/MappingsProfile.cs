using System;
using AutoMapper;
using JR.GapCodeTest.Web.Models;
using JR.GapCodeTest.Web.Models.Dto;

namespace JR.GapCodeTest.Web.Services
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Ciudad, CiudadDto>();
            CreateMap<Agencia, AgenciaDto>();
            CreateMap<Tiporiesgo, TipoRiesgoDto>();
            CreateMap<Tipocubrimiento, TipoCubrimientoDto>();
            CreateMap<Cliente, ClienteDto>();

            CreateMap<Poliza, PolizaDto>();
        }
    }
}