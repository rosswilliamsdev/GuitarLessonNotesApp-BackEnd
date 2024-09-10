using GuitarLessonNotesApp.Models;

public class LessonNote
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public string Content { get; set; }
    public string YouTubeUrl { get; set; }
    public DateTime Date { get; set; }

    // One-to-Many relationship with Attachments
    public ICollection<Attachment> Attachments { get; set; }
}

