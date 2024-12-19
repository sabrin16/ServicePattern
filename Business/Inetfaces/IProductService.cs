using Business.Models;
using System.Collections.Generic;

namespace Business.Inetfaces
{
    public interface IProductService
    {
        void AddProduct(ProductDto productDto);
        Product GetProductById(int id);
        List<Product> GetAllProducts();
    }
}
