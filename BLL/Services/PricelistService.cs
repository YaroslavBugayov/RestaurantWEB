using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class PricelistService : IPricelistService
    {
        IUnitOfWork Database { get; set; }
        public PricelistService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<PricelistDTO> GetPricelists()
        {
            return MapperService.
                PricelistMapper.
                Map<IEnumerable<Pricelist>, IEnumerable<PricelistDTO>>(Database.Pricelists.GetAll().ToList());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
