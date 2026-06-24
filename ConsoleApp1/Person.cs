namespace ConsoleApp1
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        protected Person(string name, string lastName, int age, string email, string phone)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Email = email;
            Phone = phone;
        }

        public abstract void Print();
    }
}
