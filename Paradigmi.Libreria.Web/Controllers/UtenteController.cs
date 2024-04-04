using Microsoft.AspNetCore.Mvc;
using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Application.Factories;
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
            var utente = request.ToEntity();
            if (_utenteService.Registrazione(utente.Nome, utente.Cognome, utente.Email, utente.Password))
            {
                var response = new RegistrationResponse();
                response.Utente = new Application.Models.Dtos.UtenteDto(utente);
                return Ok(ResponseFactory.WithSuccess(response));   
            }                
            else 
                return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginRequest request) 
        {
            var token = _utenteService.Login(request.Email, request.Password);
            if (token == null) 
                return BadRequest(ResponseFactory.WithError("Credenziali errate"));
            else 
                return Ok(new LoginResponse(token));
        }
    }
}
