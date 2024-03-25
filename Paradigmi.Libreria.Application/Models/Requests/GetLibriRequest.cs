using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Models.Requests
{
    public class GetLibriRequest
    {
        public GetLibriRequest(string nome, string autore, string editore, DateTime data, string categoria) 
        {
            Nome = nome;
            Autore = autore;
            Editore = editore;
            DataPubblicazione = data;
            Categoria = categoria;
        }
        public string? Nome { get; set; } 
        public string? Autore { get; set; }
        public string? Editore { get; set; }
        public DateTime? DataPubblicazione { get; set; }
        public string? Categoria { get; set; } 
    }
}
