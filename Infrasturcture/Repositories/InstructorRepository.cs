using Core.Interfaces;
using Core.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrasturcture.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly string _connectionString;

        public InstructorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Instructor> GetAll()
        {
            var instructors = new List<Instructor>();

            var query = "SELECT * FROM INSTRUCTORS";
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader.HasRows)
                {
                    instructors.Add(MapInstructor(reader));
                }

            }

            return instructors;
        }

        public Instructor GetById(int id)
        {
            var query = "SELECT * FROM INSTRUCTORS where InstructorID = @Id";

            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return MapInstructor(reader);
            }

            return null;
        }

        public bool Add(Instructor instructor)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("dbo.sp_AddInsctructor", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FirstName", instructor.FirstName);
            command.Parameters.AddWithValue("@LastName", instructor.LastName);
            command.Parameters.AddWithValue("@Email", instructor.Email);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }

        public bool UpdateEmail(int id, string email)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand("dbo.sp_UpdateInsctructor", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@InstructorId", id);
            command.Parameters.AddWithValue("@Email", email);

            connection.Open();

            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            var query = "DELETE FROM INSTRUCTORS where InstructorID = @InstructorID";
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InstructorID", id);
            connection.Open();
            return command.ExecuteNonQuery() > 0;
        }

        private Instructor MapInstructor(SqlDataReader reader)
        {
            return new Instructor
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Email = reader.GetString(3)
            };
        }
    }
}
