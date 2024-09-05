namespace GuitarLessonNotesApp.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public int LessonNoteId { get; set; } //Foreign key
        public LessonNote LessonNote { get; set; } //Navigation property
    }

}
