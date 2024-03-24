using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Abstactions.Services
{
    public interface IUtenteService
    {
        public bool Registrazione(string nome, string cognome, string email, string password);
        public string Login (string email, string password); // se corretta restituisce il token 

    }
}
