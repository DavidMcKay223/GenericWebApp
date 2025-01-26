using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericWebApp.Model.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Music_Track_Title",
                table: "Music_Track",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Music_CD_Name",
                table: "Music_CD",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Music_Album_ArtistName",
                table: "Music_Album",
                column: "ArtistName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Music_Track_Title",
                table: "Music_Track");

            migrationBuilder.DropIndex(
                name: "IX_Music_CD_Name",
                table: "Music_CD");

            migrationBuilder.DropIndex(
                name: "IX_Music_Album_ArtistName",
                table: "Music_Album");
        }
    }
}
