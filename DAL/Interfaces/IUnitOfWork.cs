using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Order> Orders { get; }
        IRepository<Pricelist> Pricelists { get; }
        IRepository<Dish> Dishes { get; }
        IRepository<Size> Sizes { get; }
        void Save();
    }
}
