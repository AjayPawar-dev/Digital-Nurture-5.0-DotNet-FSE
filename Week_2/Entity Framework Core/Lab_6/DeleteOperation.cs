using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;

// Step 1: Create database context
using var context = new AppDbContext();

// Step 2: Retrieve Product Before Deletion

Console.WriteLine("\nProduct Details Before Deletion:\n");

var productBeforeDelete = await context.Products //check if the product exist
    .FirstOrDefaultAsync(p => p.Name == "Laptop");

if (productBeforeDelete != null)
{
    Console.WriteLine($"ID    : {productBeforeDelete.Id}");
    Console.WriteLine($"Name  : {productBeforeDelete.Name}");
    Console.WriteLine($"Price : ₹{productBeforeDelete.Price}");
}
else
{
    Console.WriteLine("Laptop product not found.");
}

// Step 3: Delete Product

var product = await context.Products
    .FirstOrDefaultAsync(p => p.Name == "Laptop");

if (product != null)
{
    context.Products.Remove(product);

    await context.SaveChangesAsync();

    Console.WriteLine("\nProduct deleted successfully.");
}
else
{
    Console.WriteLine("\nProduct not found for deletion.");
}

// Step 4: Verify Product After Deletion

Console.WriteLine("\nVerifying Deletion...\n");

var deletedProduct = await context.Products
    .FirstOrDefaultAsync(p => p.Name == "Laptop");

if (deletedProduct == null)
{
    Console.WriteLine("Verification Successful.");
    Console.WriteLine("Laptop product no longer exists in the database.");
}
else
{
    Console.WriteLine("Deletion verification failed.");
}

Console.WriteLine("Delete Operation Completed Successfully");
