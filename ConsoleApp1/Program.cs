namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args) {

            #region Davaleba N1
            
            string userName = "admin";
            string password = "1234";

            Console.Write("enter username:");
            string userNameInp = Console.ReadLine();
            Console.Write("enter password:");
            string userPassInp = Console.ReadLine();

            if (userName == userNameInp && password == userPassInp) {
                Console.WriteLine("Welcome!");
            } else {
                Console.WriteLine("Access denied");
            }

            #endregion

            #region Davaleba N2
            int number1;
            int number2;
            Console.Write("შეიყვანე პირველი რიცხვი:");
            bool number1IsGood = int.TryParse(Console.ReadLine(), out number1);
            Console.Write("შეიყვანე ოპერატორი:");
            string operation = Console.ReadLine();
            Console.Write("შეიყვანე მეორე რიცხვი:");
            bool number2IsGood = int.TryParse(Console.ReadLine(), out number2);

            switch (operation)
            {
                case "+":
                    Console.WriteLine(number1 + number2);
                    break;
                case "-":
                    Console.WriteLine(number1 - number2);
                    break;
                case "/":
                    Console.WriteLine(number1 / number2);
                    break;
                case "*":
                    Console.WriteLine(number1 * number2);
                    break;
            }

            #endregion

            #region Davaleba N3

            byte age;
            Console.Write("შეიყვანე ასაკი:");
            bool correctAge = byte.TryParse(Console.ReadLine(), out age);

            switch(age)
            {
                case >= 0 and <= 12:
                    Console.WriteLine("ბავშვი");
                    break;
                case >= 13 and <= 19:
                    Console.WriteLine("თინეიჯერი");
                    break;
                case >= 20 and <= 64:
                    Console.WriteLine("ზრდასრული");
                    break;
                case >= 65:
                    Console.WriteLine("პენსიონერი");
                    break;
            }

            #endregion
        }
    }
}
