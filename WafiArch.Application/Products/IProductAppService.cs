using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArch.Application.Products.Dtos;
using WafiArch.Domain.Product;

namespace WafiArch.Application.Products
{
    public interface IProductAppService
    {
        Product CreateProduct(Product product);
        IEnumerable<Product> GetAll();
        ProductDto Get(int id);
        ProductDto Update(ProductDto product);
        void Delete(int id);

    }
}
