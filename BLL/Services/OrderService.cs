using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;


namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }
        public OrderService(IUnitOfWork unitOfWork) 
        {
            Database = unitOfWork;
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<OrderDTO> GetUsersOrders(int id)
        {
            var orderDTOs = new List<OrderDTO>();
            foreach (var order in Database.Orders.GetAll().Where(o => o.UserId.Equals(id))) 
            {
                orderDTOs.Add(new OrderDTO()
                {
                    Id = order.Id,
                    Price = order.Price,
                    User = MapperService.UserMapper.Map<UserDTO>(order.User),
                    PricelistDTOs = MapperService.PricelistMapper.Map<IEnumerable<Pricelist>, IEnumerable<PricelistDTO>>(order.Pricelists)
                });
            }
            return orderDTOs;
        }

        public void MakeOrder(OrderDTO ordedDTO)
        {
            Order order = new Order
            {
                UserId = ordedDTO.User.Id,
                Pricelists = GetPricelists(ordedDTO.PricelistDTOs),
                Price = ordedDTO.Price,
            };
            Database.Orders.Create(order);
            Database.Save();
        }

        private ICollection<Pricelist> GetPricelists(IEnumerable<PricelistDTO> pricelists)
        {
            var list = new List<Pricelist>();
            foreach (var pricelist in pricelists)
            {
                list.Add(Database.Pricelists.Find(pl => pl.Id.Equals(pricelist.Id)).FirstOrDefault());
            }
            return list;
        }
    }
}
