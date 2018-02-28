using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using JR.GapCodeTest.Web.Data;
using JR.GapCodeTest.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JR.GapCodeTest.Web.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GapCodeTestDbContext(serviceProvider.GetRequiredService<DbContextOptions<GapCodeTestDbContext>>()))
            {
                var defaultPwd = "1234";
                var defaultRole = "Asesor";

                var asesor1Id = await CreateUser(serviceProvider, defaultPwd, "asesor@jrgapcodetest.com", defaultRole);

                SeedDB(context);
            }
        }

        private static async Task<string> CreateUser(IServiceProvider serviceProvider, string testUserPw, string UserName, string role)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByNameAsync(UserName);

            if (user == null)
            {
                user = new ApplicationUser { UserName = UserName, Email = UserName };
                await userManager.CreateAsync(user, testUserPw);
            }

            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }

            await userManager.AddToRoleAsync(user, role);

            return user.Id;
        }

        public static void SeedDB(GapCodeTestDbContext context)
        {
            if (context.Ciudad.Any())
            {
                return;
            }

            var ciudad = new Ciudad
            {
                Nombre = "Bogotá"
            };

            var agencia = new Agencia
            {
                Nombre = "Agencia Principal Bogotá",
                Ciudad = ciudad
            };

            var tipoCubrimiento1 = new Tipocubrimiento
            {
                Nombre = "Terremoto"
            };

            var tipoCubrimiento2 = new Tipocubrimiento
            {
                Nombre = "Incendio"
            };

            var tipoCubrimiento3 = new Tipocubrimiento
            {
                Nombre = "Robo"
            };

            var tipoCubrimiento4 = new Tipocubrimiento
            {
                Nombre = "Pérdida"
            };

            var tipoRiesgo1 = new Tiporiesgo
            {
                Nombre = "Bajo",
                MaxPorcentajeCubrimiento = 100
            };

            var tipoRiesgo2 = new Tiporiesgo
            {
                Nombre = "Medio",
                MaxPorcentajeCubrimiento = 100
            };

            var tipoRiesgo3 = new Tiporiesgo
            {
                Nombre = "Medio-Alto",
                MaxPorcentajeCubrimiento = 50
            };

            var tipoRiesgo4 = new Tiporiesgo
            {
                Nombre = "Alto",
                MaxPorcentajeCubrimiento = 50
            };

            var cliente1 = new Cliente
            {
                Documento = "123456",
                Nombre = "Jorge Ramirez"
            };

            var cliente2 = new Cliente
            {
                Documento = "654321",
                Nombre = "Pedro Perez"
            };

            var cliente3 = new Cliente
            {
                Documento = "998877",
                Nombre = "Gonzo Gonzales"
            };

            context.Ciudad.Add(ciudad);
            context.Agencia.Add(agencia);
            context.Tipocubrimiento.AddRange(tipoCubrimiento1, tipoCubrimiento2, tipoCubrimiento3, tipoCubrimiento4);
            context.Tiporiesgo.AddRange(tipoRiesgo1, tipoRiesgo2, tipoRiesgo3, tipoRiesgo4);
            context.Cliente.AddRange(cliente1, cliente2, cliente3);

            context.SaveChanges();
        }
    }
}