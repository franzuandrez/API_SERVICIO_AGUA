﻿// <auto-generated />
using System;
using API_SERVICIO_AGUA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_SERVICIO_AGUA.Migrations
{
    [DbContext(typeof(OrdenContext))]
    [Migration("20200506164917_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_SERVICIO_AGUA.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("API_SERVICIO_AGUA.Models.Foto", b =>
                {
                    b.Property<int>("IdFoto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdOrden")
                        .HasColumnType("int");

                    b.Property<int?>("OrdenIdOrden")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFoto");

                    b.HasIndex("OrdenIdOrden");

                    b.ToTable("Foto");
                });

            modelBuilder.Entity("API_SERVICIO_AGUA.Models.Medidor", b =>
                {
                    b.Property<int>("IdMedidor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("NoMedidor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMedidor");

                    b.HasIndex("ClienteIdCliente");

                    b.ToTable("Medidor");
                });

            modelBuilder.Entity("API_SERVICIO_AGUA.Models.Motivo", b =>
                {
                    b.Property<int>("IdMotivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMotivo");

                    b.ToTable("Motivo");
                });

            modelBuilder.Entity("API_SERVICIO_AGUA.Models.Orden", b =>
                {
                    b.Property<int>("IdOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMedidor")
                        .HasColumnType("int");

                    b.Property<int>("IdMotivo")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioAsignador")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioDespacha")
                        .HasColumnType("int");

                    b.Property<int?>("MedidorIdMedidor")
                        .HasColumnType("int");

                    b.Property<int?>("MotivoIdMotivo")
                        .HasColumnType("int");

                    b.Property<string>("NoOrden")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioAsignadorIdUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioDespachaIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdOrden");

                    b.HasIndex("MedidorIdMedidor");

                    b.HasIndex("MotivoIdMotivo");

                    b.HasIndex("UsuarioAsignadorIdUsuario");

                    b.HasIndex("UsuarioDespachaIdUsuario");

                    b.ToTable("Orden");
                });

            modelBuilder.Entity("API_SERVICIO_AGUA.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("API_SERVICIO_AGUA.Models.Foto", b =>
                {
                    b.HasOne("API_SERVICIO_AGUA.Models.Orden", "Orden")
                        .WithMany("Fotos")
                        .HasForeignKey("OrdenIdOrden");
                });

            modelBuilder.Entity("API_SERVICIO_AGUA.Models.Medidor", b =>
                {
                    b.HasOne("API_SERVICIO_AGUA.Models.Cliente", "Cliente")
                        .WithMany("Medidores")
                        .HasForeignKey("ClienteIdCliente");
                });

            modelBuilder.Entity("API_SERVICIO_AGUA.Models.Orden", b =>
                {
                    b.HasOne("API_SERVICIO_AGUA.Models.Medidor", "Medidor")
                        .WithMany()
                        .HasForeignKey("MedidorIdMedidor");

                    b.HasOne("API_SERVICIO_AGUA.Models.Motivo", "Motivo")
                        .WithMany("Ordenes")
                        .HasForeignKey("MotivoIdMotivo");

                    b.HasOne("API_SERVICIO_AGUA.Models.Usuario", "UsuarioAsignador")
                        .WithMany("OrdenesAsignadas")
                        .HasForeignKey("UsuarioAsignadorIdUsuario");

                    b.HasOne("API_SERVICIO_AGUA.Models.Usuario", "UsuarioDespacha")
                        .WithMany("OrdenesDespachadas")
                        .HasForeignKey("UsuarioDespachaIdUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
