using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private List<PricelistModel> pricelists = new List<PricelistModel>();
        private List<PricelistModel> pricelistsInOrder = new List<PricelistModel>();
        private IPricelistService _pricelistService;
        
        public HomeController(IPricelistService pricelistService) 
        {
            _pricelistService = pricelistService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            pricelists = MapperService
                .PricelistDTOtoModelMapper
                .Map<IEnumerable<PricelistDTO>, IEnumerable<PricelistModel>>
                (_pricelistService.GetPricelists()).ToList();

            //var dishes = new List<string>();
            //foreach (var pricelist in pricelists)
            //{
            //    dishes.Add(string.Format("{0} {1}",
            //        pricelist.Size.SizeName, pricelist.Dish.DishName));
            //}
            //ViewBag.Dishes = dishes.AsEnumerable();
            ViewBag.Dishes = pricelists;
            //ViewBag.Pricelists = pricelists;

            var dishesInOrder = new List<string>();
            foreach (var pricelist in pricelistsInOrder)
            {
                dishesInOrder.Add(string.Format("{0} {1}",
                    pricelist.Size.SizeName, pricelist.Dish.DishName));
            }
            ViewBag.Pricelists = dishesInOrder;
            
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(string select)
        //{
        //    var dishes = new List<string>();

        //    foreach (var pricelist in pricelists)
        //    {
        //        dishes.Add(string.Format("{0} {1}",
        //            pricelist.Size.SizeName, pricelist.Dish.DishName));
        //    }
        //    ViewBag.Dishes = dishes;
        //    ViewBag.Select = select;
        //    return View();
        //}

        public ActionResult AddDish()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            
            return View();
        }
    }
}