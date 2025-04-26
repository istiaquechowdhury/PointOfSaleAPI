using PointOfSale.Domain.Entities;
using PointOfSale.Domain.RepositoryInterfaces;
using PointOfSale.Infrastructure.ApplicationDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Infrastructure.RepositoryClasses
{
    public class ProductRepository : Repository<Product,Guid>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
