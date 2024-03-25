﻿using Microsoft.Extensions.Options;
using Paradigmi.Libreria.Application.Abstactions.Services;
using Paradigmi.Libreria.Application.Options;
using Paradigmi.Libreria.Models.Entities;
using Paradigmi.Libreria.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Services
{
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;
        private TokenService _tokenService;

        public UtenteService(UtenteRepository utenteRepository, IOptions<JwtAuthenticationOption> jwtAuthOptions)
        {
            _utenteRepository = utenteRepository;
            _tokenService = new TokenService(jwtAuthOptions);
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
