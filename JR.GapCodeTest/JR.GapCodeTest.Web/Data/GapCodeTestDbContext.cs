using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JR.GapCodeTest.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JR.GapCodeTest.Web.Data
{
    public class GapCodeTestDbContext : IdentityDbContext<ApplicationUser>  
    {
        public GapCodeTestDbContext(DbContextOptions<GapCodeTestDbContext> options) : base(options)
        { }
        
        public virtual DbSet<Agencia> Agencia { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Poliza> Poliza { get; set; }
        public virtual DbSet<Tipocubrimiento> Tipocubrimiento { get; set; }
        public virtual DbSet<Tiporiesgo> Tiporiesgo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolizaCliente>().HasKey(t => new { t.PolizaId, t.ClienteId });

            //Added to prevent delete on cascade
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}