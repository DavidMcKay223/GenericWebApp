using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericWebApp.Model.Migrations.Management
{
    public partial class AddCreatedAndUpdatedDatesToTaskItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskObjectType_Code",
                table: "Management_TaskItem",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Management_TaskItem",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Management_TaskItem",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Management_TaskItem");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Management_TaskItem");

            migrationBuilder.AlterColumn<string>(
                name: "TaskObjectType_Code",
                table: "Management_TaskItem",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}
