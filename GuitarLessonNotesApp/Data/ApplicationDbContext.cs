﻿using GuitarLessonNotesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarLessonNotesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<LessonNote> LessonNotes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships and constraints here

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // One-to-many relationship between Student and LessonNote
            modelBuilder.Entity<Student>()
                .HasMany(s => s.LessonNotes)
                .WithOne(l => l.Student)
                .HasForeignKey(l => l.StudentId);

            // Define one-to-many relationship between LessonNote and Attachment
            modelBuilder.Entity<LessonNote>()
                .HasMany(l => l.Attachments)
                .WithOne(a => a.LessonNote)
                .HasForeignKey(a => a.LessonNoteId);

            // Additional configuration if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
