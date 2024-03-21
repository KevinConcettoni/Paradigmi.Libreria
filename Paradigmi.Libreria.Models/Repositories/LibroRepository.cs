using Paradigmi.Libreria.Models.Context;
using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Repositories
{
    public class LibroRepository : GenericRepository<Libro>
    {
        public LibroRepository(MyDbContext context) : base(context)
        {
        }
    }
}
