using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class PricelistModel
    {
        public int Id { get; set; }
        public DishDTO Dish { get; set; }
        public SizeDTO Size { get; set; }
        public int Price { get; set; }
    }
}