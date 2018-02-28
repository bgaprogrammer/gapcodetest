using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;

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

        public async Task<PolizaDto> ActualizarPoliza(PolizaDto p)
        {
            throw new NotImplementedException();
        }

        public async Task<PolizaDto> CrearPoliza(PolizaDto p)
        {
            throw new NotImplementedException();
        }

        public async void EliminarPoliza(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PolizaDto> ObtenerPoliza(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TipoCubrimientoDto>> ObtenerTiposCubrimiento()
        {
            var result = await _dbcontext.Tipocubrimiento.ToListAsync();

            return _mapper.Map<List<TipoCubrimientoDto>>(result);
        }

        public async Task<List<TipoRiesgoDto>> ObtenerTiposRiesgo()
        {
            var result = await _dbcontext.Tiporiesgo.ToListAsync();

            return _mapper.Map<List<TipoRiesgoDto>>(result);
        }
    }
}