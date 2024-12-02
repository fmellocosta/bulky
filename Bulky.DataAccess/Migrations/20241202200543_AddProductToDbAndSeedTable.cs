using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductToDbAndSeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "John Doe", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed iaculis leo id porttitor feugiat. Aenean efficitur sodales libero, a placerat velit commodo ut.", "AA15845467881101", 99.0, 90.0, 80.0, 85.0, "Running Free" },
                    { 2, "Max Mustermann", "Proin imperdiet lectus vel sem sodales, sed tincidunt arcu blandit. Mauris commodo sapien ex, vitae facilisis nisi convallis ac. Vestibulum tellus turpis, pulvinar vel pulvinar sed, imperdiet eu libero.", "BB12312313312303", 40.0, 30.0, 20.0, 25.0, "How to become an incognito" },
                    { 3, "João da Silva", "Maecenas venenatis sit amet nunc at hendrerit. Nulla eget arcu molestie, placerat odio et, scelerisque odio. Nam vestibulum eget nunc sollicitudin vulputate.", "CC4182438124315245", 55.0, 50.0, 40.0, 45.0, "Por que era só mais um Silva" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
