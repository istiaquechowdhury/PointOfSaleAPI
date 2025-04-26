using Microsoft.AspNetCore.Mvc;
using PointOfSale.API.DTOS;
using PointOfSale.Application.Services;
using PointOfSale.Domain.Entities;

namespace PointOfSale.API.Controllers
{
    [Route("api/ProductAPI")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]

        public  IActionResult CreateProduct([FromBody] ProductDTO productDto)
        {
            var Product = new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
            };

            _productService.CreateProductAsync(Product);    
            
            return Ok(Product); 
        }

        [HttpGet]   

        public IActionResult GetProducts()
        {
            var products = _productService.GetAllProducts();

            return Ok(products);

        }
        

    }
}
