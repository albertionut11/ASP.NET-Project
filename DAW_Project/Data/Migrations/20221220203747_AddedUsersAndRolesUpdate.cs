using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAW_Project.Data.Migrations
{
    public partial class AddedUsersAndRolesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Domains_AspNetUsers_UserId",
                table: "Domains");

            migrationBuilder.DropForeignKey(
                name: "FK_Modifications_AspNetUsers_UserId",
                table: "Modifications");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Modifications",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Modifications_UserId",
                table: "Modifications",
                newName: "IX_Modifications_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Domains",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Domains_UserId",
                table: "Domains",
                newName: "IX_Domains_UserID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Articles",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                newName: "IX_Articles_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserID",
                table: "Articles",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_AspNetUsers_UserID",
                table: "Domains",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modifications_AspNetUsers_UserID",
                table: "Modifications",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_UserID",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Domains_AspNetUsers_UserID",
                table: "Domains");

            migrationBuilder.DropForeignKey(
                name: "FK_Modifications_AspNetUsers_UserID",
                table: "Modifications");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Modifications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Modifications_UserID",
                table: "Modifications",
                newName: "IX_Modifications_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Domains",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Domains_UserID",
                table: "Domains",
                newName: "IX_Domains_UserId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Articles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_UserID",
                table: "Articles",
                newName: "IX_Articles_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Domains_AspNetUsers_UserId",
                table: "Domains",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modifications_AspNetUsers_UserId",
                table: "Modifications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
