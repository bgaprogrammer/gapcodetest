using System;
using System.Linq;
using System.Threading.Tasks;
using JR.GapCodeTest.Test.Config;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Models;
using JR.GapCodeTest.Web.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JR.GapCodeTest.Test
{
    [Collection("Service collection")]
    public class PolizaTest
    {
        ServiceFixture _fixture;
        
        public PolizaTest(ServiceFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CuandoSeCreaUnaNuevaPolizaConUnCliente()
        {
            var ciudad = new Ciudad
            {
                Nombre = "Bogotá"
            };

            var agencia = new Agencia
            {
                Nombre = "Agencia Principal Bogotá",
                Ciudad = ciudad
            };

            var tipoCubrimiento = new Tipocubrimiento
            {
                Nombre = "Terremoto"
            };

            var tipoRiesgo = new Tiporiesgo
            {
                Nombre = "Bajo",
                MaxPorcentajeCubrimiento = 100
            };

            var cliente = new Cliente
            {
                Documento = "123456",
                Nombre = "Jorge Ramirez"
            };

            await _fixture._agenciaRepository.Create(agencia);
            await _fixture._tipoCubrimientoRepository.Create(tipoCubrimiento);
            await _fixture._tipoRiesgoRepository.Create(tipoRiesgo);
            await _fixture._clienteRepository.Create(cliente);
            
            var poliza = new Poliza
            {
                Nombre = "Poliza1",
                Descripcion = "Mi Poliza",
                CoberturaMeses = 3,
                InicioVigencia = DateTime.Now,
                PorcentajeCubrimiento = 30,
                Precio = 500000,
                AgenciaId = agencia.Id,
                TipoCubrimientoId = tipoCubrimiento.Id,
                TipoRiesgoId = tipoRiesgo.Id
            };

            poliza.PolizaClientes.Add(new PolizaCliente { ClienteId = cliente.Id });

            await _fixture._polizaRepository.Create(poliza);

            Assert.Equal(1, _fixture._polizaRepository.GetAll().Count());
            Assert.Equal(1, _fixture._polizaRepository.GetAll().Include(x => x.PolizaClientes).Count());
        }

        [Fact]
        public async Task CuandoSeEliminaUnaNuevaPolizaConUnCliente()
        {
            var ciudad = new Ciudad
            {
                Nombre = "Bogotá"
            };

            var agencia = new Agencia
            {
                Nombre = "Agencia Principal Bogotá",
                Ciudad = ciudad
            };

            var tipoCubrimiento = new Tipocubrimiento
            {
                Nombre = "Terremoto"
            };

            var tipoRiesgo = new Tiporiesgo
            {
                Nombre = "Bajo",
                MaxPorcentajeCubrimiento = 100
            };

            var cliente = new Cliente
            {
                Documento = "123456",
                Nombre = "Jorge Ramirez"
            };

            await _fixture._agenciaRepository.Create(agencia);
            await _fixture._tipoCubrimientoRepository.Create(tipoCubrimiento);
            await _fixture._tipoRiesgoRepository.Create(tipoRiesgo);
            await _fixture._clienteRepository.Create(cliente);

            var poliza = new Poliza
            {
                Nombre = "Poliza1",
                Descripcion = "Mi Poliza",
                CoberturaMeses = 3,
                InicioVigencia = DateTime.Now,
                PorcentajeCubrimiento = 30,
                Precio = 500000,
                AgenciaId = agencia.Id,
                TipoCubrimientoId = tipoCubrimiento.Id,
                TipoRiesgoId = tipoRiesgo.Id
            };

            poliza.PolizaClientes.Add(new PolizaCliente { ClienteId = cliente.Id });

            await _fixture._polizaRepository.Create(poliza);
            await _fixture._polizaRepository.DeleteWithRelated(poliza.Id);

            Assert.Equal(null, await _fixture._polizaRepository.GetById(poliza.Id));
            Assert.Equal(0, _fixture._polizaRepository.GetAll().Include(x => x.PolizaClientes).SelectMany(x => x.PolizaClientes).Where(x => x.PolizaId == poliza.Id).Count());
        }

        [Fact]
        public async Task CuandoSeActualizaUnaNuevaPolizaConUnCliente()
        {
            var ciudad = new Ciudad
            {
                Nombre = "Bogotá"
            };

            var agencia = new Agencia
            {
                Nombre = "Agencia Principal Bogotá",
                Ciudad = ciudad
            };

            var tipoCubrimiento = new Tipocubrimiento
            {
                Nombre = "Terremoto"
            };

            var tipoRiesgo = new Tiporiesgo
            {
                Nombre = "Bajo",
                MaxPorcentajeCubrimiento = 100
            };

            var cliente = new Cliente
            {
                Documento = "123456",
                Nombre = "Jorge Ramirez"
            };

            await _fixture._agenciaRepository.Create(agencia);
            await _fixture._tipoCubrimientoRepository.Create(tipoCubrimiento);
            await _fixture._tipoRiesgoRepository.Create(tipoRiesgo);
            await _fixture._clienteRepository.Create(cliente);

            var poliza = new Poliza
            {
                Nombre = "Poliza1",
                Descripcion = "Mi Poliza",
                CoberturaMeses = 3,
                InicioVigencia = DateTime.Now,
                PorcentajeCubrimiento = 30,
                Precio = 500000,
                AgenciaId = agencia.Id,
                TipoCubrimientoId = tipoCubrimiento.Id,
                TipoRiesgoId = tipoRiesgo.Id
            };

            poliza.PolizaClientes.Add(new PolizaCliente { ClienteId = cliente.Id });

            await _fixture._polizaRepository.Create(poliza);

            poliza.Nombre = "Nueva Poliza 1";
            poliza.Precio = 600000;

            await _fixture._polizaRepository.Update(poliza.Id, poliza);

            var polizaActualizada = await _fixture._polizaRepository.GetById(poliza.Id);

            Assert.Equal("Nueva Poliza 1", polizaActualizada.Nombre);
            Assert.Equal(600000, polizaActualizada.Precio);
        }

        [Fact]
        public async Task CuandoHayPolizasEnLaBaseDeDatos()
        {
            var ciudad = new Ciudad
            {
                Nombre = "Bogotá"
            };

            var agencia = new Agencia
            {
                Nombre = "Agencia Principal Bogotá",
                Ciudad = ciudad
            };

            var tipoCubrimiento = new Tipocubrimiento
            {
                Nombre = "Terremoto"
            };

            var tipoRiesgo = new Tiporiesgo
            {
                Nombre = "Bajo",
                MaxPorcentajeCubrimiento = 100
            };

            var cliente = new Cliente
            {
                Documento = "123456",
                Nombre = "Jorge Ramirez"
            };

            await _fixture._agenciaRepository.Create(agencia);
            await _fixture._tipoCubrimientoRepository.Create(tipoCubrimiento);
            await _fixture._tipoRiesgoRepository.Create(tipoRiesgo);
            await _fixture._clienteRepository.Create(cliente);

            var poliza = new Poliza
            {
                Nombre = "Poliza1",
                Descripcion = "Mi Poliza",
                CoberturaMeses = 3,
                InicioVigencia = DateTime.Now,
                PorcentajeCubrimiento = 30,
                Precio = 500000,
                AgenciaId = agencia.Id,
                TipoCubrimientoId = tipoCubrimiento.Id,
                TipoRiesgoId = tipoRiesgo.Id
            };

            poliza.PolizaClientes.Add(new PolizaCliente { ClienteId = cliente.Id });

            await _fixture._polizaRepository.Create(poliza);

            Assert.Equal(true, _fixture._polizaRepository.GetAll().Any());
        }
    }
}