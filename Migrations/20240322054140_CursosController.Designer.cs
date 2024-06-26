﻿// <auto-generated />
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
    [Migration("20240322054140_CursosController")]
    partial class CursosController
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

                    b.HasKey("Id");

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

                    b.HasKey("Id");

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

                    b.Property<int>("CursoDadosId")
                        .HasColumnType("int");

                    b.Property<int>("CursoNivelId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("urlVideo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CursoDadosId");

                    b.HasIndex("CursoNivelId");

                    b.ToTable("CursoContent");
                });

            modelBuilder.Entity("WebApi.DTOs.Request.Cursos.CursoNivelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CursoNivel");
                });

            modelBuilder.Entity("WebApi.DTOs.Request.Cursos.UsuarioCursoNivelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CursoDadosId")
                        .HasColumnType("int");

                    b.Property<int>("CursoNivelId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CursoDadosId");

                    b.HasIndex("CursoNivelId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioCursoNivel");
                });

            modelBuilder.Entity("WebApi.DTOs.Request.Cursos.CursoContent", b =>
                {
                    b.HasOne("WebApi.DTO.Request.Cursos.CursosDadosModel", "CursoDados")
                        .WithMany()
                        .HasForeignKey("CursoDadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.DTOs.Request.Cursos.CursoNivelModel", "CursoNivel")
                        .WithMany()
                        .HasForeignKey("CursoNivelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CursoDados");

                    b.Navigation("CursoNivel");
                });

            modelBuilder.Entity("WebApi.DTOs.Request.Cursos.UsuarioCursoNivelModel", b =>
                {
                    b.HasOne("WebApi.DTO.Request.Cursos.CursosDadosModel", "CursoDados")
                        .WithMany()
                        .HasForeignKey("CursoDadosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.DTOs.Request.Cursos.CursoNivelModel", "CursoNivel")
                        .WithMany()
                        .HasForeignKey("CursoNivelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.DTO.Request.Usuario.UsuarioCadastroRequest", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CursoDados");

                    b.Navigation("CursoNivel");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
