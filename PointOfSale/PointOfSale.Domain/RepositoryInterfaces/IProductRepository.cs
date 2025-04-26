using PointOfSale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Domain.RepositoryInterfaces
{
    public interface IProductRepository : IRepositoryBase<Product,Guid>
    {

    }
}
