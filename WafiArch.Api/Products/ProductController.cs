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
        public ActionResult<Product> CreateProduct(Product product)
        {
            var alpha = _productAppService.CreateProduct(product);

            return Ok(alpha);
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
