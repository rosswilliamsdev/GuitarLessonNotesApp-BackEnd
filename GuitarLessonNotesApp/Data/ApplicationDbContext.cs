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
    }
}
