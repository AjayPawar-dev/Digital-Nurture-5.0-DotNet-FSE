using SearchFunctionExample;

class Program
{
    static void Main()
    {
        // 1. Initialize sample data
        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Smartphone", "Electronics"),
            new Product(103, "Tablet", "Electronics"),
            new Product(104, "Headphones", "Accessories"),
            new Product(105, "Mouse", "Accessories")
        };

        string target = "Tablet";

        // 2. Perform Linear Search
        Console.WriteLine("Linear Search :");
        Product res1 = LinearSearch(products, target);
        Console.WriteLine(res1 != null ? $"Found Product: {res1.ProductName} in {res1.Category}" : "Product Not Found");

        // 3. Perform Binary Search (Requires sorting by ProductName)
        Console.WriteLine("\nBinary Search: ");
        var sortedProducts = products.OrderBy(p => p.ProductName).ToArray();
        Product res2 = BinarySearch(sortedProducts, target);
        Console.WriteLine(res2 != null ? $"Found Product: {res2.ProductName} in {res2.Category}" : "Product Not Found");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    // Linear Search: Compares target with every element one by one [3].
    public static Product LinearSearch(Product[] list, string name)
    {
        foreach (var p in list)
        {
            if (p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase)) return p;
        }
        return null;
    }

    // Binary Search: Halves the search range repeatedly in a sorted array [3].
    public static Product BinarySearch(Product[] list, string name)
    {
        int low = 0, high = list.Length - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int compare = string.Compare(list[mid].ProductName, name, StringComparison.OrdinalIgnoreCase);

            if (compare == 0) return list[mid];
            if (compare < 0) low = mid + 1;
            else high = mid - 1;
        }
        return null;
    }
}
