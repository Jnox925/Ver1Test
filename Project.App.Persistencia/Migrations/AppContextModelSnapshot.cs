﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.App.Persistencia;

namespace Project.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Project.App.Dominio.Diagnostico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sintomas")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Diagnosticos");
                });

            modelBuilder.Entity("Project.App.Dominio.Instalaciones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("salonid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("salonid");

                    b.ToTable("Instalaciones");
                });

            modelBuilder.Entity("Project.App.Dominio.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("diagnosticoid")
                        .HasColumnType("int");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("vacunaid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("diagnosticoid");

                    b.HasIndex("vacunaid");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Project.App.Dominio.Salon", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("aforo")
                        .HasColumnType("int");

                    b.Property<string>("hora")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Salones");
                });

            modelBuilder.Entity("Project.App.Dominio.Vacuna", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("esquema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fabricante")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("Project.App.Dominio.Directivos", b =>
                {
                    b.HasBaseType("Project.App.Dominio.Persona");

                    b.Property<string>("unidad")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Directivos");
                });

            modelBuilder.Entity("Project.App.Dominio.Estudiante", b =>
                {
                    b.HasBaseType("Project.App.Dominio.Persona");

                    b.Property<string>("carrera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("semestre")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Estudiante");
                });

            modelBuilder.Entity("Project.App.Dominio.PersonalAseo", b =>
                {
                    b.HasBaseType("Project.App.Dominio.Persona");

                    b.Property<string>("turno")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PersonalAseo");
                });

            modelBuilder.Entity("Project.App.Dominio.Profesor", b =>
                {
                    b.HasBaseType("Project.App.Dominio.Persona");

                    b.Property<string>("departamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("materia")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Profesor");
                });

            modelBuilder.Entity("Project.App.Dominio.Instalaciones", b =>
                {
                    b.HasOne("Project.App.Dominio.Salon", "salon")
                        .WithMany()
                        .HasForeignKey("salonid");

                    b.Navigation("salon");
                });

            modelBuilder.Entity("Project.App.Dominio.Persona", b =>
                {
                    b.HasOne("Project.App.Dominio.Diagnostico", "diagnostico")
                        .WithMany()
                        .HasForeignKey("diagnosticoid");

                    b.HasOne("Project.App.Dominio.Vacuna", "vacuna")
                        .WithMany()
                        .HasForeignKey("vacunaid");

                    b.Navigation("diagnostico");

                    b.Navigation("vacuna");
                });
#pragma warning restore 612, 618
        }
    }
}
