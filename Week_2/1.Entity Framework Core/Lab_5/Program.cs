using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

// Step 1: Create an instance of AppDbContext
using var context = new AppDbContext();

// Step 2: Retrieve all products using ToListAsync()

Console.WriteLine("\nAll Products:\n");

var products = await context.Products
    .Include(p => p.Category)
    .ToListAsync();

foreach (var product in products)
{
    Console.WriteLine(
        $"ID: {product.Id}, " +
        $"Name: {product.Name}, " +
        $"Price: ₹{product.Price}, " +
        $"Category: {product.Category?.Name}");
}

// Step 3: Retrieve a product by its ID using FindAsync()

Console.WriteLine("\nProduct Retrieved Using FindAsync()");

// to get the product with productid=5
int productId = 5;

var productById = await context.Products.FindAsync(productId);

if (productById != null)
{
    Console.WriteLine($"Product ID : {productById.Id}");
    Console.WriteLine($"Name       : {productById.Name}");
    Console.WriteLine($"Price      : ₹{productById.Price}");
}
else
{
    Console.WriteLine($"No product found with ID {productId}");
}

// Step 4: Retrieve first expensive product using FirstOrDefaultAsync()

Console.WriteLine("\nFirst Product Above ₹50,000");

var expensiveProduct = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);

if (expensiveProduct != null)
{
    Console.WriteLine($"Product ID : {expensiveProduct.Id}");
    Console.WriteLine($"Name       : {expensiveProduct.Name}");
    Console.WriteLine($"Price      : ₹{expensiveProduct.Price}");
}
else
{
    Console.WriteLine("No product found above ₹50,000");
}

Console.WriteLine("Data Retrieval Completed Successfully");
