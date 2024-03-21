﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libri");
            builder.HasKey(p=>p.IdLibro);
            builder.Property(p => p.Nome)
                .HasMaxLength(50);
            builder.Property(p=>p.Autore)
                .HasMaxLength(50);
            builder.Property(p => p.Editore)
                .HasMaxLength(50);


        }
    }
}
