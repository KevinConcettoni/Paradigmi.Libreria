using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Models.Requests
{
    public class AggiungiCategoriaRequest
    {
        public AggiungiCategoriaRequest(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
    }
}
