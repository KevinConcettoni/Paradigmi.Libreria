using Microsoft.EntityFrameworkCore;
using Paradigmi.Libreria.Models.Context;
using Paradigmi.Libreria.Models.Entities;
using Paradigmi.Libreria.Models.Repositories.Abstacations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Paradigmi.Libreria.Models.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(MyDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Restituisce una lista di libri che appartengono ad una categoria
        /// </summary>
        /// <param name="Nome">Nome della categoria</param>
        /// <returns>Lista di libri appartenenti dalla categoria</returns>
        public IEnumerable<Libro> GetLibri(string Nome)
        { 
            return _ctx.Libri
                .Where(w=>w.Categorie.Any(c=>c.Nome.ToLower().Trim() == Nome.ToLower().Trim()))
                .ToList();
        }

        // faccio overload del metodo per evitare che si siano categorie con lo stesso nome ma lettere maiuscole/minuscole
        public Categoria Get(string nome)
        {
            var categoria = _ctx.Categorie.FirstOrDefault(n=>n.Nome.ToLower().Trim() == nome.ToLower().Trim());
            if (categoria != null)
                return _ctx.Categorie.Find(categoria.Nome);
            else
                return null;
        }
    }
}
