using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sintomas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Salones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aforo = table.Column<int>(type: "int", nullable: false),
                    hora = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fabricante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    esquema = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Instalaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salonid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instalaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Instalaciones_Salones_salonid",
                        column: x => x.salonid,
                        principalTable: "Salones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    diagnosticoid = table.Column<int>(type: "int", nullable: true),
                    vacunaid = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    carrera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    semestre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    turno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    materia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personas_Diagnosticos_diagnosticoid",
                        column: x => x.diagnosticoid,
                        principalTable: "Diagnosticos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Vacunas_vacunaid",
                        column: x => x.vacunaid,
                        principalTable: "Vacunas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instalaciones_salonid",
                table: "Instalaciones",
                column: "salonid");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_diagnosticoid",
                table: "Personas",
                column: "diagnosticoid");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_vacunaid",
                table: "Personas",
                column: "vacunaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instalaciones");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Salones");

            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Vacunas");
        }
    }
}
