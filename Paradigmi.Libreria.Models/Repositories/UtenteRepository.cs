using Paradigmi.Libreria.Models.Context;
using Paradigmi.Libreria.Models.Entities;
using Paradigmi.Libreria.Models.Repositories.Abstacations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>, IUtenteRepository
    {
        public UtenteRepository(MyDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Controlla se l'email sia già presente nel Db
        /// </summary>
        /// <returns>True se è presente, False altrimenti</returns>
        public bool CheckEmail (string email)
        {
            if (_ctx.Utenti.Any(u => u.Email.Equals(email)))
                return true;
            return false;
        }

        /// <summary>
        /// Controlla che le credenziali inserite siano corrette 
        /// </summary>
        /// <returns>True se l'utente esiste, False altrimenti</returns>
        public bool ControlloCredenziali (string email, string password) 
        {
            var utente = _ctx.Utenti.FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));
            return utente != null;
        }

        /// <summary>
        /// Restituisce l'utente passata la mail
        /// </summary>
        public Utente GetUtenteByEmail(string email) 
        {
            return _ctx.Utenti.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
