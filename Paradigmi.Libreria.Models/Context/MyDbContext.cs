﻿using Microsoft.EntityFrameworkCore;
using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Libro> Libri { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Utente> Utenti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=localhost;Initial catalog=Libreria;" +
                    "User Id=libreriaParadigmi;Password=libreriaParadigmi;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
                .HasMany(e => e.Categorie)
                .WithMany(e => e.Libri)
                .UsingEntity(
                "LibriCategorie",
                l => l.HasOne(typeof(Categoria)).WithMany().HasForeignKey("NomeCategoria").HasPrincipalKey(nameof(Categoria.Nome)),
                r => r.HasOne(typeof(Libro)).WithMany().HasForeignKey("IdLibro").HasPrincipalKey(nameof(Libro.IdLibro)),
                j => j.HasKey("IdLibro", "NomeCategoria"));
            // prende tutte le classi dentro models che implementano l'interfaccia per la configurzione
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
