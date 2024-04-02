using Microsoft.Extensions.Options;
using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Application.Options;
using Paradigmi.Libreria.Application.Token;
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
    public class UtenteService : IUtenteService
    {
        private readonly IUtenteRepository _utenteRepository;
        private TokenGenerator _tokenService;

        public UtenteService(IUtenteRepository utenteRepository, IOptions<JwtAuthenticationOption> jwtAuthOptions)
        {
            _utenteRepository = utenteRepository;
            _tokenService = new TokenGenerator(jwtAuthOptions);
        }

        public string Login(string email, string password)
        {
            if (_utenteRepository.ControlloCredenziali(email, password))
                return _tokenService.CreateToken(_utenteRepository.GetUtenteByEmail(email));
            return String.Empty;
        }

        public bool Registrazione(string nome, string cognome, string email, string password)
        {
            if (_utenteRepository.CheckEmail(email))
                return false;
            Utente utente = new Utente(nome,cognome,email,password);
            _utenteRepository.Aggiungi(utente);
            _utenteRepository.SaveChanges();
            return true;
        }
    }
}
