namespace Core.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"Instructor: Id={Id}, FirstName={FirstName}, LastName={LastName}, Email={Email}";
        }
    }
}
