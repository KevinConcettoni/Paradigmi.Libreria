using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Repositories.Abstacations
{
    public interface ILibroRepository : IRepository<Libro>
    {
        IEnumerable<Categoria> GetCategorie(int Id);
        IEnumerable<Libro> GetLibri(string? nome, string? autore, string? editore, DateTime? dataPubblicazione, string? categoria, int pageNum, int pageSize, out int totalNum);
    }
}
