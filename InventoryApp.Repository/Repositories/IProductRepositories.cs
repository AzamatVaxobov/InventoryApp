using InventoryApp.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryApp.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync(); // Get all products
        Task<Product> GetProductByIdAsync(int id);        // Get a product by ID
        Task AddProductAsync(Product product);            // Add a new product
        Task UpdateProductAsync(Product product);         // Update an existing product
        Task DeleteProductAsync(int id);                  // Delete a product
    }
}