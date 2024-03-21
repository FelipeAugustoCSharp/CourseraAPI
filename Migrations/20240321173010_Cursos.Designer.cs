﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Infrastructure;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240321173010_Cursos")]
    partial class Cursos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.DTO.Request.Cursos.CursosDadosModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CursoContentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioCursoNivelModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CursoContentId");

                    b.HasIndex("UsuarioCursoNivelModelId");

                    b.ToTable("CursoDados");
                });

            modelBuilder.Entity("WebApi.DTO.Request.Usuario.UsuarioCadastroRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UsuarioCursoNivelModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioCursoNivelModelId");

                    b.ToTable("UsuarioCadastro");
                });

            modelBuilder.Entity("WebApi.DTOs.Request.Cursos.CursoContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("urlVideo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CursoContent");
                });

            modelBuilder.Entity("WebApi.DTOs.Request.Cursos.CursoNivelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CursoContentId")
                        .HasColumnType("int");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioCursoNivelModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CursoContentId");

                    b.HasIndex("UsuarioCursoNivelModelId");

                    b.ToTable("CursoNivel");
                });

            modelBuilder.Entity("WebApi.DTOs.Request.Cursos.UsuarioCursoNivelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("UsuarioCursoNivel");
                });

            modelBuilder.Entity("WebApi.DTO.Request.Cursos.CursosDadosModel", b =>
                {
                    b.HasOne("WebApi.DTOs.Request.Cursos.CursoContent", null)
                        .WithMany("IdCurso")
                        .HasForeignKey("CursoContentId");

                    b.HasOne("WebApi.DTOs.Request.Cursos.UsuarioCursoNivelModel", null)
                        .WithMany("IdCurso")
                        .HasForeignKey("UsuarioCursoNivelModelId");
                });

            modelBuilder.Entity("WebApi.DTO.Request.Usuario.UsuarioCadastroRequest", b =>
                {
                    b.HasOne("WebApi.DTOs.Request.Cursos.UsuarioCursoNivelModel", null)
                        .WithMany("IdUsuario")
                        .HasForeignKey("UsuarioCursoNivelModelId");
                });

            modelBuilder.Entity("WebApi.DTOs.Request.Cursos.CursoNivelModel", b =>
                {
                    b.HasOne("WebApi.DTOs.Request.Cursos.CursoContent", null)
                        .WithMany("IdNivel")
                        .HasForeignKey("CursoContentId");

                    b.HasOne("WebApi.DTOs.Request.Cursos.UsuarioCursoNivelModel", null)
                        .WithMany("IdNivel")
                        .HasForeignKey("UsuarioCursoNivelModelId");
                });

            modelBuilder.Entity("WebApi.DTOs.Request.Cursos.CursoContent", b =>
                {
                    b.Navigation("IdCurso");

                    b.Navigation("IdNivel");
                });

            modelBuilder.Entity("WebApi.DTOs.Request.Cursos.UsuarioCursoNivelModel", b =>
                {
                    b.Navigation("IdCurso");

                    b.Navigation("IdNivel");

                    b.Navigation("IdUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
