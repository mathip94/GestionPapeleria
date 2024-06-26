using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DataAccess
{
    public class Repository<T>: IRepository<T> where T : class, IIdentityById
    {
        protected DbContext Contexto { get; set; }

        public T Add(T item)
        {
            Contexto.Set<T>().Add(item);
            Contexto.SaveChanges();
            return item;
        }

        public void Remove(T item)
        {
            Contexto.Set<T>().Remove(item);
            Contexto.SaveChanges();
        }

        public void Update(T item)
        {
            Contexto.Entry(item).State = EntityState.Modified;
            Contexto.SaveChanges();
        }

        public virtual T Get(int id)
        {
            T item = Contexto.Set<T>().FirstOrDefault(e => e.Id == id);
            return item;
        }
    }
}
