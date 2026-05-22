namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args) {

            #region Davaleba N1
            int[] array1 = [1,2,3];
            int[] array2 = [4,5,6];

            int[] resultArray = new int[array1.Length + array2.Length];

            for (int i = 0; i< array1.Length; i++)
            {
                resultArray[i] = array1[i];
            }

            for (int i = 0;i< array2.Length; i++)
            {
                resultArray[array1.Length + i] = array2[i];
            }

            foreach (int i in resultArray)
            {
                Console.WriteLine(i);
            }
            #endregion
        }
    }
}
