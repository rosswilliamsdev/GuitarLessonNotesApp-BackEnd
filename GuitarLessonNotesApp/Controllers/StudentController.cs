using GuitarLessonNotesApp.Data;
using GuitarLessonNotesApp.DTOs;
using GuitarLessonNotesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GuitarLessonNotesApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Students
        [HttpPost]
        public IActionResult Post([FromBody] StudentDTO studentDTO)
        {
            var student = new Student
            {
                Name = studentDTO.Name,
                Instrument = studentDTO.Instrument
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student.StudentId); // Return the generated StudentId
        }

        // GET: api/Students
        [HttpGet]
        public IActionResult Get()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }
    }
}
