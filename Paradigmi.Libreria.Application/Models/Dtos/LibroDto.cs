using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Models.Dtos
{
    public class LibroDto
    {
        public int IdLibro { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;
        public string Editore { get; set; } = string.Empty;
        public DateTime DataPubblicazione { get; set; } = DateTime.MinValue;
        public ICollection<Categoria> Categorie { get; set; } = new HashSet<Categoria>();

        public LibroDto(Libro libro)
        {
            libro.IdLibro = IdLibro;
            libro.Nome = Nome;
            libro.Autore = Autore;
            libro.Editore = Editore;
            libro.DataPubblicazione = DataPubblicazione;
            libro.Categorie = Categorie;
        }

        public Libro ToEntity(int id, string nome, string autore, string editore, DateTime data, HashSet<Categoria> categorie)
        {
            Libro libro = new Libro(nome, autore, data, editore, categorie);
            return libro;

        }
    }
}
