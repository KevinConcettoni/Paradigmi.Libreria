using Paradigmi.Libreria.Models.Context;
using Paradigmi.Libreria.Models.Repositories.Abstacations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Libreria.Models.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected MyDbContext _ctx;

        public GenericRepository(MyDbContext context) 
        {
            _ctx = context;
        }
        public void Aggiungi (T entity)
        {
            _ctx.Set<T>().Add(entity);
        }

        public void Modifica<T> (T entity)
        {
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public T Get(object id) 
        {
            return _ctx.Set<T>().Find(id);
        }
        public void Elimina (object id)
        {
            var entity = Get(id);
            _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }
    }
}
