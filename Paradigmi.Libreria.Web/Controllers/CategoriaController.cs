using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paradigmi.Libreria.Application.Abstactions.Services;
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
                return Ok();
            else 
                return BadRequest();
        }

        [HttpDelete]
        [Route("elimina")]
        public IActionResult EliminaCategoria([FromBody] EliminaCategoriaRequest request)
        {
            if (_categoriaService.EliminaCategoria(request.Nome))
                return Ok();
            else 
                return BadRequest();
        }
    }
}
