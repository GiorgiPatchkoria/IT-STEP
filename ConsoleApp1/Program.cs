namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>() {
                new Student("Giorgi", 3.1),
                new Student("Nika", 2.9),
                new Student("Mariam", 2.0),
                new Student("Saba", 3.8)
            };

            
            var studentsWithHighScores = Helper.Where(students, s => s.GPA >= 3);
            Console.WriteLine($"Students with high GPAs: ");
            foreach (var student in studentsWithHighScores)
            {
                Console.WriteLine(student.Name);
            }

            var sorted = Helper.OrderBy(students, (a, b) => a.GPA > b.GPA);
            Console.WriteLine($"Students sorted by GPA: ");
            foreach (var student in sorted)
            {
                Console.WriteLine($"{student.Name} - {student.GPA}");
            }

            var first = Helper.First(students, s => s.GPA > 3);
            Console.WriteLine($"First student with GPA > 3 is {first.Name}");

            var firstDefault = Helper.FirstOrDefault(students, s => s.GPA > 3.5);
            Console.WriteLine($"First student with GPA > 3.5 is {firstDefault.Name}");

            var single = Helper.Single(students, s => s.Name == "Saba");
            Console.WriteLine($"There is Student named {single.Name} and his/her GPA is {single.GPA}");

            var singleOrDefault = Helper.SingleOrDefault(students, s => s.Name == "Nika");
            Console.WriteLine($"There is Student named {singleOrDefault.Name} and his/her GPA is {singleOrDefault.GPA}");
            
            bool any = Helper.Any(students, s => s.GPA == 2);
            Console.WriteLine(any);

            bool all = Helper.All(students, s => s.GPA >= 2);
            Console.WriteLine(all);

            int count = Helper.Count(students, s => s.GPA >= 3);
            Console.WriteLine(count);

            List<int> numbers = new List<int>() { 1, 2, 2, 3, 3, 4 };
            var unique = Helper.Distinct(numbers);
            foreach (var number in unique)
            {
                Console.WriteLine(number);
            }
        }
    }
}