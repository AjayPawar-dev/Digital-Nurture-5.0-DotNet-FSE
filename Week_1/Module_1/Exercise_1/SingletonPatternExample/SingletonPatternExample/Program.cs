using System;
using SingletonPatternExample;

class Program
{
    static void Main()
    {
        // Trying to get the logger twice
        Logger obj1 = Logger.GetInstance();
        Logger obj2 = Logger.GetInstance();

        // Testing if they are the same
        if (obj1 == obj2)
        {
            Console.WriteLine("Success: Both objects are exactly the same!");
        }

        obj1.Log("System Started.");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}