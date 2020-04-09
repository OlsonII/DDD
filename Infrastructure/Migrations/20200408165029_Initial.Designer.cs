﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20200408165029_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.CDT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Periodo")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<double>("TasaInteres")
                        .HasColumnType("float");

                    b.Property<string>("TipoDeposito")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CDT");
                });

            modelBuilder.Entity("Domain.Entities.CuentaBancaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("CuentaBancaria");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CuentaBancaria");
                });

            modelBuilder.Entity("Domain.Entities.Fiducia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Periodo")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<double>("TasaInteres")
                        .HasColumnType("float");

                    b.Property<string>("TipoDeposito")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fiducias");
                });

            modelBuilder.Entity("Domain.Entities.MovimientoFinanciero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CDTId")
                        .HasColumnType("int");

                    b.Property<int?>("CuentaBancariaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaMovimiento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FiduciaId")
                        .HasColumnType("int");

                    b.Property<double>("ValorConsignacion")
                        .HasColumnType("float");

                    b.Property<double>("ValorRetiro")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CDTId");

                    b.HasIndex("CuentaBancariaId");

                    b.HasIndex("FiduciaId");

                    b.ToTable("MovimientoFinanciero");
                });

            modelBuilder.Entity("Domain.Entities.CuentaAhorro", b =>
                {
                    b.HasBaseType("Domain.Entities.CuentaBancaria");

                    b.HasDiscriminator().HasValue("CuentaAhorro");
                });

            modelBuilder.Entity("Domain.Entities.CuentaCorriente", b =>
                {
                    b.HasBaseType("Domain.Entities.CuentaBancaria");

                    b.HasDiscriminator().HasValue("CuentaCorriente");
                });

            modelBuilder.Entity("Domain.Entities.CuentaCredito", b =>
                {
                    b.HasBaseType("Domain.Entities.CuentaBancaria");

                    b.Property<double>("Deuda")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("CuentaCredito");
                });

            modelBuilder.Entity("Domain.Entities.MovimientoFinanciero", b =>
                {
                    b.HasOne("Domain.Entities.CDT", null)
                        .WithMany("Movimientos")
                        .HasForeignKey("CDTId");

                    b.HasOne("Domain.Entities.CuentaBancaria", "CuentaBancaria")
                        .WithMany("Movimientos")
                        .HasForeignKey("CuentaBancariaId");

                    b.HasOne("Domain.Entities.Fiducia", null)
                        .WithMany("Movimientos")
                        .HasForeignKey("FiduciaId");
                });
#pragma warning restore 612, 618
        }
    }
}