using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArch.Domain.Product;

namespace WafiArch.Application.Products
{
    public interface IProductAppService
    {
        Product CreateProduct(Product product);
    }
}
