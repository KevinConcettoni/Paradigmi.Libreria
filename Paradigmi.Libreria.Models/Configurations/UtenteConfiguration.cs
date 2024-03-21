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
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utenti");
            builder.HasKey(k => k.IdUtente);
            builder.Property(p => p.Nome)
                .HasMaxLength(50);
            builder.Property(p => p.Cognome)
                .HasMaxLength(50);
            builder.Property(p => p.Email)
                .HasMaxLength(50);
            builder.Property(p => p.Password)
                .HasMaxLength(50);
        }
    }
}
