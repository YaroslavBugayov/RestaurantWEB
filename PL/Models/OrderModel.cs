using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public int Price { get; set; }
        public IEnumerable<PricelistModel> pricelistModels { get; set; }
    }
}