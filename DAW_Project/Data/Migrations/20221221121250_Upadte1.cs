using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAW_Project.Data.Migrations
{
    public partial class Upadte1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Domains_DomainId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Modifications_Articles_Article_Id1",
                table: "Modifications");

            migrationBuilder.DropIndex(
                name: "IX_Modifications_Article_Id1",
                table: "Modifications");

            migrationBuilder.DropIndex(
                name: "IX_Articles_DomainId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Article_Id1",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "DomainId",
                table: "Articles");

            migrationBuilder.AlterColumn<string>(
                name: "Domain_description",
                table: "Domains",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Modifications_Article_Id",
                table: "Modifications",
                column: "Article_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Domain_id",
                table: "Articles",
                column: "Domain_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Domains_Domain_id",
                table: "Articles",
                column: "Domain_id",
                principalTable: "Domains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modifications_Articles_Article_Id",
                table: "Modifications",
                column: "Article_Id",
                principalTable: "Articles",
                principalColumn: "Article_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Domains_Domain_id",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Modifications_Articles_Article_Id",
                table: "Modifications");

            migrationBuilder.DropIndex(
                name: "IX_Modifications_Article_Id",
                table: "Modifications");

            migrationBuilder.DropIndex(
                name: "IX_Articles_Domain_id",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "Article_Id1",
                table: "Modifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Domain_description",
                table: "Domains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DomainId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Modifications_Article_Id1",
                table: "Modifications",
                column: "Article_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_DomainId",
                table: "Articles",
                column: "DomainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Domains_DomainId",
                table: "Articles",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modifications_Articles_Article_Id1",
                table: "Modifications",
                column: "Article_Id1",
                principalTable: "Articles",
                principalColumn: "Article_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
