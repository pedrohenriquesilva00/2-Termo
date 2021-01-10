﻿using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Contexts
{
    /// <summary>
    /// Essa classe é a responsável pelo contexto do projeto
    /// Faz a comunicação entre API e Banco de Dados
    /// </summary>
    public class InLockContext : DbContext
    {
        public DbSet <TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Estudios> Estudios { get; set; }

        public DbSet<Jogos> Jogos { get; set; }

        /// <summary>
        /// Define as opções de construção do Banco de Dados
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEV22\\SQLEXPRESS; Database=InLock_Games_CodeFirst; user Id=sa; pwd=sa@132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposUsuario>().HasData(
                new TiposUsuario
                {
                    IdTipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TiposUsuario
                {
                    IdTipoUsuario = 2,
                    Titulo = "Cliente"
                });

            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {
                    IdUsuario = 1,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    IdTipoUsuario = 1
                },
                new Usuarios
                {
                    IdUsuario = 2,
                    Email = "cliente@cliente",
                    Senha = "cliente",
                    IdTipoUsuario = 2
                });

            modelBuilder.Entity<Estudios>().HasData(
                new Estudios
                {
                    IdEstudio = 1,
                    NomeEstudio = "Blizzard"
                },
                new Estudios
                {
                    IdEstudio = 2,
                    NomeEstudio = "Rockstar Studios"
                },
                new Estudios
                {
                    IdEstudio = 3,
                    NomeEstudio = "Square Enix"
                });

            modelBuilder.Entity<Jogos>().HasData(
                new Jogos
                {
                    IdJogo = 1,
                    NomeJogo = "Diablo 3",
                    DataLancamento = Convert.ToDateTime("15/05/2012"),
                    Descricao = "É um jogo bacana!",
                    Valor = Convert.ToDecimal("99,99"),
                    IdEstudio = 1
                },
                new Jogos
                {
                    IdJogo = 2,
                    NomeJogo = "Read Redemption II",
                    DataLancamento = Convert.ToDateTime("26/10/2018"),
                    Descricao = "Jogo legal!",
                    Valor = Convert.ToDecimal("120,00"),
                    IdEstudio = 2
                });
        }
    }
}
