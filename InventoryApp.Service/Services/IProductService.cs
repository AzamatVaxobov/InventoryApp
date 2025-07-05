using InventoryApp.Service.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryApp.Service.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProductsAsync();         // Get all products
        Task<ProductDto> GetProductByIdAsync(int id);         // Get a single product by ID
        Task AddProductAsync(CreateUpdateProductDto productDto); // Add a new product
        Task UpdateProductAsync(int id, CreateUpdateProductDto productDto); // Update an existing product
        Task DeleteProductAsync(int id);                     // Delete a product by ID
    }
}