using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Models.Requests
{
    public class EliminaCategoriaRequest
    {
        public EliminaCategoriaRequest(string nome) 
        {
            Nome = nome;    
        }
        public string Nome { get; set; }
    }
}
