namespace ConsoleApp1
{
    public class Student : Person, IPrintable
    {
        public double GPA { get; set; }
        public Faculty Faculty { get; set; }

        public Student(string name, string lastName, int age, string email, string phone, double gpa, Faculty faculty)
            : base(name, lastName, age, email, phone)
        {
            GPA = gpa;
            Faculty = faculty;
        }

        public override void Print()
        {
            Console.WriteLine($"{Name} {LastName} | {Age} | {Faculty} | {GPA}");
        }

        public static bool operator >(Student s1, Student s2)
        {
            return s1.GPA > s2.GPA;
        }

        public static bool operator <(Student s1, Student s2)
        {
            return s1.GPA < s2.GPA;
        }
    }
}
