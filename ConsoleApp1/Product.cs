using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleApp1
{
    public class Product
    {
        public Product(string id, string name, string description, double price, int quantity, string brand, string category, bool isAvailable, double discountPercent)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.Brand = brand;
            this.Category = category;
            this.IsAvailable = isAvailable;
            this.DiscountPercent = discountPercent;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public bool IsAvailable { get; set; }
        public double DiscountPercent { get; set; }

        public double GetFinalPrice()
        {
            return Price - (Price * DiscountPercent / 100);
        }

        public void AddQuantity(int amount)
        {
            Quantity += amount;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Product Name: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Discount: {DiscountPercent}%");
            Console.WriteLine($"FinalPrice: {GetFinalPrice()}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"IsAvailabe: {(IsAvailable ? "Yes" : "No")}");
        }

    }
}
