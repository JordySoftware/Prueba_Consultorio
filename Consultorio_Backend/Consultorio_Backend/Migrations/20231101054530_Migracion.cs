using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio_Backend.Migrations
{
    public partial class Migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "seguro",
                columns: table => new
                {
                    id_seguro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_del_seguro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigo_seguro = table.Column<int>(type: "int", nullable: false),
                    suma_asegurada = table.Column<int>(type: "int", nullable: false),
                    prima = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seguro", x => x.id_seguro);
                });

            migrationBuilder.CreateTable(
                name: "asegurado",
                columns: table => new
                {
                    id_asegurado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_seguro = table.Column<int>(type: "int", nullable: false),
                    cedula = table.Column<int>(type: "int", nullable: false),
                    nombre_del_cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asegurado", x => x.id_asegurado);
                    table.ForeignKey(
                        name: "FK_asegurado_seguro_id_seguro",
                        column: x => x.id_seguro,
                        principalTable: "seguro",
                        principalColumn: "id_seguro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asegurado_id_seguro",
                table: "asegurado",
                column: "id_seguro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asegurado");

            migrationBuilder.DropTable(
                name: "seguro");
        }
    }
}
