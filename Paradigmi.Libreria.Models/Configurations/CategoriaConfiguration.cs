using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Configurations
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorie");
            builder.HasKey(k => k.Nome);
            builder.Property(p => p.Nome)
                .HasMaxLength(50);
        }
    }
}
