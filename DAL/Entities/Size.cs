using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Size
    {
        public int Id { get; set; }
        public string SizeName { get; set; }
        public int Weight { get; set; }
        public virtual ICollection<Pricelist> Pricelists { get; set; }
    }
}
