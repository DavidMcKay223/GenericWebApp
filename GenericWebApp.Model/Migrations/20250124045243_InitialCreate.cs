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
                name: "Music_Label",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Founded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Founder = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Defunct = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music_Label", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Music_CD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Album_ID = table.Column<int>(type: "int", nullable: true),
                    Genre_ID = table.Column<int>(type: "int", nullable: true),
                    Label_ID = table.Column<int>(type: "int", nullable: true),
                    AlbumID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music_CD", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Music_CD_Music_Album_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Music_Album",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Music_CD_Music_Label_Label_ID",
                        column: x => x.Label_ID,
                        principalTable: "Music_Label",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Music_Genre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LabelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music_Genre", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Music_Genre_Music_Label_LabelID",
                        column: x => x.LabelID,
                        principalTable: "Music_Label",
                        principalColumn: "ID");
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
                    Length = table.Column<TimeSpan>(type: "time", nullable: false),
                    CDID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music_Track", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Music_Track_Music_CD_CDID",
                        column: x => x.CDID,
                        principalTable: "Music_CD",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Music_Label_Genre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre_ID = table.Column<int>(type: "int", nullable: false),
                    Label_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music_Label_Genre", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Music_Label_Genre_Music_Genre_Genre_ID",
                        column: x => x.Genre_ID,
                        principalTable: "Music_Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Music_Label_Genre_Music_Label_Label_ID",
                        column: x => x.Label_ID,
                        principalTable: "Music_Label",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Music_CD_AlbumID",
                table: "Music_CD",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Music_CD_Label_ID",
                table: "Music_CD",
                column: "Label_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Music_Genre_LabelID",
                table: "Music_Genre",
                column: "LabelID");

            migrationBuilder.CreateIndex(
                name: "IX_Music_Label_Genre_Genre_ID",
                table: "Music_Label_Genre",
                column: "Genre_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Music_Label_Genre_Label_ID",
                table: "Music_Label_Genre",
                column: "Label_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Music_Track_CDID",
                table: "Music_Track",
                column: "CDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Music_Label_Genre");

            migrationBuilder.DropTable(
                name: "Music_Track");

            migrationBuilder.DropTable(
                name: "Music_Genre");

            migrationBuilder.DropTable(
                name: "Music_CD");

            migrationBuilder.DropTable(
                name: "Music_Album");

            migrationBuilder.DropTable(
                name: "Music_Label");
        }
    }
}
