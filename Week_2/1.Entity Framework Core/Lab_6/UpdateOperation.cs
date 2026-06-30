using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

// Step 1: Create database context
using var context = new AppDbContext();

// Step 2: Retrieve product before update

Console.WriteLine("\nProduct Details Before Update:\n");

var productBeforeUpdate = await context.Products
	.FirstOrDefaultAsync(p => p.Name == "Laptop");

if (productBeforeUpdate != null)
{
	Console.WriteLine($"ID    : {productBeforeUpdate.Id}");
	Console.WriteLine($"Name  : {productBeforeUpdate.Name}");
	Console.WriteLine($"Price : ₹{productBeforeUpdate.Price}");
}
else
{
	Console.WriteLine("Laptop product not found.");
}

// Step 3: Update Product Price

var product = await context.Products
	.FirstOrDefaultAsync(p => p.Name == "Laptop");

if (product != null)
{
	product.Price = 70000; //set price

	await context.SaveChangesAsync();//save changes to database

	Console.WriteLine("\nProduct updated successfully.");
}
else
{
	Console.WriteLine("\nProduct not found for update.");
}

// Step 4: Retrieve product after update

Console.WriteLine("\nProduct Details After Update:\n");

var productAfterUpdate = await context.Products
	.FirstOrDefaultAsync(p => p.Name == "Laptop");

if (productAfterUpdate != null)
{
	Console.WriteLine($"ID    : {productAfterUpdate.Id}");
	Console.WriteLine($"Name  : {productAfterUpdate.Name}");
	Console.WriteLine($"Price : ₹{productAfterUpdate.Price}");
}
else
{
	Console.WriteLine("Laptop product not found.");
}
