using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Entities
{
    public class Categoria
    {
        public string Nome { get; set; } = string.Empty;
        public ICollection<Libro> Libri { get; set; } = new List<Libro>();
    }
}
