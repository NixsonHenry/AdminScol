using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminScol.Migrations
{
    /// <inheritdoc />
    public partial class SecondThree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professeur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professeur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourProfesseur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourId = table.Column<int>(type: "int", nullable: false),
                    ProfesseurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourProfesseur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourProfesseur_Cours_CourId",
                        column: x => x.CourId,
                        principalTable: "Cours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourProfesseur_Professeur_ProfesseurId",
                        column: x => x.ProfesseurId,
                        principalTable: "Professeur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourProfesseur_CourId",
                table: "CourProfesseur",
                column: "CourId");

            migrationBuilder.CreateIndex(
                name: "IX_CourProfesseur_ProfesseurId",
                table: "CourProfesseur",
                column: "ProfesseurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourProfesseur");

            migrationBuilder.DropTable(
                name: "Professeur");
        }
    }
}
