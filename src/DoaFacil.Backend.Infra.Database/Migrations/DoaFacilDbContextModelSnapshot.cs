﻿// <auto-generated />
using System;
using DoaFacil.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoaFacil.Backend.Infra.Database.Migrations
{
    [DbContext(typeof(DoaFacilDbContext))]
    partial class DoaFacilDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.AnuncioEntity.Anuncio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ChavePix")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Meta")
                        .HasColumnType("decimal(15, 2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.HasIndex("Data");

                    b.HasIndex("UsuarioId");

                    b.ToTable("anuncio", (string)null);
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.CategoriaEntity.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("categoria", (string)null);
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.CidadeEntity.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<Guid>("UfId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.HasIndex("UfId");

                    b.ToTable("cidade", (string)null);
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.DoacaoEntity.Doacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AnuncioId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(15, 2)");

                    b.HasKey("Id");

                    b.HasIndex("AnuncioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("doacao", (string)null);
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity.EnderecoUsuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.Property<Guid>("CidadeId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("endereco_usuario", (string)null);
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity.ImagemAnuncio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AnuncioId")
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("Conteudo")
                        .IsRequired()
                        .HasColumnType("MEDIUMBLOB");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("Principal")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AnuncioId");

                    b.ToTable("imagem_anuncio", (string)null);
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.UfEntity.Uf", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("uf", (string)null);
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.UsuarioEntity.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("CpfCnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("varchar(55)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("varchar(55)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Email", "Senha")
                        .HasDatabaseName("email_senha");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.AnuncioEntity.Anuncio", b =>
                {
                    b.HasOne("DoaFacil.Backend.Domain.Entities.CategoriaEntity.Categoria", "Categoria")
                        .WithMany("Anuncios")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoaFacil.Backend.Domain.Entities.UsuarioEntity.Usuario", "Usuario")
                        .WithMany("Anuncios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.CidadeEntity.Cidade", b =>
                {
                    b.HasOne("DoaFacil.Backend.Domain.Entities.UfEntity.Uf", "Uf")
                        .WithMany("Cidades")
                        .HasForeignKey("UfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uf");
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.DoacaoEntity.Doacao", b =>
                {
                    b.HasOne("DoaFacil.Backend.Domain.Entities.AnuncioEntity.Anuncio", "Anuncio")
                        .WithMany("Doacoes")
                        .HasForeignKey("AnuncioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoaFacil.Backend.Domain.Entities.UsuarioEntity.Usuario", "Usuario")
                        .WithMany("Doacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anuncio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity.EnderecoUsuario", b =>
                {
                    b.HasOne("DoaFacil.Backend.Domain.Entities.CidadeEntity.Cidade", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DoaFacil.Backend.Domain.Entities.UsuarioEntity.Usuario", "Usuario")
                        .WithMany("Enderecos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity.ImagemAnuncio", b =>
                {
                    b.HasOne("DoaFacil.Backend.Domain.Entities.AnuncioEntity.Anuncio", "Anuncio")
                        .WithMany("Imagens")
                        .HasForeignKey("AnuncioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anuncio");
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.AnuncioEntity.Anuncio", b =>
                {
                    b.Navigation("Doacoes");

                    b.Navigation("Imagens");
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.CategoriaEntity.Categoria", b =>
                {
                    b.Navigation("Anuncios");
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.CidadeEntity.Cidade", b =>
                {
                    b.Navigation("Enderecos");
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.UfEntity.Uf", b =>
                {
                    b.Navigation("Cidades");
                });

            modelBuilder.Entity("DoaFacil.Backend.Domain.Entities.UsuarioEntity.Usuario", b =>
                {
                    b.Navigation("Anuncios");

                    b.Navigation("Doacoes");

                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
