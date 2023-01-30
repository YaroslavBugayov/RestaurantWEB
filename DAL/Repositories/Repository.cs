using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private ApplicationContext db;
        private DbSet<T> dbSet; 
        public Repository(ApplicationContext context) 
        {
            db = context;
            dbSet = db.Set<T>();
        }

        public void Create(T item)
        {
            dbSet.Add(item);
        }

        public void Delete(int id)
        {
            T item = dbSet.Find(id);
            if (item != null)
            {
                dbSet.Remove(item);
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> exp)
        {
            return dbSet.Where(exp).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet;
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
