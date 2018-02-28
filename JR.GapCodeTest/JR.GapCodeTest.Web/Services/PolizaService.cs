using System;
using System.Collections.Generic;
using AutoMapper;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Models.Dto;

namespace JR.GapCodeTest.Web.Services
{
    public class PolizaService : IPoliza
    {
        private readonly GapCodeTestDbContext _dbcontext;
        private readonly IMapper _mapper;
        
        public PolizaService(GapCodeTestDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public PolizaDto ActualizarPoliza(PolizaDto p)
        {
            throw new NotImplementedException();
        }

        public PolizaDto CrearPoliza(PolizaDto p)
        {
            throw new NotImplementedException();
        }

        public void EliminarPoliza(int id)
        {
            throw new NotImplementedException();
        }

        public PolizaDto ObtenerPoliza(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoCubrimientoDto> ObtenerTiposCubrimiento()
        {
            throw new NotImplementedException();
        }

        public List<TipoRiesgoDto> ObtenerTiposRiesgo()
        {
            throw new NotImplementedException();
        }
    }
}