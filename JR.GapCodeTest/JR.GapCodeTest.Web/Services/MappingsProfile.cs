using System;
using AutoMapper;
using JR.GapCodeTest.Web.Models;
using JR.GapCodeTest.Web.Models.Dto;
using System.Collections.Generic;
using System.Linq;

namespace JR.GapCodeTest.Web.Services
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Ciudad, CiudadDto>().ReverseMap();
            CreateMap<Agencia, AgenciaDto>().ReverseMap();
            CreateMap<Tiporiesgo, TipoRiesgoDto>().ReverseMap();
            CreateMap<Tipocubrimiento, TipoCubrimientoDto>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<PolizaDto, Poliza>().ReverseMap();
        }
    }
}