using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Models.Requests
{
    public class GetLibriRequest
    {
        public GetLibriRequest(string? nome, string? autore, string? editore, DateTime? dataPubblicazione, string? categoria, int from, int size)
        {
            this.Nome = nome;
            this.Autore = autore;
            this.Editore = editore;
            this.DataPubblicazione = dataPubblicazione;
            this.Categoria = categoria;
            this.From = from;
            this.Size = size;
        }
        public string? Nome { get; set; } 
        public string? Autore { get; set; } 
        public string? Editore { get; set; } 
        public DateTime? DataPubblicazione {  get; set; } 
        public string? Categoria { get; set; }
        public int From { get; set; }
        public int Size { get; set; }  
       
    }
}
