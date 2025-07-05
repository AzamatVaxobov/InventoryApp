using InventoryApp.Repository.Interfaces;
using InventoryApp.Service.DTOs;
using InventoryApp.Service.Interfaces;
using InventoryApp.Service.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryApp.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Get all products (use IEnumerable to List mapper)
        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return ProductMapper.ToProductDtoList(products);
        }

        // Get a single product by ID
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null) return null;

            return ProductMapper.ToProductDto(product);
        }

        // Add a new product
        public async Task AddProductAsync(CreateUpdateProductDto createUpdateProductDto)
        {
            if (createUpdateProductDto.Price < 0 || createUpdateProductDto.Quantity < 0)
                throw new System.ArgumentException("Price and Quantity must be non-negative.");

            var productEntity = ProductMapper.ToProductEntity(createUpdateProductDto);
            await _productRepository.AddProductAsync(productEntity);
        }

        // Update an existing product
        public async Task UpdateProductAsync(int id, CreateUpdateProductDto createUpdateProductDto)
        {
            if (createUpdateProductDto.Price < 0 || createUpdateProductDto.Quantity < 0)
                throw new System.ArgumentException("Price and Quantity must be non-negative.");

            var productEntity = ProductMapper.ToProductEntity(createUpdateProductDto);
            productEntity.ProductId = id;

            await _productRepository.UpdateProductAsync(productEntity);
        }

        // Delete a product by ID
        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}