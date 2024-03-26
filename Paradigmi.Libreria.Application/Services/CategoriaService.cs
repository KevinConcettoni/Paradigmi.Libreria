﻿using Paradigmi.Libreria.Application.Abstactions.Services;
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
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository) 
        {
            _categoriaRepository = categoriaRepository;
        }
        public bool AggiungiCategoria(string nome)
        {
            if(_categoriaRepository.Get(nome) != null)
                return false;
            Categoria categoria = new Categoria();
            categoria.Nome = nome;
            _categoriaRepository.Aggiungi(categoria);
            _categoriaRepository.SaveChanges();
            return true;
        }

        public bool EliminaCategoria(string nome)
        {
            if (_categoriaRepository.Get(nome) == null || _categoriaRepository.Get(nome).Libri.Any())
                return false;
            _categoriaRepository.Elimina(nome);
            _categoriaRepository.SaveChanges();
            return true;
        }
    }
}
