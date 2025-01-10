using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentcrud.DTOS;
using studentcrud.Models;

namespace studentcrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly StudentsContext context;
        private readonly IMapper mapper;

        public StudentApiController(StudentsContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await context.Students
                        .Include(c=>c.Courses).ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudents(int id)
        {
            //await db.Items.Include(i => i.ItemVerifications)
            //.FirstOrDefaultAsync(i => i.Id == id.Value);
            var res = await context.Students.FindAsync(id);

            var data = await context.Students.Include(c=>c.Courses)
                .FirstOrDefaultAsync(i=>id == i.StudentId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        //private Student MapStudentObject(StudentsDTO std)
        //{
        //    var student = new Student();
        //    student.FirstName = std.FirstName;
        //    student.LastName = std.LastName;
        //    student.Email = std.Email;
        //    student.DateOfBirth = std.DateOfBirth;
        //    student.Courses = new List<Course>();
        //    foreach (var item in std.Courses)
        //    {
        //        var newcourse = new Course();
        //        newcourse.CourseName = item.CourseName;
        //        newcourse.CourseDate = item.CourseDate;
        //        student.Courses.Add(newcourse);
        //    }
        //    return student;
        //}
          
        [HttpPost]
        public async Task<ActionResult> CreatStudents(StudentsDTO std)
        {
            var newstd = mapper.Map<Student>(std);
            await context.Students.AddAsync(newstd);
            await context.SaveChangesAsync();
            return Ok(newstd);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>>> UpdateStudents(int id ,StudentsDTO std)
        {
            var newstd = mapper.Map<Student>(std);
            if (id != newstd.StudentId)
            {
                return BadRequest();
            }
            context.Students.Update(newstd);
            await context.SaveChangesAsync();
            return Ok(newstd);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudents(int id)
        {
            //var std = await context.Students.FindAsync(id);
            //if (std == null)
            //{
            //    return NotFound();
            //}
            //context.Students.Remove(std);
            //await context.SaveChangesAsync();
            //return Ok();

            var stdDelete = await context
                .Students.Include(c => c.Courses).Where(c => c.StudentId == id)
                .FirstOrDefaultAsync();
            if (stdDelete == null)
            {
                return NotFound();
            }
            context.Students.Remove(stdDelete);
            await context.SaveChangesAsync();
            return Ok(stdDelete);
        }
    }
}
