using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Application.Models.Requests
{
    public class RegistrationRequest
    {
        public string Nome {  get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    

        public Utente ToEntity()
        {
            return new Utente(Nome, Cognome,Email,Password);
        }
    }
}
