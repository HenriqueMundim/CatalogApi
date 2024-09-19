using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogApi.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(Name, ImageUrl) VALUES('Bebidas', 'bebidas.jpg')");
            migrationBuilder.Sql("INSERT INTO Categories(Name, ImageUrl) VALUES('Sobremesas', 'sobremesas.jpg')");
            migrationBuilder.Sql("INSERT INTO Categories(Name, ImageUrl) VALUES('Lanches', 'lanches.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories WHERE Categories.Name == 'Bebidas'");
            migrationBuilder.Sql("DELETE FROM Categories WHERE Categories.Name == 'Sobremesas'");
            migrationBuilder.Sql("DELETE FROM Categories WHERE Categories.Name == 'Lanches'");
        }
    }
}
