using GuitarLessonNotesApp.Models;

public class LessonNote
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Content { get; set; }
    public string YouTubeUrl { get; set; }
    public Student Student { get; set; }
    public int StudentId { get; set; }
    public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
}

