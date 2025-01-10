using studentcrud.Models;

namespace studentcrud.DTOS
{
    public class CoursesDTO
    {
        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public string CourseName { get; set; } = null!;

        public DateOnly CourseDate { get; set; }

        //public virtual Student Student { get; set; } = null!;

    }
}
