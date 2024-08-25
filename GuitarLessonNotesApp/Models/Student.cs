namespace GuitarLessonNotesApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<LessonNote> LessonNotes { get; set; }

        public Student()
        {
            LessonNotes = new List<LessonNote>();
        }
    }
}
