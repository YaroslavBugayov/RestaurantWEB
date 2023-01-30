using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T item);
        IEnumerable<T> Find(Expression<Func<T, bool>> exp);
        void Update(T item);
        void Delete(int id);
    }
}
