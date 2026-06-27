using RetailInventory.Data;
using RetailInventory.Models;

using var context = new AppDbContext();

var electronics = new Category
{
    Name = "Electronics"
};

var groceries = new Category
{
    Name = "Groceries"
};

var clothing = new Category
{
    Name = "Clothing"
};

var stationery = new Category
{
    Name = "Stationery"
};

await context.Categories.AddRangeAsync(
    electronics,
    groceries,
    clothing,
    stationery);

var products = new List<Product>
{
    // Electronics
    new Product
    {
        Name = "Laptop",
        Price = 79999,
        Category = electronics
    },
    new Product
    {
        Name = "Smartphone",
        Price = 40999,
        Category = electronics
    },
    new Product
    {
        Name = "Bluetooth Speaker",
        Price = 2499,
        Category = electronics
    },

    // Groceries
    new Product
    {
        Name = "Rice Bag",
        Price = 1200,
        Category = groceries
    },
    new Product
    {
        Name = "Wheat Flour",
        Price = 438,
        Category = groceries
    },
    new Product
    {
        Name = "Olive Oil",
        Price = 543,
        Category = groceries
    },

    // Clothing
    new Product
    {
        Name = "Men's Shirt",
        Price = 799,
        Category = clothing
    },
    new Product
    {
        Name = "Women's Kurti",
        Price = 1100,
        Category = clothing
    },
    new Product
    {
        Name = "Jeans",
        Price = 1299,
        Category = clothing
    },

    // Stationery
    new Product
    {
        Name = "Notebook",
        Price = 50,
        Category = stationery
    },
    new Product
    {
        Name = "Parker Pen",
        Price = 120,
        Category = stationery
    },
    new Product
    {
        Name = "Marker Set",
        Price = 200,
        Category = stationery
    }
};

await context.Products.AddRangeAsync(products);

await context.SaveChangesAsync();

Console.WriteLine("Data inserted successfully.");