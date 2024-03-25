using Paradigmi.Libreria.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Repositories.Abstacations
{
    public interface IUtenteRepository : IRepository<Utente>
    {
        bool CheckEmail (string email);
        bool ControlloCredenziali (string email, string password);
        Utente GetUtenteByEmail(string email);
    }
}
