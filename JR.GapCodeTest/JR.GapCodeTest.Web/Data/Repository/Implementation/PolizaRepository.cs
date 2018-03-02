using System;
using System.Linq;
using System.Threading.Tasks;
using JR.GapCodeTest.Web.Models;
using JR.GapCodeTest.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace JR.GapCodeTest.Web.Data.Repository.Implementation
{
    public class PolizaRepository : GenericRepository<Poliza>, IPolizaRepository
    {
        GapCodeTestDbContext _dbContext;
        
        public PolizaRepository(GapCodeTestDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteWithRelated(int id)
        {
            var poliza = await _dbContext.Poliza.Include(x => x.PolizaClientes).FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (poliza != null)
            {
                poliza.PolizaClientes.Clear();
                await _dbContext.SaveChangesAsync();

                _dbContext.Remove(poliza);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateWithRelated(PolizaDto p)
        {
            var poliza = await _dbContext.Poliza.Include(x => x.PolizaClientes).FirstOrDefaultAsync(x => x.Id.Equals(p.Id));

            if (poliza != null)
            {
                poliza.Nombre = p.Nombre;
                poliza.Descripcion = p.Descripcion;
                poliza.CoberturaMeses = p.CoberturaMeses;
                poliza.InicioVigencia = p.InicioVigencia;
                poliza.PorcentajeCubrimiento = p.PorcentajeCubrimiento;
                poliza.Precio = p.Precio;
                poliza.AgenciaId = p.Agencia.Id;
                poliza.TipoCubrimientoId = p.TipoCubrimiento.Id;
                poliza.TipoRiesgoId = p.TipoRiesgo.Id;
                poliza.PolizaClientes.Clear();

                await _dbContext.SaveChangesAsync();

                poliza.PolizaClientes = p.Clientes.Select(x => new PolizaCliente { ClienteId = x.Id }).ToList();

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}