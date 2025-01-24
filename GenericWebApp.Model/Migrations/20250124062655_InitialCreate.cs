using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericWebApp.Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Music_Album",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music_Album", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Music_Genre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Music_CD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Album_ID = table.Column<int>(type: "int", nullable: true),
                    Genre_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music_CD", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Music_CD_Music_Album_Album_ID",
                        column: x => x.Album_ID,
                        principalTable: "Music_Album",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Music_Track",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CD_ID = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music_Track", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Music_Track_Music_CD_CD_ID",
                        column: x => x.CD_ID,
                        principalTable: "Music_CD",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Music_CD_Album_ID",
                table: "Music_CD",
                column: "Album_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Music_Track_CD_ID",
                table: "Music_Track",
                column: "CD_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Music_Genre");

            migrationBuilder.DropTable(
                name: "Music_Track");

            migrationBuilder.DropTable(
                name: "Music_CD");

            migrationBuilder.DropTable(
                name: "Music_Album");
        }
    }
}
