using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArch.Domain.Product;
using WafiArch.EntityFrameworkCore.Data;

namespace WafiArch.Application.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly ApplicationDbContext _context;

        public ProductAppService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }
    }
}
