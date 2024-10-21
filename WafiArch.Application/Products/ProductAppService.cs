using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArch.Application.Products.Dtos;
using WafiArch.Domain.Product;
using WafiArch.EntityFrameworkCore.Data;

namespace WafiArch.Application.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductAppService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            Product product = _context.Products.FirstOrDefault(u=>u.Id==id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public ProductDto Get(int id)
        {
            Product product = _context.Products.FirstOrDefault(u => u.Id == id);
            ProductDto productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products = _context.Products.ToList();
            return products;
        }

        public ProductDto Update(ProductDto productDto)
        {
            Product? product = _context.Products.FirstOrDefault(u => u.Id == productDto.Id);

            product.Name = productDto.Name;
            product.Price = productDto.Price;

            _context.Update(product);
            _context.SaveChanges();
            return _mapper.Map<ProductDto>(productDto);
        }
    }
}
