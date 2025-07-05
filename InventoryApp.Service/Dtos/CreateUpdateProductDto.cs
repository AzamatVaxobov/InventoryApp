namespace InventoryApp.Service.DTOs
{
    public class CreateUpdateProductDto
    {
        public string Name { get; set; }       // Name of the product
        public string Description { get; set; } // Description of the product
        public decimal Price { get; set; }     // Price of the product
        public int Quantity { get; set; }      // Quantity in stock
    }
}