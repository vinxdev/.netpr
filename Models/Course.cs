using System;
using System.Collections.Generic;

namespace studentcrud.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public int StudentId { get; set; }

    public string CourseName { get; set; } = null!;

    public DateOnly CourseDate { get; set; }

    public virtual Student Student { get; set; } = null!;
}
