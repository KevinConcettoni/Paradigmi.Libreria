using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Models.Requests
{
    public class GetLibriRequest
    {
        public string? Nome { get; set; }  = string.Empty;
        public string? Autore { get; set; } = string.Empty;
        public string? Editore { get; set; } = string.Empty;
        public string? Categoria { get; set; } = string.Empty;
    }
}
