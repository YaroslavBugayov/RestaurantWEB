using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.UnitOfWork;
using Ninject.Modules;

namespace BLL.Infrastructure
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IPricelistService>().To<PricelistService>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
