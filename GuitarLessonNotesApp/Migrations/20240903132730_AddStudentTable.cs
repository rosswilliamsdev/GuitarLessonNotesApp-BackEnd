using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarLessonNotesApp.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "YoutubeUrl",
                table: "LessonNotes",
                newName: "YouTubeUrl");

            migrationBuilder.AddColumn<string>(
                name: "Instrument",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instrument",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "YouTubeUrl",
                table: "LessonNotes",
                newName: "YoutubeUrl");
        }
    }
}
