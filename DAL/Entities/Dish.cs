using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string DishName { get; set; }
        public virtual ICollection<Pricelist> Pricelists { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set;}
    }
}
