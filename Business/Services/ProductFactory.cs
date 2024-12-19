using Business.Models;

namespace Business.Services
{
    public class ProductFactory
    {
        public Product Create(ProductDto dto)
        {
            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };
        }
    }
}
