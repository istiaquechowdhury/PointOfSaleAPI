using PointOfSale.Domain.Entities;
using PointOfSale.Domain.UnitOfWorkInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IPOSUnitOfWork _POSunitOfWork;
        public ProductService(IPOSUnitOfWork pOSunitOfWork)
        {
            _POSunitOfWork = pOSunitOfWork;
        }

        public void CreateProductAsync(Product product)
        {
            _POSunitOfWork.Product.Add(product);
            _POSunitOfWork.Save();
        }

        public IList<Product> GetAllProducts()
        {
           return _POSunitOfWork.Product.GetAll();
        }
    }
}
