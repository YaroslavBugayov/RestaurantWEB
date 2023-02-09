using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        private IPricelistService _pricelistService;
        private List<string> _dishes = new List<string>();
        private List<PricelistModel> _pricelists = new List<PricelistModel>();

        public HomeController(IPricelistService pricelistService) 
        {
            _pricelistService = pricelistService;
            FillDishes();
        }

        public ActionResult Index()
        {
            ViewBag.Dishes = _dishes;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string select, List<PricelistModel> list)
        {
            var currentPricelistsInOrder = new List<PricelistModel>();
            if (list != null)
            {
                currentPricelistsInOrder.AddRange(list);
            }
            currentPricelistsInOrder.Add(_pricelists[int.Parse(select)]);

            var dishesInOrder = new List<string>();
            foreach (var pricelist in currentPricelistsInOrder)
            {
                dishesInOrder.Add(string.Format("{0} {1}",
                    pricelist.Size.SizeName, pricelist.Dish.DishName));
            }
            ViewBag.Pricelists = dishesInOrder;
            //return View();
            return View(currentPricelistsInOrder);
        }

        public void FillDishes()
        {
            _pricelists = MapperService
                .PricelistDTOtoModelMapper
                .Map<IEnumerable<PricelistDTO>, IEnumerable<PricelistModel>>
                (_pricelistService.GetPricelists()).ToList();

            foreach (var pricelist in _pricelists)
            {
                _dishes.Add(string.Format("{0} {1}",
                    pricelist.Size.SizeName, pricelist.Dish.DishName));
            }
        }

    }
}