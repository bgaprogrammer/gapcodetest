using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = await _dbcontext.Poliza
                                         .Include(x => x.Agencia)
                                         .Include(x => x.TipoCubrimiento)
                                         .Include(x => x.TipoRiesgo)
                                         .Include(x => x.PolizaClientes).ThenInclude(pc => pc.Cliente)
                                         .ToListAsync();
            
            var polizas = _mapper.Map<List<PolizaDto>>(result);

            foreach (var p in polizas)
            {
                p.Clientes = result.FirstOrDefault(x => x.Id.Equals(p.Id)).PolizaClientes.Select(y => new ClienteDto { Id = y.Cliente.Id, Nombre = y.Cliente.Nombre }).ToList();
            }

            return polizas;
        }

        public async Task<PolizaDto> CrearPoliza(PolizaDto p)
        {
            var poliza = new Poliza
            {
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                CoberturaMeses = p.CoberturaMeses,
                InicioVigencia = p.InicioVigencia,
                Precio = p.Precio,
                PorcentajeCubrimiento = p.PorcentajeCubrimiento,
                AgenciaId = p.Agencia.Id,
                TipoCubrimientoId = p.TipoCubrimiento.Id,
                TipoRiesgoId = p.TipoRiesgo.Id,
                PolizaClientes = p.Clientes.Select(x => new PolizaCliente { ClienteId = x.Id }).ToList()
            };

            await _dbcontext.Poliza.AddAsync(poliza);
            await _dbcontext.SaveChangesAsync();

            p.Id = poliza.Id;

            return p;
        }

        public async Task<PolizaDto> ActualizarPoliza(PolizaDto p)
        {
            throw new NotImplementedException();
        }

        public async Task<PolizaDto> EliminarPoliza(PolizaDto p)
        {
            var poliza = await _dbcontext.Poliza.Include(x => x.PolizaClientes).FirstOrDefaultAsync(x => x.Id.Equals(p.Id));

            if(poliza != null)
            {
                poliza.PolizaClientes.Clear();
                await _dbcontext.SaveChangesAsync();

                _dbcontext.Remove(poliza);
                await _dbcontext.SaveChangesAsync();
            }

            return p;
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