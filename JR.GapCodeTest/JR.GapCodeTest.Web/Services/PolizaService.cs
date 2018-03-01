using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Models;
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

        public async Task<List<PolizaDto>> ObtenerPolizas()
        {
            var result = await _dbcontext.Poliza.ToListAsync();

            return _mapper.Map<List<PolizaDto>>(result);
        }

        public async Task<PolizaDto> CrearPoliza(PolizaDto p)
        {
            var poliza = _mapper.Map<Poliza>(p);

            var result = await _dbcontext.Poliza.AddAsync(poliza);

            p.Id = poliza.Id;

            return p;
        }

        public async Task<PolizaDto> ActualizarPoliza(PolizaDto p)
        {
            throw new NotImplementedException();
        }

        public async void EliminarPoliza(PolizaDto p)
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