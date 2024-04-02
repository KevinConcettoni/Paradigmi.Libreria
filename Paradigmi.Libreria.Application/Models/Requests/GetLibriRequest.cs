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
        public GetLibriRequest(string? nome, string? autore, string? editore, DateTime? dataPubblicazione, string? categoria, int pageSize, int pageNum)
        {
            this.Nome = nome;
            this.Autore = autore;
            this.Editore = editore;
            this.DataPubblicazione = dataPubblicazione;
            this.Categoria = categoria;
            this.PageSize = pageSize;
            this.PageNum = pageNum;
        }
        public string? Nome { get; set; }  = string.Empty;
        public string? Autore { get; set; } = string.Empty;
        public string? Editore { get; set; } = string.Empty;
        public DateTime? DataPubblicazione {  get; set; } = DateTime.MinValue;
        public string? Categoria { get; set; } = string.Empty;
        public int PageSize { get; set; }
        public int PageNum { get; set; }  
       
    }
}
