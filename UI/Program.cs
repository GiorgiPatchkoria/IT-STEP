using Core.Interfaces;
using Core.Models;
using Infrasturcture.Repositories;
using Services.Services;

namespace UI
{
    internal class Program
    {
        private static readonly string _connectionString = "Server=localhost;Database=UNIVERSITY;Trusted_Connection=True; TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            IInstructorRepository instructorRepository = new InstructorRepository(_connectionString);
            var instructorService = new InstructorService(instructorRepository);

            instructorService.GetAllInstructors();
            instructorService.GetInstructorById(1);
            instructorService.AddInstructor(new Instructor { FirstName = "გიორგი", LastName = "პაჭკორია", Email = "gio.pachkoria@test.ge" });
            instructorService.UpdateInstructorEmail(1, "newemail@test.ge");
            instructorService.DeleteInstructor(8);
        }
    }
}
