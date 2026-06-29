namespace ConsoleApp1
{
    internal class Student
    {
        public string Name { get; set; }
        public double GPA { get; set; }

        public Student(string name, double gpa)
        {
            Name = name;
            GPA = gpa;
        }
    }
}
