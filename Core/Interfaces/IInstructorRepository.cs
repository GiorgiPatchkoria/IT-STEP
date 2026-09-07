using Core.Models;

namespace Core.Interfaces
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> GetAll();
        Instructor GetById(int id);
        bool Add(Instructor instructor);
        bool UpdateEmail(int id, string email);
        bool Delete(int id);
    }
}
