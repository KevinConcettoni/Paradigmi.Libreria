using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Models.Entities;
using Paradigmi.Libreria.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Services
{
    public class LibroService : ILibroService
    {
        private readonly LibroRepository _libroRepository;
        private readonly CategoriaRepository _categoriaRepository;

        public LibroService(LibroRepository libroRepository, CategoriaRepository categoriaRepository)
        {
            _libroRepository = libroRepository;
            _categoriaRepository = categoriaRepository;
        }

        public bool AggiungiLibro(string nome, string autore, string editore, DateTime data, HashSet<string> categorie)
        {
            var categorieCollection = GetCategorie(categorie);
            Libro libro = new Libro(nome, autore, data, editore, categorieCollection);
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

        public IEnumerable<Libro> GetLibri(string? nome, string? autore, string? editore, DateTime? data, string categoria)
        {
            return _libroRepository.GetLibri(nome, autore, editore, data, categoria);
        }

        public bool ModificaLibro(int id, string nome, string autore, string editore, DateTime data, HashSet<string> categorie)
        {
            var categorieCollection = GetCategorie(categorie);
            if (_libroRepository.Get(id) == null)
                return false;
            Libro libro = _libroRepository.Get(id);
            libro.Nome = nome;
            libro.Autore = autore;
            libro.Editore = editore;    
            libro.DataPubblicazione = data;
            libro.Categorie = categorieCollection;
            _libroRepository.Modifica(libro);
            _libroRepository.SaveChanges();
            return true;

        }

        private HashSet<Categoria> GetCategorie(HashSet<string> categorie) 
        {
            var categorieCollection = new HashSet<Categoria>();
            foreach (string cat in categorie) 
            {
                Categoria categoria = _categoriaRepository.Get(cat);
                if (categoria != null)
                    categorieCollection.Add(categoria);
            }
            return categorieCollection;
        }
    }
}
