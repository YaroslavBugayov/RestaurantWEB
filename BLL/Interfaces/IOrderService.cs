using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO ordedDTO);
        IEnumerable<OrderDTO> GetUsersOrders(int id);
        void Dispose();
    }
}
