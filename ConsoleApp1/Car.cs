namespace ConsoleApp1
{
    internal class Car
    {
        private string _brand;
        private string _model;
        private int _year;
        private double _price;
        private string _color;

        public string Brand
        {
            get => _brand;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name can not be empty");
                }
                _brand = value;
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Model can not be empty");
                }
                _model = value;
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                int currentYear = DateTime.Now.Year;
                if (value < 1900 || value > currentYear)
                {
                    Console.WriteLine("Year should be correct");
                };
                _year = value;
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price should be positive");
                }
                _price = value;
            }
        }

        public string Color
        {
            get => _color;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Color can not be empty");
                }
                _color = value;
            }
        }

        public string GetName()
        {
            return Brand + " " + Model;
        }

        public int GetAge()
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - Year;
        }

        public double GetDiscountedPrice(double discountPercent)
        {
            if (discountPercent < 0 || discountPercent > 100)
            {
                Console.WriteLine("Discount should be from 0% to 100%");
            }
            return Price - (Price * discountPercent / 100);
        }

        public string FilterByPrice()
        {
            switch (Price)
            {
                case <=30000:
                    return "Budget";
                    break;
                case <=40000:
                    return "Average Class";
                    break;
                case <=60000:
                    return "Premium";
                    break;
                case >60000:
                    return "Very High Class";
                    break;
                default:
                    return "Unknown";

            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"{Brand} {Model} was made in {Year} and its {Color}. Price is {Price}$");
        } 

        
    }
}
