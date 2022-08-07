using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_Task_BookandCategory.Migrations
{
    public partial class createBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Author = table.Column<string>(maxLength: 30, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Display = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
