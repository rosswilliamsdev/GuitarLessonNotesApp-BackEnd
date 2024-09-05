using System.ComponentModel.DataAnnotations;

namespace GuitarLessonNotesApp.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } //auto generated
        public string Name { get; set; }
        public string Instrument { get; set; }

        public ICollection<LessonNote> LessonNotes { get; set; }

        public Student()
        {
            LessonNotes = new List<LessonNote>();
        }
    }
}
