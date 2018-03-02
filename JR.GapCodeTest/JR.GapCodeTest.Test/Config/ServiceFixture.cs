using System;
using AutoMapper;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Data.Repository;
using JR.GapCodeTest.Web.Data.Repository.Implementation;
using JR.GapCodeTest.Web.Models;
using JR.GapCodeTest.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace JR.GapCodeTest.Test.Config
{
    public class ServiceFixture : IDisposable
    {
        public IAgenciaRepository _agenciaRepository { get; private set; }
        public ICiudadRepository _ciudadRepository { get; private set; }
        public IClienteRepository _clienteRepository { get; private set; }
        public IPolizaRepository _polizaRepository { get; private set; }
        public ITipoCubrimientoRepository _tipoCubrimientoRepository { get; private set; }
        public ITipoRiesgoRepository _tipoRiesgoRepository { get; private set; }
        private GapCodeTestDbContext _dbContext;
        
        public ServiceFixture()
        {
            DbContextOptions<GapCodeTestDbContext> options;

            var builder = new DbContextOptionsBuilder<GapCodeTestDbContext>();
            builder.UseInMemoryDatabase("mytestdb");

            options = builder.Options;

            _dbContext = new GapCodeTestDbContext(options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _agenciaRepository = new AgenciaRepository(_dbContext);
            _ciudadRepository = new CiudadRepository(_dbContext);
            _clienteRepository = new ClienteRepository(_dbContext);
            _polizaRepository = new PolizaRepository(_dbContext);
            _tipoCubrimientoRepository = new TipoCubrimientoRepository(_dbContext);
            _tipoRiesgoRepository = new TipoRiesgoRepository(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}