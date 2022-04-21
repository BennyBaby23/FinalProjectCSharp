using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject1.Migrations
{
    public partial class MYMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinalProject",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AboutProducts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Productprice = table.Column<int>(type: "int", nullable: false),
                    ProductMadeCountry = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalProject", x => x.ProductID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalProject");
        }
    }
}
