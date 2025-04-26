using PointOfSale.Domain.RepositoryInterfaces;
using PointOfSale.Domain.UnitOfWorkInterfaces;
using PointOfSale.Infrastructure.ApplicationDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Infrastructure.UnitOfWorkClasses
{
    public class POSUnitOfWork : UnitOfWork, IPOSUnitOfWork
    {
        public IProductRepository Product { get; private set; }
        public POSUnitOfWork(ApplicationDbContext dbContext, IProductRepository product) : base(dbContext)
        {
            Product = product;
        }

    }
}
