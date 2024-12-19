
using System;
using System.Collections.Generic;
using System.Linq;
using Business.Inetfaces;
using Business.Models;


namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;
        private readonly ProductFactory _productFactory;
        private int _nextId = 1;

        public ProductService()
        {
            _products = new List<Product>();
            _productFactory = new ProductFactory();
        }

        public void AddProduct(ProductDto productDto)
        {
            var product = _productFactory.Create(productDto);
            product.Id = _nextId++;
            _products.Add(product);
        }

        public Product GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            return product;
        }

         public List<Product> GetAllProducts()
        { 
             return new List<Product>(_products);
        }
    }
}
