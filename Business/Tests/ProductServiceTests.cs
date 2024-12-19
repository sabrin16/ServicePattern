using Business.Models;
using Business.Services;
using Moq;
using Xunit;

namespace Business.Tests
{
    public class ProductServiceTests
    {
        private readonly ProductService _productService;
        private readonly Mock<ProductFactory> _mockProductFactory;

        public ProductServiceTests()
        {

            _mockProductFactory = new Mock<ProductFactory>();
            _productService = new ProductService(_mockProductFactory.Object);
        }

        [Fact]
        public void AddProduct_ShouldAddProduct_WhenValidProductDtoIsGiven()
        {
            // Arange
            var productDto = new ProductDto { Name = "Test Product", Price = 99.99m };
            var product = new Product { Name = productDto.Name, Price = productDto.Price };
            _mockProductFactory.Setup(p => p.Create(It.IsAny<ProductDto>())).Returns(product);

            // Act
            _productService.AddProduct(productDto);

            // Assert
            var addedProduct = _productService.GetProductById(1); // Id should be 1 since it's the first product
            Assert.Equal(productDto.Name, addedProduct.Name);
            Assert.Equal(productDto.Price, addedProduct.Price);
        }

        [Fact]
        public void GetProductById_ShouldReturnProduct_WhenProductExists()
        {
            // Arrange
            var productDto = new ProductDto { Name = "Test Product", Price = 99.99m };
            _productService.AddProduct(productDto);

            // Act
            var product = _productService.GetProductById(1);

            // Assert
            Assert.NotNull(product);
            Assert.Equal(1, product.Id);
            Assert.Equal("Test Product", product.Name);
        }

        [Fact]
        public void GetProductById_ShouldThrowException_WhenProductDoesNotExist()
        {
            // Act & Assert
            var exception = Assert.Throws<KeyNotFoundException>(() => _productService.GetProductById(999));
            Assert.Equal("Product with ID 999 not found.", exception.Message);
        }

        [Fact]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            // Arrange
            var productDto1 = new ProductDto { Name = "Product 1", Price = 99.99m };
            var productDto2 = new ProductDto { Name = "Product 2", Price = 49.99m };
            _productService.AddProduct(productDto1);
            _productService.AddProduct(productDto2);

            // Act
            var products = _productService.GetAllProducts();

            // Assert
            Assert.Equal(2, products.Count);
        }

    }
}
