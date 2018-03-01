using System;
using System.Linq;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JR.GapCodeTest.Test
{
    public class PolizaCrudTest : IDisposable
    {
        GapCodeTestDbContext _dbContext;

        public PolizaCrudTest()
        {
            var serviceProvider = new ServiceCollection().AddEntityFrameworkMySql().BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<GapCodeTestDbContext>();

            builder.UseMySql("server=jrmysqlserver.mysql.database.azure.com;port=3306;user=mysqlserveradmin@jrmysqlserver;password=12345;database=gapcodetest_test;SslMode=Preferred;charset=utf8;")
                   .UseInternalServiceProvider(serviceProvider);

            _dbContext = new GapCodeTestDbContext(builder.Options);
            _dbContext.Database.Migrate();
        }

        [Fact]
        public void CiudadPorDefectoCreada()
        {
            var ciudad = new Ciudad
            {
                Nombre = "Bogotá"
            };

            _dbContext.Ciudad.Add(ciudad);
            _dbContext.SaveChanges();

            var ciudades = _dbContext.Ciudad.ToList();

            Assert.Equal(1, ciudades.Count());

            var c = ciudades.First();
            Assert.Equal("Bogotá", c.Nombre);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}