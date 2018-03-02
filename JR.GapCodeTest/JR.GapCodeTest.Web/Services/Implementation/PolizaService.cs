using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Data.Repository;
using JR.GapCodeTest.Web.Models;
using JR.GapCodeTest.Web.Models.Dto;
using JR.GapCodeTest.Web.Services.Definition;
using Microsoft.EntityFrameworkCore;

namespace JR.GapCodeTest.Web.Services.Implementation
{
    public class PolizaService : IPolizaService
    {
        private readonly IAgenciaRepository _agenciaRepository;
        private readonly ICiudadRepository _ciudadRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IPolizaRepository _polizaRepository;
        private readonly ITipoCubrimientoRepository _tipoCubrimientoRepository;
        private readonly ITipoRiesgoRepository _tipoRiesgoRepository;
        private readonly IMapper _mapper;
        
        public PolizaService(IAgenciaRepository agenciaRepository, ICiudadRepository ciudadRepository,
                             IClienteRepository clienteRepository, IPolizaRepository polizaRepository, 
                             ITipoCubrimientoRepository tipoCubrimientoRepository, ITipoRiesgoRepository tipoRiesgoRepository,
                             IMapper mapper)
        {
            _agenciaRepository = agenciaRepository;
            _ciudadRepository = ciudadRepository;
            _clienteRepository = clienteRepository;
            _polizaRepository = polizaRepository;
            _tipoCubrimientoRepository = tipoCubrimientoRepository;
            _tipoRiesgoRepository = tipoRiesgoRepository;
            _mapper = mapper;
        }

        public async Task<List<CiudadDto>> ObtenerCiudades()
        {
            var result = await _ciudadRepository.GetAll().ToListAsync();

            return _mapper.Map<List<CiudadDto>>(result);
        }

        public async Task<List<AgenciaDto>> ObtenerAgencias()
        {
            var result = await _agenciaRepository.GetAll().Include(x => x.Ciudad).ToListAsync();

            return _mapper.Map<List<AgenciaDto>>(result);
        }

        public async Task<List<ClienteDto>> ObtenerClientes()
        {
            var result = await _clienteRepository.GetAll().ToListAsync();

            return _mapper.Map<List<ClienteDto>>(result);
        }

        public async Task<List<TipoCubrimientoDto>> ObtenerTiposCubrimiento()
        {
            var result = await _tipoCubrimientoRepository.GetAll().ToListAsync();

            return _mapper.Map<List<TipoCubrimientoDto>>(result);
        }

        public async Task<List<TipoRiesgoDto>> ObtenerTiposRiesgo()
        {
            var result = await _tipoRiesgoRepository.GetAll().ToListAsync();

            return _mapper.Map<List<TipoRiesgoDto>>(result);
        }

        public async Task<List<PolizaDto>> ObtenerPolizas()
        {
            var result = await _polizaRepository.GetAll()
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

            await _polizaRepository.Create(poliza);

            p.Id = poliza.Id;

            return p;
        }

        public async Task<PolizaDto> ActualizarPoliza(PolizaDto p)
        {
            await _polizaRepository.UpdateWithRelated(p);

            return p;
        }

        public async Task<PolizaDto> EliminarPoliza(PolizaDto p)
        {
            await _polizaRepository.DeleteWithRelated(p.Id);

            return p;
        }
    }
}