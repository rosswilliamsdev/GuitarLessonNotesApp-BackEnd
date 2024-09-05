using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GuitarLessonNotesApp.DTOs
{
    public class LessonNoteDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Date { get; set; }
        public string NoteContent { get; set; }
        public List<IFormFile>? Attachments { get; set; }  // Optional
        public string? YouTubeUrl { get; set; }  // Optional
    }


}
