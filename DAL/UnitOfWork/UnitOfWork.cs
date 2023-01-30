using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db = new ApplicationContext();
        private Repository<Order> orderRepository;
        private Repository<User> userRepository;
        private Repository<Pricelist> pricelistRepository;
        private Repository<Dish> dishRepository;
        private Repository<Size> sizeRepository;

        IRepository<User> IUnitOfWork.Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new Repository<User>(db);
                }
                return userRepository;
            }
        }

        IRepository<Order> IUnitOfWork.Orders
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new Repository<Order>(db);
                }
                return orderRepository;
            }
        }

        IRepository<Pricelist> IUnitOfWork.Pricelists
        {
            get
            {
                if (pricelistRepository == null)
                {
                    pricelistRepository = new Repository<Pricelist>(db);
                }
                return pricelistRepository;
            }
        }

        IRepository<Dish> IUnitOfWork.Dishes
        {
            get
            {
                if (dishRepository == null)
                {
                    dishRepository = new Repository<Dish>(db);
                }
                return dishRepository;
            }
        }

        IRepository<Size> IUnitOfWork.Sizes
        {
            get
            {
                if (sizeRepository == null)
                {
                    sizeRepository = new Repository<Size>(db);
                }
                return sizeRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
