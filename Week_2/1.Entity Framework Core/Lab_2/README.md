# Lab 2: Setting Up the Database Context for a Retail Store

## 1.Scenario

I am developing a Retail Inventory Management System. To store and manage product information in a database, Entity Framework Core requires entity classes and a database context.

## 2.Understanding DbContext

DbContext is the primary class in Entity Framework Core that acts as a bridge between the application and the database.

It manages database connections, tracks changes made to entities, and allows data to be queried and saved.

In this lab, I created an AppDbContext class to manage Product and Category entities.

## 3.Product Entity

The Product entity represents products available in the retail store.

### Properties

- Id
- Name
- Price
- CategoryId

The Product class will be mapped to the Products table in the database.

## 4.Category Entity

The Category entity represents product categories.

### Properties

- Id
- Name

The Category class will be mapped to the Categories table in the database.

## 5.Relationship Between Product and Category

A category can contain multiple products.

Examples:

- Electronics consist of: Laptop, Mouse, Keyboard
- Clothing consist of: T-Shirt, Jeans
- Grocery consist of: Rice, Sugar

This is called a One-to-Many Relationship because one category can have many products.

## Database Context Configuration

The AppDbContext class was created by inheriting from DbContext.

The following DbSet properties were added:

- DbSet<Product> Products
- DbSet<Category> Categories

These properties tell Entity Framework Core to create Products and Categories tables in the database.

The SQL Server connection string was configured using the UseSqlServer() method.

## Implementation Steps

1. Created a Models folder.
2. Added Product.cs entity class.
3. Added Category.cs entity class.
4. Created a Data folder.
5. Added AppDbContext.cs.
6. Configured SQL Server connection using UseSqlServer().
7. Added DbSet properties for Product and Category.
8. Built the project successfully.

## Output

Look at the screenshot below:

![Lab 2 Output](Screenshots/Lab2_Models_and_DbContext.png)

The screenshot shows:

- Product entity model
- Category entity model
- AppDbContext configuration
- Project structure in Solution Explorer

## Result

Thus, the Product and Category entity classes were created successfully and the AppDbContext was configured using Entity Framework Core. The project is now ready for database creation and migrations in the upcoming labs.