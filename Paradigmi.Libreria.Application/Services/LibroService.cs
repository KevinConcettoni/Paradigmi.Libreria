using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Models.Entities;
using Paradigmi.Libreria.Models.Repositories;
using Paradigmi.Libreria.Models.Repositories.Abstacations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LibroService(ILibroRepository libroRepository, ICategoriaRepository categoriaRepository)
        {
            _libroRepository = libroRepository;
            _categoriaRepository = categoriaRepository;
        }

        public bool AggiungiLibro(string nome, string autore, string editore, DateTime data, HashSet<Categoria> categorie)
        {
            Libro libro = new Libro(nome, autore, data, editore, categorie);
            _libroRepository.Aggiungi(libro);
            _libroRepository.SaveChanges();
            return true;
        }

        public bool EliminaLibro(int Id)
        {
            if (Id > 0 && _libroRepository.Get(Id) != null)
            {
                _libroRepository.Elimina(Id);
                _libroRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Libro> GetLibri(string? nome, string? autore, string? editore, DateTime? data, string? categoria, int pageNum, int pageSize, out int totalNum)
        {
            return _libroRepository.GetLibri(nome, autore, editore, data, categoria, pageNum, pageSize, out totalNum);
        }

        public bool ModificaLibro(int id, string nome, string autore, string editore, DateTime data, HashSet<Categoria> categorie)
        {
            if (_libroRepository.Get(id) == null)
                return false;
            Libro libro = _libroRepository.Get(id);
            libro.Nome = nome;
            libro.Autore = autore;
            libro.Editore = editore;    
            libro.DataPubblicazione = data;
            libro.Categorie = categorie;
            _libroRepository.Modifica(libro);
            _libroRepository.SaveChanges();
            return true;

        }
    }
}
