namespace GuitarLessonNotesApp.Models
{
    public class LessonNote
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }

        public List<string> Attachments { get; set; }  // Store paths to attachments if necessary

        public string YoutubeUrl { get; set; }  // Store the YouTube video link if there is one

        public Student Student { get; set; }
    }
}
