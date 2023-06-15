using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdminScol.Migrations
{
    /// <inheritdoc />
    public partial class SecondOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Cours_CourId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_CourId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "CourId",
                table: "Classes");

            migrationBuilder.AlterColumn<string>(
                name: "NomCours",
                table: "Cours",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NomCours",
                table: "Cours",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cours",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CourId",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CourId",
                table: "Classes",
                column: "CourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Cours_CourId",
                table: "Classes",
                column: "CourId",
                principalTable: "Cours",
                principalColumn: "Id");
        }
    }
}
