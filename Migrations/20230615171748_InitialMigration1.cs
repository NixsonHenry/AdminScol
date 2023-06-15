using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminScol.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EtudiantId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatutMatrimonial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maladie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClasseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etudiants_Classes_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_EtudiantId",
                table: "Classes",
                column: "EtudiantId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_ClasseId",
                table: "Etudiants",
                column: "ClasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Etudiants_EtudiantId",
                table: "Classes",
                column: "EtudiantId",
                principalTable: "Etudiants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Etudiants_EtudiantId",
                table: "Classes");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropIndex(
                name: "IX_Classes_EtudiantId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "EtudiantId",
                table: "Classes");
        }
    }
}
