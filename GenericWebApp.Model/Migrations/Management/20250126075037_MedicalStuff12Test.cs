using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericWebApp.Model.Migrations.Management
{
    /// <inheritdoc />
    public partial class MedicalStuff12Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Management_Address",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management_Address", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Management_Claimant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsurancePolicyNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrimaryAddressID = table.Column<int>(type: "int", nullable: false),
                    SecondaryAddressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management_Claimant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Management_Claimant_Management_Address_PrimaryAddressID",
                        column: x => x.PrimaryAddressID,
                        principalTable: "Management_Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Management_Claimant_Management_Address_SecondaryAddressID",
                        column: x => x.SecondaryAddressID,
                        principalTable: "Management_Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Management_CMS1500Form",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimantID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Management_CMS1500Form", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Management_CMS1500Form_Management_Claimant_ClaimantID",
                        column: x => x.ClaimantID,
                        principalTable: "Management_Claimant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Management_Claimant_PrimaryAddressID",
                table: "Management_Claimant",
                column: "PrimaryAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Management_Claimant_SecondaryAddressID",
                table: "Management_Claimant",
                column: "SecondaryAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Management_CMS1500Form_ClaimantID",
                table: "Management_CMS1500Form",
                column: "ClaimantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Management_CMS1500Form");

            migrationBuilder.DropTable(
                name: "Management_Claimant");

            migrationBuilder.DropTable(
                name: "Management_Address");
        }
    }
}
