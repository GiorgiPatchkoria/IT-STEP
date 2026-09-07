namespace Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public decimal? GPA { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegisteredAt { get; set; }
        public int? DepartmentId { get; set; }

        public override string ToString()
        {
            return $"Student: Id={Id}, FirstName={FirstName}, LastName={LastName}, Email={Email}, Age={Age}, GPA={GPA}, PhoneNumber={PhoneNumber}, IsActive={IsActive}, RegisteredAt={RegisteredAt}, DepartmentId={DepartmentId}";
        }
    }
}
