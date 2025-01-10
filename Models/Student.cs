using System;
using System.Collections.Generic;

namespace studentcrud.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
