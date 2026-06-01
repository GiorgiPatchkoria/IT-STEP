namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../CarsData.txt";
            Car[] cars = FillCars(path);

            PrintAllCars(cars);

            Car mostExpensive = MostExpensiveCar(cars);
            Console.WriteLine("Most expensive car:");
            mostExpensive.DisplayInfo();

            double averagePrice = AveragePrice(cars);
            Console.WriteLine($"Average Price of Cars is: {averagePrice}$");
        }

        public static Car[] FillCars(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Car[] cars = new Car[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                cars[i] = new Car
                {
                    Brand = parts[0],
                    Model = parts[1],
                    Year = int.Parse(parts[2]),
                    Price = double.Parse(parts[3]),
                    Color = parts[4]
                };
            }
            return cars;
        }

        public static void PrintAllCars(Car[] cars)
        {
            foreach (Car car in cars)
            {
                double discountPrice = car.GetDiscountedPrice(15);
                Console.WriteLine($"{car.GetName()} is {car.GetAge()} years old {car.FilterByPrice()} car and after discount its price is {discountPrice}$");
            }
        }

        public static Car MostExpensiveCar(Car[] cars)
        {
            Car mostExpensive = cars[0];
            foreach (Car car in cars)
            {
                if (car.Price > mostExpensive.Price)
                {
                    mostExpensive = car;
                }
            }
            return mostExpensive;
        }

        public static double AveragePrice(Car[] cars)
        {
            double total = 0;
            foreach (Car car in cars)
            {
                total += car.Price;
            }
            return total / cars.Length;
        }
    }
}