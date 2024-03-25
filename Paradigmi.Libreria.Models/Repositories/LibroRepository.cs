using Paradigmi.Libreria.Models.Context;
using Paradigmi.Libreria.Models.Entities;
using Paradigmi.Libreria.Models.Repositories.Abstacations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Repositories
{
    public class LibroRepository : GenericRepository<Libro>, ILibroRepository
    {
        public LibroRepository(MyDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Restituisce la lista di categorie che appartengono a quel libro
        /// </summary>
        /// <param name="id">Id del libro</param>
        /// <returns>La lista di categorie</returns>
        public IEnumerable<Categoria> GetCategorie(int Id)
        {
            return _ctx.Libri
                .Where(w => w.IdLibro == Id)
                .SelectMany(c => c.Categorie)
                .ToList();
        }
    }
}
