namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args) {

            #region DavalebaN1

            Console.WriteLine("შეიყვანეთ ასაკი:");
            string strAge = Console.ReadLine();
            int intAge = int.Parse(strAge);
            bool isAdult = intAge >= 18;
            Console.WriteLine(isAdult ? "გილოცავთ! ხმის მიცემის უფლება გაქვთ" : "სამწუხაროთ ხმის მიცემის უფლება ჯერ არ გაქვთ");

            #endregion

            #region DavalebaN2

            Console.WriteLine("შეიყვანეთ პირველი რიცხვი:");
            int number1 = int.Parse(Console.ReadLine());
            Console.WriteLine("შეიყვანეთ მე-2 რიცხვი:");
            int number2 = int.Parse(Console.ReadLine());
            Console.WriteLine("შეიყვანეთ მე-3 რიცხვი:");
            int number3 = int.Parse(Console.ReadLine());

            if (number1 >= number2 && number1 >= number3) {
                Console.WriteLine("პირველი რიცხვი მაქსიმალურია წარმოდგენილ რიცხვებს შორის");
            } else if (number2 >= number1 && number2 >= number3) {
                Console.WriteLine("მე-2 რიცხვი მაქსიმალურია წარმოდგენილ რიცხვებს შორის");
            } else {
                Console.WriteLine("მე-3 რიცხვი მაქსიმალურია წარმოდგენილ რიცხვებს შორის");
            }

            #endregion

            #region DavalebaN3

            Console.WriteLine("შეიყვანეთ პირველი რიცხვი:");
            int ricxvi1 = int.Parse(Console.ReadLine());
            Console.WriteLine("შეიყვანეთ მე-2 რიცხვი:");
            int ricxvi2 = int.Parse(Console.ReadLine());
            int jami = ricxvi1 + ricxvi2;

            if (ricxvi1 == ricxvi2) {
                jami *= 3;
            }
            Console.WriteLine($"ჯამი არის {jami}");

            #endregion
        }
    }
}
