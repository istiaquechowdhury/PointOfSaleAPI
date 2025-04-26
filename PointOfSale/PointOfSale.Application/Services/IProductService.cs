using PointOfSale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale.Application.Services
{
    public interface IProductService
    {
        void CreateProductAsync(Product product);
        IList<Product> GetAllProducts();
    }
}
