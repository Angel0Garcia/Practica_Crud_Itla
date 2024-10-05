using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud1.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Pro_id = table.Column<double>(type: "float", nullable: false),
                    pro_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pro_price = table.Column<double>(type: "float", nullable: false),
                    pro_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Pro_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
