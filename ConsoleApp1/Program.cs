namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("23523", "Iphone 17 Pro", "Apple iPhone 17 Pro Max 256GB Deep Blue", 4559.99, 100, "Apple", "Phone", true, 10);

            product1.DisplayInfo();
            Console.WriteLine();

            double finalPrice = product1.GetFinalPrice();
            Console.WriteLine($"Final Price Is {finalPrice}");
            Console.WriteLine();

            Product product2 = new Product("23451", "Lenovo Legion Pro 5", "Lenovo Legion Pro 5 Oled 83LU003FRK, Intel Core Ultra 9 275HX - 24c, Nvidia GeForce RTX 5070 Ti 12GB, 32GB RAM SSD 1TB",
                7999, 23, "Lenovo", "Laptop", true, 5);

            product2.DisplayInfo();
            Console.WriteLine();

            Console.WriteLine($"There is {product2.Quantity} items in Stock");
            product2.AddQuantity(5);
            Console.WriteLine($"There is {product2.Quantity} items in Stock");
        }
    }
}
