using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public int Price { get; set; }
        public IEnumerable<PricelistDTO> PricelistDTOs { get; set; }
    }
}
