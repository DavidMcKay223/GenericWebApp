using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericWebApp.Model.Migrations.Management
{
    public partial class InitialMigrationForManagementContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Management_TaskActivity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskType_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TaskSubType_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management_TaskActivity", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Management_TaskItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskObjectType_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Task_Object_ID = table.Column<int>(type: "int", nullable: true),
                    TaskActivity_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management_TaskItem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Management_TaskObjectType",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management_TaskObjectType", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Management_TaskSubType",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management_TaskSubType", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Management_TaskType",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management_TaskType", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Management_TaskActivity");

            migrationBuilder.DropTable(
                name: "Management_TaskItem");

            migrationBuilder.DropTable(
                name: "Management_TaskObjectType");

            migrationBuilder.DropTable(
                name: "Management_TaskSubType");

            migrationBuilder.DropTable(
                name: "Management_TaskType");
        }
    }
}
