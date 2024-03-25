﻿using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Abstactions.Services
{
    public  interface ILibroService
    {
        bool AggiungiLibro(string nome, string autore, string editore, DateTime dataPubblicazione, HashSet<string> categorie);
        bool EliminaLibro(int id);
        public bool ModificaLibro(int id, string nome, string autore, string editore, DateTime data, HashSet<string> categorie);
        IEnumerable<Libro> GetLibri(string? nome, string? autore, string? editore, DateTime? data, string categorie);
    }
}
