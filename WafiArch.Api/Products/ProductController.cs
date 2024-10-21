using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WafiArch.Application.Products;
using WafiArch.Application.Products.Dtos;
using WafiArch.Domain.Product;
using WafiArch.EntityFrameworkCore.Data;

namespace WafiArch.Api.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpPost]
        [Route("[Action]")]
        public IActionResult CreateProduct(Product product)
        {
            var alpha = _productAppService.CreateProduct(product);

            return Ok(alpha);
        }
        [HttpGet]
        [Route("[Action]")]
        public IActionResult GetAllProduct()
        {
            IEnumerable<Product> products = _productAppService.GetAll();
            if(products==null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        
        [HttpPut]
        [Route("[action]/{Id}")]
        public IActionResult Update(int id, ProductDto product)
        {
            if(id != product.Id)
            {
                return BadRequest();
            }
            ProductDto productDto = _productAppService.Update(product);
            return Ok(productDto);
        }

        [HttpDelete]
        [Route("[action]/{id}")]

        public IActionResult DeleteProduct(int id)
        {
            ProductDto product = _productAppService.Get(id);

            if (product == null) return BadRequest();

            _productAppService.Delete(id);
            return Ok();
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetProductById(int id)
        {
            ProductDto productDto = _productAppService.Get(id);
            return Ok(productDto);
        }
    }

}
