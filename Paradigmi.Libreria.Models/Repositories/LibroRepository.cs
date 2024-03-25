using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Restituisce una collezione di libri che combaciano coi criteri indicati
        /// </summary>
        /// <returns>La lista dei libri</returns>
        public IEnumerable<Libro> GetLibri(string? nome, string? autore, string? editore, DateTime? dataPubblicazione, string? categoria)
        {
            var query = _ctx.Set<Libro>().Include(c => c.Categorie).AsQueryable();
            if (nome != null && nome != string.Empty)
                query = query.Where(n => n.Nome.Contains(nome));
            if (autore != null && autore != string.Empty)
                query = query.Where(a => a.Autore.Contains(autore));    
            if (editore != null && editore != string.Empty)
                query = query.Where(e => e.Autore.Contains(editore));
            if (dataPubblicazione != null)
                query = query.Where(d => d.DataPubblicazione.Date.Equals(dataPubblicazione.Value.Date));
            if (categoria != null && categoria != string.Empty)
                query = query.Where(c => categoria.Equals(categoria));
            return query.ToList();


        }

    }
}
