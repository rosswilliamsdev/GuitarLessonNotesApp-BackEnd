using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarLessonNotesApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$DgpT/ER.YxCbTTwGoh5DnuDPoEWhj2H4XIY1SR7Yii7CL6PpK8z8S");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$dBDgbAMoz0myWvpyftZEduvMjYObsO3AZgONkAT4pxyF38cOII8Ai");
        }
    }
}
