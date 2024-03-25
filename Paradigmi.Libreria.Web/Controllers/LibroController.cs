using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Application.Models.Requests;
using Paradigmi.Libreria.Models.Entities;
using Paradigmi.Libreria.Models.Repositories.Abstacations;

namespace Paradigmi.Libreria.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
                return Ok();
            else return BadRequest();
        }

        [HttpPut]
        [Route("modifica")]
        public IActionResult ModificaLibro([FromBody] ModificaLibroRequest request)
        {
            var categorie = GetCategorie(request.Categorie);
            if (_libroService.ModificaLibro(request.Id, request.Nome, request.Autore, request.Editore, request.DataPubblicazione,
                categorie))
                return Ok();
            else return BadRequest();
        }

        [HttpDelete]
        [Route("elimina")]
        public IActionResult EliminaLibro([FromBody] EliminaLibroRequest request)
        {
            if (_libroService.EliminaLibro(request.Id))
                return Ok();
            else 
                return BadRequest();
        }

        [HttpPost]
        [Route("lista")]
        public IActionResult GetLibri([FromBody] GetLibriRequest request)
        {
            var libri = _libroService.GetLibri(request.Nome, request.Autore, request.Editore, request.DataPubblicazione, request.Categoria);
            return Ok(libri);

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
