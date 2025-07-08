using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManejoStocks.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productos",
                table: "productos");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "productos",
                newName: "Productos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    CantidadMinima = table.Column<int>(type: "int", nullable: false),
                    ProductosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "Productos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductosId",
                table: "Stock",
                column: "ProductosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "productos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productos",
                table: "productos",
                column: "Id");
        }
    }
}
