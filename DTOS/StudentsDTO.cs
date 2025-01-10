using studentcrud.Models;

namespace studentcrud.DTOS
{
    public class StudentsDTO
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateOnly? DateOfBirth { get; set; }

        public virtual ICollection<CoursesDTO> Courses { get; set; } = new List<CoursesDTO>();
    }
}
