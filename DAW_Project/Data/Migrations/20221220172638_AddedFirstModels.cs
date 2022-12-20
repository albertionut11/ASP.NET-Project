using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAW_Project.Data.Migrations
{
    public partial class AddedFirstModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Article_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Editor_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modify_count = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Article_Id);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Domain_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Domain_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Domain_id);
                });

            migrationBuilder.CreateTable(
                name: "Modifications",
                columns: table => new
                {
                    Modification_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article_Id = table.Column<int>(type: "int", nullable: false),
                    Editor_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    New_Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifications", x => x.Modification_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Modifications");
        }
    }
}
