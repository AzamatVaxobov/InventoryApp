using InventoryApp.Service.DTOs;
using InventoryApp.Service.Interfaces;
using InventoryApp.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace InventoryApp.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockProductService; // Mock for the service
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            // Arrange: Create mock and controller instance
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductController(_mockProductService.Object);
        }

        // Test: GetAllProducts (200 OK)
        [Fact]
        public async Task GetAllProducts_ReturnsOk_WithProductList()
        {
            // Arrange
            var mockProducts = new List<ProductDto>
            {
                new ProductDto { ProductId = 1, Name = "Product A", Description = "Desc A", Price = 100, Quantity = 10 },
                new ProductDto { ProductId = 2, Name = "Product B", Description = "Desc B", Price = 200, Quantity = 5 }
            };
            _mockProductService.Setup(service => service.GetAllProductsAsync()).ReturnsAsync(mockProducts);

            // Act
            var result = await _controller.GetAllProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result); // Response should be 200 OK
            var returnedProducts = Assert.IsType<List<ProductDto>>(okResult.Value); // Check returned data
            Assert.Equal(2, returnedProducts.Count); // Ensure 2 products were returned
        }

        // Test: GetProductById (200 OK)
        [Fact]
        public async Task GetProductById_ReturnsOk_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var mockProduct = new ProductDto { ProductId = productId, Name = "Product A", Price = 100, Quantity = 10 };
            _mockProductService.Setup(service => service.GetProductByIdAsync(productId)).ReturnsAsync(mockProduct);

            // Act
            var result = await _controller.GetProductById(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result); // Check if response is 200 OK
            var returnedProduct = Assert.IsType<ProductDto>(okResult.Value); // Check returned product
            Assert.Equal("Product A", returnedProduct.Name); // Verify product details
        }

        // Test: GetProductById (404 Not Found)
        [Fact]
        public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            var productId = 1;
            _mockProductService.Setup(service => service.GetProductByIdAsync(productId)).ReturnsAsync((ProductDto)null);

            // Act
            var result = await _controller.GetProductById(productId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result); // Ensure response is 404 Not Found
        }

        // Test: AddProduct (201 Created)
        [Fact]
        public async Task AddProduct_ReturnsCreated_WhenProductIsAdded()
        {
            // Arrange
            var newProduct = new CreateUpdateProductDto { Name = "Product A", Description = "Desc", Price = 100, Quantity = 10 };

            // Act
            var result = await _controller.AddProduct(newProduct);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result); // Ensure response is 201 Created
            Assert.Equal(nameof(_controller.GetProductById), createdResult.ActionName); // Action for CreatedAt is correct
        }

        // Test: UpdateProduct (404 Not Found for Invalid ID)
        [Fact]
        public async Task UpdateProduct_ReturnsNotFound_WhenProductIdIsInvalid()
        {
            // Arrange
            var productId = 1;
            var updatedProduct = new CreateUpdateProductDto { Name = "Updated Product", Description = "Updated Desc", Price = 120, Quantity = 5 };
            _mockProductService.Setup(service => service.GetProductByIdAsync(productId)).ReturnsAsync((ProductDto)null);

            // Act
            var result = await _controller.UpdateProduct(productId, updatedProduct);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result); // Ensure response is 404 Not Found
        }

        // Test: DeleteProduct (204 No Content)
        [Fact]
        public async Task DeleteProduct_ReturnsNoContent_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            _mockProductService.Setup(service => service.GetProductByIdAsync(productId)).ReturnsAsync(new ProductDto());

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            Assert.IsType<NoContentResult>(result); // Ensure response is 204 No Content
        }

        // Test: DeleteProduct (404 Not Found)
        [Fact]
        public async Task DeleteProduct_ReturnsNotFound_WhenProductIdIsInvalid()
        {
            // Arrange
            var productId = 1;
            _mockProductService.Setup(service => service.GetProductByIdAsync(productId)).ReturnsAsync((ProductDto)null);

            // Act
            var result = await _controller.DeleteProduct(productId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result); // Ensure response is 404 Not Found
        }
    }
}