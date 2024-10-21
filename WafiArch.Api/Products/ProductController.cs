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
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ProductController(IProductAppService productAppService, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _productAppService = productAppService;
            _mapper = mapper;
            _context = applicationDbContext;
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
        
        [HttpPut("{id}")]
        ////[Route("[action]/{Id}")]
        public IActionResult Update(int id, ProductDto product)
        {
            if(id != product.Id)
            {
                return BadRequest();
            }
            ProductDto productDto = _productAppService.Update(product);
            return Ok(productDto);
        }

        [HttpPost]
        [Route("[action]")]

        public ActionResult DeleteProduct(int id)
        {
            ProductDto product = _productAppService.Get(id);

            if (product == null) return BadRequest();

            _productAppService.Delete(id);
            return Ok();
        }





        [HttpGet]
        
        public async Task<List<ProductDto>> GetListAsync()
        {
            var productList = await _context.Products.ToListAsync();
            var mappedData = _mapper.Map<List<Product>,         
            List<ProductDto>>(productList);

            return mappedData;
        }

    }

}
