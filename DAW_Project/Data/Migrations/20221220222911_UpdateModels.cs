using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAW_Project.Data.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Editor_Name",
                table: "Modifications",
                newName: "Modificator_Name");

            migrationBuilder.RenameColumn(
                name: "Modify_count",
                table: "Articles",
                newName: "Domain_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modificator_Name",
                table: "Modifications",
                newName: "Editor_Name");

            migrationBuilder.RenameColumn(
                name: "Domain_id",
                table: "Articles",
                newName: "Modify_count");
        }
    }
}
