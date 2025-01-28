using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenericWebApp.Model.Migrations.Template
{
    /// <inheritdoc />
    public partial class migrationUpdatingFK14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrimaryAddressID",
                table: "Template_TemplateItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryAddressID",
                table: "Template_TemplateItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Template_TemplateAddress",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template_TemplateAddress", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Template_TemplateItem_PrimaryAddressID",
                table: "Template_TemplateItem",
                column: "PrimaryAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Template_TemplateItem_SecondaryAddressID",
                table: "Template_TemplateItem",
                column: "SecondaryAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Template_TemplateItem_Template_TemplateAddress_PrimaryAddressID",
                table: "Template_TemplateItem",
                column: "PrimaryAddressID",
                principalTable: "Template_TemplateAddress",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Template_TemplateItem_Template_TemplateAddress_SecondaryAddressID",
                table: "Template_TemplateItem",
                column: "SecondaryAddressID",
                principalTable: "Template_TemplateAddress",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Template_TemplateItem_Template_TemplateAddress_PrimaryAddressID",
                table: "Template_TemplateItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Template_TemplateItem_Template_TemplateAddress_SecondaryAddressID",
                table: "Template_TemplateItem");

            migrationBuilder.DropTable(
                name: "Template_TemplateAddress");

            migrationBuilder.DropIndex(
                name: "IX_Template_TemplateItem_PrimaryAddressID",
                table: "Template_TemplateItem");

            migrationBuilder.DropIndex(
                name: "IX_Template_TemplateItem_SecondaryAddressID",
                table: "Template_TemplateItem");

            migrationBuilder.DropColumn(
                name: "PrimaryAddressID",
                table: "Template_TemplateItem");

            migrationBuilder.DropColumn(
                name: "SecondaryAddressID",
                table: "Template_TemplateItem");
        }
    }
}
