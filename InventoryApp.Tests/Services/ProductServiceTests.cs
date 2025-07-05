using InventoryApp.Service.DTOs;
using InventoryApp.Service.Mappers;
using InventoryApp.Service.Services;
using InventoryApp.DataAccess.Models;
using InventoryApp.Repository.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace InventoryApp.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository; // Mock for the repository
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            // Arrange: Create mock repository and service instance
            _mockProductRepository = new Mock<IProductRepository>();
            _service = new ProductService(_mockProductRepository.Object);
        }

        // Test: GetAllProductsAsync - Returns list of ProductDto
        [Fact]
        public async Task GetAllProductsAsync_ReturnsListOfProductDto()
        {
            // Arrange
            var mockProducts = new List<Product>
            {
                new Product { ProductId = 1, Name = "Product A", Description = "Desc A", Price = 100, Quantity = 10 },
                new Product { ProductId = 2, Name = "Product B", Description = "Desc B", Price = 200, Quantity = 5 }
            };
            _mockProductRepository.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(mockProducts);

            // Act
            var result = await _service.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ProductDto>>(result);
            Assert.Equal(2, result.Count); // Two products should be returned
        }

        // Test: GetProductByIdAsync - Returns ProductDto if found
        [Fact]
        public async Task GetProductByIdAsync_ReturnsProductDto_WhenProductExists()
        {
            // Arrange
            var mockProduct = new Product
            {
                ProductId = 1,
                Name = "Product A",
                Description = "Desc A",
                Price = 100,
                Quantity = 10
            };
            _mockProductRepository.Setup(repo => repo.GetProductByIdAsync(1)).ReturnsAsync(mockProduct);

            // Act
            var result = await _service.GetProductByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProductDto>(result);
            Assert.Equal("Product A", result.Name); // Ensure product name matches
        }

        // Test: GetProductByIdAsync - Returns null if not found
        [Fact]
        public async Task GetProductByIdAsync_ReturnsNull_WhenProductDoesNotExist()
        {
            // Arrange
            _mockProductRepository.Setup(repo => repo.GetProductByIdAsync(1)).ReturnsAsync((Product)null);

            // Act
            var result = await _service.GetProductByIdAsync(1);

            // Assert
            Assert.Null(result); // Product should not exist
        }

        // Test: AddProductAsync - Adds a new product
        [Fact]
        public async Task AddProductAsync_CallsRepositoryToAddProduct()
        {
            // Arrange
            var newProductDto = new CreateUpdateProductDto
            {
                Name = "New Product",
                Description = "New Description",
                Price = 50,
                Quantity = 20
            };

            _mockProductRepository.Setup(repo => repo.AddProductAsync(It.IsAny<Product>()))
                .Returns(Task.CompletedTask)
                .Verifiable(); // Ensure method is called

            // Act
            await _service.AddProductAsync(newProductDto);

            // Assert
            _mockProductRepository.Verify(repo => repo.AddProductAsync(It.IsAny<Product>()), Times.Once);
        }

        // Test: UpdateProductAsync - Updates an existing product
        [Fact]
        public async Task UpdateProductAsync_CallsRepositoryToUpdateProduct()
        {
            // Arrange
            var productId = 1;
            var updatedProductDto = new CreateUpdateProductDto
            {
                Name = "Updated Product",
                Description = "Updated Desc",
                Price = 120,
                Quantity = 50
            };

            _mockProductRepository.Setup(repo => repo.UpdateProductAsync(It.IsAny<Product>()))
                .Returns(Task.CompletedTask)
                .Verifiable(); // Ensure method is called

            // Act
            await _service.UpdateProductAsync(productId, updatedProductDto);

            // Assert
            _mockProductRepository.Verify(repo => repo.UpdateProductAsync(It.IsAny<Product>()), Times.Once);
        }

        // Test: DeleteProductAsync - Calls repository to delete product
        [Fact]
        public async Task DeleteProductAsync_CallsRepositoryToDeleteProduct()
        {
            // Arrange
            var productId = 1;
            _mockProductRepository.Setup(repo => repo.DeleteProductAsync(productId))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Act
            await _service.DeleteProductAsync(productId);

            // Assert
            _mockProductRepository.Verify(repo => repo.DeleteProductAsync(productId), Times.Once);
        }
    }
}