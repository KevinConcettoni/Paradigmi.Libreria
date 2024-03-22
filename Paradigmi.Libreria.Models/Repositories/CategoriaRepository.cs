using Paradigmi.Libreria.Models.Context;
using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Paradigmi.Libreria.Models.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public CategoriaRepository(MyDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Restituisce una lista di libri che appartengono ad una categoria
        /// </summary>
        /// <param name="Nome">Nome della categoria</param>
        /// <returns>Lista di libri appartenenti dalla categoria</returns>
        public List<Libro> GetLibri(string Nome)
        { 
            return _ctx.Libri
                .Where(w=>w.Categorie.Any(c=>c.Nome.ToLower().Trim() == Nome.ToLower().Trim()))
                .ToList();
        }
    }
}
