namespace ConsoleApp1
{
    class Program
    {
        static List<string> students = new List<string>();
        static Dictionary<string, int> grades = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nამოირჩიეთ ოპერაცია:");
                Console.WriteLine("1. სტუდენტის დამატება");
                Console.WriteLine("2. სტუდენტის ძებნა");
                Console.WriteLine("3. ქულის განახლება");
                Console.WriteLine("4. ყველა სტუდენტის ჩვენება");
                Console.WriteLine("0. დასრულება");
                Console.Write("აირჩიეთ ოპერაცია: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        FindStudent();
                        break;
                    case "3":
                        UpdateGrade();
                        break;
                    case "4":
                        ShowAllStudents();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("არასწორი მნიშვნელობა. აირჩიეთ სწორი ოპერაცია");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("შეიყვანეთ სტუდენტის სახელი: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("შეიყვანეთ სწორი სახელი");
                return;
            } else if (students.Contains(name))
            {
                Console.WriteLine("სტუდენტი უკვე დამატებულია");
                return;
            }

            Console.Write("შეიყვანეთ ქულა: ");
            if (!int.TryParse(Console.ReadLine(), out int grade))
            {
                Console.WriteLine("შეიყვანეთ სწორი ქულა");
                return;
            }

            students.Add(name);
            grades.Add(name, grade);
            Console.WriteLine($"{name} დამატებულია სტუდენტების სიაში");
        }

        static void FindStudent()
        {
            Console.Write("შეიყვანეთ სტუდენტის სახელი: ");
            string name = Console.ReadLine();

            if (grades.ContainsKey(name))
            {
                Console.WriteLine($"სტუდენტი: {name}, ქულა: {grades[name]}");
            }
            else
            {
                Console.WriteLine("სტუდენტი ვერ მოიძებნა");
            }
        }

        static void UpdateGrade()
        {
            Console.Write("შეიყვანეთ სტუდენტის სახელი: ");
            string name = Console.ReadLine();

            if (!grades.ContainsKey(name))
            {
                Console.WriteLine("სტუდენტი ვერ მოიძებნა");
                return;
            }

            Console.Write("შეიყვანეთ ახალი ქულა: ");
            if (!int.TryParse(Console.ReadLine(), out int newGrade))
            {
                Console.WriteLine("შეიყვანეთ სწორი ქულა");
                return;
            }

            grades[name] = newGrade;
            Console.WriteLine($"{name}-ის ქულა განახლდა: {newGrade}");
        }

        static void ShowAllStudents()
        {
            foreach (string name in students)
            {
                Console.WriteLine($"სახელი: {name}, ქულა: {grades[name]}");
            }
        }
    }
}