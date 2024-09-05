namespace GuitarLessonNotesApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // Admin or Student

        // Navigation property for related students (for Admin)
        public List<Student> Students { get; set; }
    }

}
