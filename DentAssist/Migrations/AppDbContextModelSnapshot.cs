﻿// <auto-generated />
using System;
using DentAssist.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DentAssist.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DentAssist.Models.Data.Entities.Odontologo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Odontologos");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.PasoTratamiento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaEstimada")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlanTratamientoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TratamientoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlanTratamientoId");

                    b.HasIndex("TratamientoId");

                    b.ToTable("PasosTratamiento");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.PlanTratamiento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OdontologoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OdontologoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("PlanesTratamiento");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.Tratamiento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecioEstimado")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Tratamientos");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.Turno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OdontologoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PacienteId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OdontologoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.PasoTratamiento", b =>
                {
                    b.HasOne("DentAssist.Models.Data.Entities.PlanTratamiento", "PlanTratamiento")
                        .WithMany()
                        .HasForeignKey("PlanTratamientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentAssist.Models.Data.Entities.Tratamiento", "Tratamiento")
                        .WithMany("PasosTratamiento")
                        .HasForeignKey("TratamientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlanTratamiento");

                    b.Navigation("Tratamiento");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.PlanTratamiento", b =>
                {
                    b.HasOne("DentAssist.Models.Data.Entities.Odontologo", "Odontologo")
                        .WithMany("PlanesTratamiento")
                        .HasForeignKey("OdontologoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentAssist.Models.Data.Entities.Paciente", "Paciente")
                        .WithMany("PlanesTratamiento")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Odontologo");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.Turno", b =>
                {
                    b.HasOne("DentAssist.Models.Data.Entities.Odontologo", "Odontologo")
                        .WithMany("Turnos")
                        .HasForeignKey("OdontologoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DentAssist.Models.Data.Entities.Paciente", "Paciente")
                        .WithMany("Turnos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Odontologo");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.Odontologo", b =>
                {
                    b.Navigation("PlanesTratamiento");

                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.Paciente", b =>
                {
                    b.Navigation("PlanesTratamiento");

                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("DentAssist.Models.Data.Entities.Tratamiento", b =>
                {
                    b.Navigation("PasosTratamiento");
                });
#pragma warning restore 612, 618
        }
    }
}
