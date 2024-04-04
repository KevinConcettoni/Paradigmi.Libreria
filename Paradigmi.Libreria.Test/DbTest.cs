using Paradigmi.Libreria.Models.Context;
using Paradigmi.Libreria.Models.Entities;
using Paradigmi.Libreria.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Test
{
    public class DbTest
    {
        public void RunDbTest()
        {
            var ctx = new MyDbContext();
            var categoriaRepo = new CategoriaRepository(ctx);
            var libroRepo = new LibroRepository(ctx);

            /*var nuovaCategoria = new Categoria()
            {
                Nome = "Horror"
            };*/

            // categoriaRepo.Aggiungi(nuovaCategoria); --> aggiunto
            //AggiungiLibro(ctx);
            //AggiungiUtente(ctx);
            //EliminaCategoria(ctx);
            //AggiungiLibroConPiuCategorie(ctx);
            // var categorieConId = libroRepo.GetCategorie(4);
            var libriPerCategoia = categoriaRepo.GetLibri("Romanzo");
            Console.ReadLine();
        }

        private void AggiungiLibro(MyDbContext ctx)
        {
            var categoriaRepo = new CategoriaRepository(ctx);
            var libroRepo = new LibroRepository(ctx);
            var nuovoLibro = new Libro()
            {
                Nome = "Il Gattopardo",
                Autore = "Giuseppe Tommasi",
                DataPubblicazione = new DateTime(1958, 1, 1),
                Editore = "Feltirnelli"
            };
            var categoriaRomanzo = new Categoria() { Nome = "Romanzo" };
            var categoriaEsistente = ctx.Categorie.FirstOrDefault(c => c.Nome.ToLower() == categoriaRomanzo.Nome.ToLower());
            if (categoriaEsistente == null) //  la categoria non esiste nel DB
                categoriaRepo.Aggiungi(categoriaRomanzo);
            nuovoLibro.Categorie.Add(categoriaRomanzo);
            libroRepo.Aggiungi(nuovoLibro);
            libroRepo.SaveChanges();
            categoriaRepo.SaveChanges();
        }

        private void AggiungiUtente(MyDbContext ctx)
        {
            var utenteRepo = new UtenteRepository(ctx);
            var nuovoUtente = new Utente()
            {
                Nome = "Kevin",
                Cognome = "Concettoni",
                Email = "kevin.concettoni@gmail.com",
                Password = "Kevin"
            }; 

            utenteRepo.Aggiungi(nuovoUtente);
            utenteRepo.SaveChanges();
        }

        private void AggiungiLibroConPiuCategorie(MyDbContext ctx) 
        {
            var libroRepo = new LibroRepository(ctx);
            var categoriaRepo = new CategoriaRepository(ctx);
            var nuovoLibro = new Libro()
            {
                Nome = "Moby Dick",
                Autore = "Herman Melville",
                DataPubblicazione = new DateTime(1932, 1, 1),
                Editore = "Mondadori"
            };

            var categoria1 = new Categoria { Nome = "Romanzo" };
            var categoria2 = new Categoria { Nome = "Avventura" };
            if (ControllaEsistenzaCategoria(categoria1, ctx))
                nuovoLibro.Categorie.Add(categoriaRepo.Get(categoria1.Nome));
            else
            {
                categoriaRepo.Aggiungi(categoria1);
                nuovoLibro.Categorie.Add(categoria1);
            }
            if (ControllaEsistenzaCategoria(categoria2, ctx))
                nuovoLibro.Categorie.Add(categoriaRepo.Get(categoria2.Nome));
            else
            {
                categoriaRepo.Aggiungi(categoria2);
                nuovoLibro.Categorie.Add(categoria2);
            }

            libroRepo.Aggiungi(nuovoLibro);
            categoriaRepo.SaveChanges();
            libroRepo.SaveChanges();
        }

        private void EliminaCategoria(MyDbContext ctx)
        {
            var categoria = new Categoria { Nome = "Avventura" };
            var categoriaRepo = new CategoriaRepository(ctx);
            var categoriaEsistente = ctx.Categorie.FirstOrDefault(c => c.Nome.ToLower() == categoria.Nome.ToLower());
            if (categoriaEsistente != null)
            {
                categoriaRepo.Elimina(categoria.Nome);
                categoriaRepo.SaveChanges();
            }

        }

        private bool ControllaEsistenzaCategoria(Categoria categoria, MyDbContext ctx)
        {
            var categoriaEsistente = ctx.Categorie.FirstOrDefault(c => c.Nome.ToLower() == categoria.Nome.ToLower());
            if (categoriaEsistente != null)
                return true;
            return false;
        }
    }
}
