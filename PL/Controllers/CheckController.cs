using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using PL.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;

namespace PL.Controllers
{
    [Authorize]
    public class CheckController : Controller
    {
        IOrderService _orderService;
        IUserService _userService;
        public CheckController(IOrderService orderService, IUserService userService) 
        {
            _orderService = orderService;
            _userService = userService;
        }
        [HttpGet]
        public ActionResult Check()
        {
            var user = _userService.GetUserByUsername(User.Identity.Name);
            var ordersList = new List<string>();
            var orderModels = MapperService
                .OrderDTOtoModelMapper
                .Map<IEnumerable<OrderDTO>, IEnumerable<OrderModel>>
                (_orderService.GetUsersOrders(user.Id));

            foreach (var order in orderModels)
            {
                foreach (var pricelist in order.pricelistModels)
                {
                    ordersList.Add(string.Format("{0} {1}, {2}",
                        pricelist.Size.SizeName, pricelist.Dish.DishName, pricelist.Price));
                }
                ordersList.Add(string.Format("Summary price: {0}", order.Price));
                ordersList.Add("--------------------------------------");
            }
            ViewBag.Orders = ordersList;
            return View();
        }
    }
}