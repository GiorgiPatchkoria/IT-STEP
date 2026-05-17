namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args) {

            #region Davaleba N1

            Console.WriteLine("შეიყვანეთ რიცხვი:");
            int number1;
            bool numberIsGood1 = int.TryParse(Console.ReadLine(), out number1);
            int result1;

            if (numberIsGood1) {
                for (int i = 1; i <= 10; i++) {
                    result1 = number1 * i;
                    Console.WriteLine($"{number1} * {i} = {result1}");
                }
            } else {
                Console.WriteLine("Incorrect Number");
            }

            #endregion

            #region Davaleba N2

            for (int i = 1; i <= 4; i++)  {
                for (int j = 1; j <= 4-i; j++) {
                    Console.Write(" ");
                } 
                for (int h = 1; h <= i; h++) {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

            #endregion

            #region Davaleba N3

            Console.WriteLine("შეიყვანეთ რიცხვი:");
            int number3;
            bool numberIsGood3 = int.TryParse(Console.ReadLine(), out number3);
            int result3 = 0;

            if (numberIsGood3) {
                for (int i = 1; i < number3; i++)  {
                    if (i % 2 == 0) {
                        result3 += i;
                    }
                }
                Console.WriteLine($"ჯამი არის {result3}");
            } else {
                Console.WriteLine("Incorrect Number");
            }

            #endregion

            #region Davaleba N4

            Random random = new Random();
            int randomNumber = random.Next(0, 10);
            int number4;

            do {
                Console.WriteLine("შეიყვანეთ რიცხვი:");
                bool numberIsGood4 = int.TryParse(Console.ReadLine(), out number4);
            } while (number4 != randomNumber);

            #endregion
        }
    }
}
