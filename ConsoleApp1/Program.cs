namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Davaleba N1

            int[][] points = [[8, 7, 8], [8, 9, 6, 8], [10, 9, 9, 8, 10]];

            for (int i = 0; i < points.Length; i++)
            {
                double sum = 0;
                double avg = 0;
                for (int j = 0; j < points[i].Length; j++)
                {
                    sum += points[i][j];
                }
                avg = sum / points[i].Length;
                Console.WriteLine($"Average Point of Student {i + 1} is {avg}");

            }

            #endregion

            #region Davaleba N2

            Random random = new Random();
            string[] passcodes = new string[10];

            for (int i = 0; i < passcodes.Length; i++)
            {
                string code = "";
                for (int j = 0; j < 4; j++)
                {
                    code += random.Next(0, 10).ToString();
                }
                passcodes[i] = code;
            }

            Console.Write("Enter passcode: ");
            string passcode = Console.ReadLine();

            bool found = false;
            for (int i = 0; i < passcodes.Length; i++)
            {
                if (passcodes[i] == passcode)
                {
                    found = true;
                    break;
                }
            }

            Console.WriteLine(found ? "Correct" : "Wrong");

            #endregion

            #region Davaleba N3

            int[] numbers = { 24, -4, 43, -81, 12, 21, 23, -1, 8, 0 };

            int min = 0;
            int max = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                else if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            Console.WriteLine($"Minimum is {min}");
            Console.WriteLine($"Maximum is {max}");

            #endregion

            #region Davaleba N4

            string[] words = { "Irakli", "Lana", "Giorgi", "Nino" };

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    Console.WriteLine(words[i][j]);
                }
            }

            #endregion

            #region Davaleba N5

            string[] emails = {"giorgi.patchkoriagmail.com", "giorgi@gmail.com", "giorgi.gmail.com", "giorgi@ragac.edu.ge"};
            for (int i = 0; i < emails.Length; i++)
            {
                bool goodEmail = false;
                string email = emails[i];
                for (int j = 0; j < emails[i].Length; j++)
                {
                    if (emails[i][j] == '@')
                    {
                        goodEmail = true;
                    }

                }
                if (!goodEmail)
                {
                    Console.WriteLine(email);
                }
            }

            #endregion
        }
    }
}
