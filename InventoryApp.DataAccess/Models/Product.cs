using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.DataAccess.Models;

public class Product
{
    public int ProductId { get; set; }      // Primary Key
    public string Name { get; set; }       // Product Name
    public string Description { get; set; } // Product Description
    public decimal Price { get; set; }     // Product Price
    public int Quantity { get; set; }      // Product Quantity
}
