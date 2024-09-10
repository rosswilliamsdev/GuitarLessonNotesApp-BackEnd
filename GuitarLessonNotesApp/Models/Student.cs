using System.ComponentModel.DataAnnotations;

namespace GuitarLessonNotesApp.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } //auto generated
        public string Name { get; set; }
        public string Instrument { get; set; }

        // Foreign key reference to the User (admin)
        public int UserId { get; set; }
        public User User { get; set; }

        // Navigation property for related lesson notes
        public ICollection<LessonNote> LessonNotes { get; set; }

        public Student()
        {
            LessonNotes = new List<LessonNote>();
        }
    }
}
