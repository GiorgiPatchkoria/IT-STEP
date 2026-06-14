namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {6, 2, 1, 8, 3, 8, 2, 9, 9, 9, 7};

            Array arr = new Array(numbers);

            #region Davaleba N1
            arr.ShowEven();
            Console.WriteLine();
            arr.ShowOdd();
            Console.WriteLine();
            #endregion


            #region Davaleba N3
            Console.WriteLine($"უნიკალური მნიშვნელობები არის {arr.CountDistinct()}");
            Console.WriteLine($"მასივში 0 არის {arr.EqualToValue(0)}-ჯერ");
            Console.WriteLine($"მასივში 2 არის {arr.EqualToValue(2)}-ჯერ");
            Console.WriteLine($"მასივში 9 არის {arr.EqualToValue(9)}-ჯერ");
            #endregion
        }

    }
}