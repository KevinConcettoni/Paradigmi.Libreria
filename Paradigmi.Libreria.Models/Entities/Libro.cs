using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Entities
{
    public class Libro
    {
        public Libro() { }
        public Libro(string Nome, string Autore, DateTime DataPubblicazione, string Editore, HashSet<Categoria> Categorie)
        {
            this.Nome = Nome;
            this.Autore = Autore;
            this.Categorie = Categorie;
            this.DataPubblicazione = DataPubblicazione;
            this.Editore = Editore;
        }
        public int IdLibro { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Autore {  get; set; } = string.Empty;
        public DateTime DataPubblicazione { get; set; }
        public string Editore { get; set; } = string.Empty;
        public virtual ICollection<Categoria> Categorie {  get; set; } = new HashSet<Categoria>();

    }
}
