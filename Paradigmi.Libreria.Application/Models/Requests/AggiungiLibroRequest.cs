using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Models.Requests
{
    public class AggiungiLibroRequest
    {
        public AggiungiLibroRequest (string nome, string autore, string editore, DateTime dataPubblicazione, HashSet<string> categorie)
        {
            Nome = nome;
            Autore = autore;
            Editore = editore;
            DataPubblicazione = dataPubblicazione;
            Categorie = categorie;
        }
    
        public string Nome { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;
        public string Editore { get; set; } = string.Empty;
        public DateTime DataPubblicazione { get; set; } 
        public HashSet<string> Categorie { get; set; } = new HashSet<string>();


    }
}
