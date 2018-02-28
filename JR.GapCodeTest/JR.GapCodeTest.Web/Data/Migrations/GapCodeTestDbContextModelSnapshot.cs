﻿// <auto-generated />
using JR.GapCodeTest.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JR.GapCodeTest.Web.Data.Migrations
{
    [DbContext(typeof(GapCodeTestDbContext))]
    partial class GapCodeTestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CiudadId");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.ToTable("Agencia");
                });

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Ciudad");
                });

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Documento");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.Poliza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CoberturaMeses");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("InicioVigencia");

                    b.Property<string>("Nombre");

                    b.Property<int>("PorcentajeCubrimiento");

                    b.Property<decimal>("Precio");

                    b.Property<int?>("TipoCubrimientoId");

                    b.Property<int?>("TipoRiesgoId");

                    b.HasKey("Id");

                    b.HasIndex("TipoCubrimientoId");

                    b.HasIndex("TipoRiesgoId");

                    b.ToTable("Poliza");
                });

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.PolizaCliente", b =>
                {
                    b.Property<int>("PolizaId");

                    b.Property<int>("ClienteId");

                    b.HasKey("PolizaId", "ClienteId");

                    b.HasIndex("ClienteId");

                    b.ToTable("PolizaCliente");
                });

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.Tipocubrimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Tipocubrimiento");
                });

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.Tiporiesgo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaxPorcentajeCubrimiento");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Tiporiesgo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.Agencia", b =>
                {
                    b.HasOne("JR.GapCodeTest.Web.Models.Ciudad", "Ciudad")
                        .WithMany("Agencias")
                        .HasForeignKey("CiudadId");
                });

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.Poliza", b =>
                {
                    b.HasOne("JR.GapCodeTest.Web.Models.Tipocubrimiento", "TipoCubrimiento")
                        .WithMany("Polizas")
                        .HasForeignKey("TipoCubrimientoId");

                    b.HasOne("JR.GapCodeTest.Web.Models.Tiporiesgo", "TipoRiesgo")
                        .WithMany("Polizas")
                        .HasForeignKey("TipoRiesgoId");
                });

            modelBuilder.Entity("JR.GapCodeTest.Web.Models.PolizaCliente", b =>
                {
                    b.HasOne("JR.GapCodeTest.Web.Models.Cliente", "Cliente")
                        .WithMany("PolizaClientes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JR.GapCodeTest.Web.Models.Poliza", "Poliza")
                        .WithMany("PolizaClientes")
                        .HasForeignKey("PolizaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JR.GapCodeTest.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JR.GapCodeTest.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JR.GapCodeTest.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JR.GapCodeTest.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
