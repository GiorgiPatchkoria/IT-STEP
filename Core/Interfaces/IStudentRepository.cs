using Core.Models;

namespace Core.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        bool Add(Student student);
        bool UpdateGpa(int id, decimal gpa);
    }
}
