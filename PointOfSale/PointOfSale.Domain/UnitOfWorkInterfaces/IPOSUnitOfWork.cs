using PointOfSale.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Domain.UnitOfWorkInterfaces
{
    public interface IPOSUnitOfWork : IUnitOfWork   
    {
        public IProductRepository Product { get; }

    }
}
