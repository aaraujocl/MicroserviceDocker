﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webapi_docker.Persistencia;

namespace webapi_docker.Migrations
{
    [DbContext(typeof(ContextoDocker))]
    partial class ContextoDockerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("webapi_docker.Modelo.Categoria", b =>
                {
                    b.Property<int>("Codfamilia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Codnegocio")
                        .HasColumnType("integer");

                    b.Property<string>("Imagen")
                        .HasColumnType("text");

                    b.Property<string>("Nomfamilia")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<int>("View")
                        .HasColumnType("integer");

                    b.HasKey("Codfamilia");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("webapi_docker.Modelo.SubCategoria", b =>
                {
                    b.Property<int>("Codsubfamilia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("Codfamilia")
                        .HasColumnType("integer");

                    b.Property<int>("Codnegocio")
                        .HasColumnType("integer");

                    b.Property<string>("Imagen")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.Property<int>("View")
                        .HasColumnType("integer");

                    b.HasKey("Codsubfamilia");

                    b.ToTable("SubCategoria");
                });
#pragma warning restore 612, 618
        }
    }
}