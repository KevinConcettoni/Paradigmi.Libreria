using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Application.Factories;
using Paradigmi.Libreria.Application.Models.Requests;

namespace Paradigmi.Libreria.Web.Controllers
{
    [ApiController]
    [Route("api/v2/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService) 
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        [Route("aggiungi")]
        public IActionResult AggiungiCategoria([FromBody] AggiungiCategoriaRequest request)
        {
            if (_categoriaService.AggiungiCategoria(request.Nome))            
                return Ok(ResponseFactory.WithSuccess($"Categoria {request.Nome} aggiunta con successo"));
            else
                return BadRequest(ResponseFactory.WithError("Categoria già esistente"));
        }

        [HttpDelete]
        [Route("elimina")]
        public IActionResult EliminaCategoria([FromBody] EliminaCategoriaRequest request)
        {
            if (_categoriaService.EliminaCategoria(request.Nome))
                return Ok(ResponseFactory.WithSuccess($"Categoria {request.Nome} eliminata con successo"));
            else 
                return BadRequest(ResponseFactory.WithError("Categoria nulla o associata ad un libro"));
        }
    }
}
