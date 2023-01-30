using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Pricelist
    {
        public int Id { get; set; }
        public virtual Dish Dish { get; set; }
        public int DishId { get; set; }
        public virtual Size Size { get; set; }
        public int SizeId { get; set; }
        public int Price { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
