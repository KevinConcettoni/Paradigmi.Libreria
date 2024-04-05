using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Application.Models.Requests;
using Paradigmi.Libreria.Application.Models.Responses;
using Paradigmi.Libreria.Application.Models.Dtos;
using Paradigmi.Libreria.Models.Entities;
using Paradigmi.Libreria.Models.Repositories.Abstacations;
using Paradigmi.Libreria.Application.Factories;

namespace Paradigmi.Libreria.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;
        private readonly ICategoriaRepository _categoriaRepository;

        public LibroController(ILibroService libroService, ICategoriaRepository categoriaRepository) 
        {
            _libroService = libroService;
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost]
        [Route("aggiungi")]
        public IActionResult AggiungiLibro([FromBody] AggiungiLibroRequest request)
        {
            var categorie = GetCategorie(request.Categorie);
            if (_libroService.AggiungiLibro(request.Nome, request.Autore, request.Editore, request.DataPubblicazione, categorie))
                return Ok(ResponseFactory.WithSuccess("Libro aggiunto con successo"));
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("modifica")]
        public IActionResult ModificaLibro([FromBody] ModificaLibroRequest request)
        {
            var categorie = GetCategorie(request.Categorie);
            if (_libroService.ModificaLibro(request.Id, request.Nome, request.Autore, request.Editore, request.DataPubblicazione,
                categorie))
                return Ok(ResponseFactory.WithSuccess($"Libro con Id {request.Id} modificato con successo"));
            else 
                return BadRequest();
        }

        [HttpDelete]
        [Route("elimina")]
        public IActionResult EliminaLibro([FromBody] EliminaLibroRequest request)
        {
            if (_libroService.EliminaLibro(request.Id))
                return Ok(ResponseFactory.WithSuccess($"Libro con Id {request.Id} eliminato con successo"));
            else 
                return BadRequest();
        }

        [HttpPost]
        [Route("lista")]
        public IActionResult GetLibri([FromBody] GetLibriRequest request)
        {
            int totalNum = 0;
            var libri = _libroService.GetLibri(request.Nome, request.Autore, request.Editore, request.DataPubblicazione, request.Categoria, request.From, request.Size, out totalNum);
            var response = new GetLibriResponse();
            response.NumPagine = (int) Math.Ceiling((double) totalNum/request.Size);
            response.Libri = libri.Select(l => new LibroDto(l)).ToList();
            return Ok(ResponseFactory.WithSuccess(response));
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
