using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Repositories.Abstacations
{
    public interface IRepository<T> where T : class
    {
        void Aggiungi (T entity);
        void Modifica<T> (T entity);
        T Get (object id);
        void Elimina (object id);
        void SaveChanges();
    }
}
