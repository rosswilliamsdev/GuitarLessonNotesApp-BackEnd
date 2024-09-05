using GuitarLessonNotesApp.Data;
using GuitarLessonNotesApp.DTOs;
using GuitarLessonNotesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;

namespace GuitarLessonNotesApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonNotesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LessonNotesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LessonNotes
        [HttpGet]
        public IActionResult Get()
        {
            var lessonNotes = _context.LessonNotes.ToList();
            return Ok(lessonNotes);
        }

        // POST: api/LessonNotes
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] LessonNoteDTO lessonNoteDTO)
        {
            var student = _context.Students.FirstOrDefault(s => s.Name == lessonNoteDTO.StudentName);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            var lessonNote = new LessonNote
            {
                Date = DateTime.Parse(lessonNoteDTO.Date),
                Content = lessonNoteDTO.NoteContent,
                YouTubeUrl = lessonNoteDTO.YouTubeUrl, // Optional
                Student = student
            };

            if (lessonNoteDTO.Attachments != null)
            {
                foreach (var file in lessonNoteDTO.Attachments)
                {
                    if (file.Length > 0)
                    {
                        var filePath = Path.Combine("uploads", file.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var attachment = new Attachment
                        {
                            FilePath = filePath,
                            FileName = file.FileName,
                            FileSize = file.Length,
                            UploadDate = DateTime.UtcNow,
                            LessonNote = lessonNote
                        };

                        _context.Attachments.Add(attachment);
                    }
                }
            }

            _context.LessonNotes.Add(lessonNote);
            await _context.SaveChangesAsync();

            return Ok("Lesson note and attachments saved successfully");
        }


    }
}
