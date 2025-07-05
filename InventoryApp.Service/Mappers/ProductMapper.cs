using InventoryApp.DataAccess.Models;
using InventoryApp.Service.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace InventoryApp.Service.Mappers
{
    public static class ProductMapper
    {
        // Map Product Entity to ProductDto
        public static ProductDto ToProductDto(Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity
            };
        }

        // Map IEnumerable<Product> to List<ProductDto>
        public static List<ProductDto> ToProductDtoList(IEnumerable<Product> products)
        {
            return products.Select(ToProductDto).ToList();
        }

        // Map CreateUpdateProductDto to Product Entity
        public static Product ToProductEntity(CreateUpdateProductDto createUpdateProductDto)
        {
            return new Product
            {
                Name = createUpdateProductDto.Name,
                Description = createUpdateProductDto.Description,
                Price = createUpdateProductDto.Price,
                Quantity = createUpdateProductDto.Quantity
            };
        }
    }
}