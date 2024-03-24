using Microsoft.AspNetCore.Mvc;
using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Application.Models.Requests;
using Paradigmi.Libreria.Application.Models.Responses;

namespace Paradigmi.Libreria.Web.Controllers
{
    [Route ("api/v1/[controller]")]
    [ApiController]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;

        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpPost]
        [Route("registrazione")]
        public IActionResult Registrazione([FromBody] RegistrationRequest request)
        {
            if (_utenteService.Registrazione(request.Nome, request.Cognome, request.Email, request.Password))
                return Ok();
            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request) 
        {
            var token = _utenteService.Login(request.Email, request.Password);
            if (token == null) 
                return BadRequest();
            else return Ok(new LoginResponse(token));
        }
    }
}
