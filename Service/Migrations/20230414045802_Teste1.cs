using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.Migrations
{
    /// <inheritdoc />
    public partial class Teste1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorLivro");

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "livros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BaseAutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LivroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseAutor_livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "livros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_livros_AutorId",
                table: "livros",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAutor_LivroId",
                table: "BaseAutor",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_livros_autores_AutorId",
                table: "livros",
                column: "AutorId",
                principalTable: "autores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_livros_autores_AutorId",
                table: "livros");

            migrationBuilder.DropTable(
                name: "BaseAutor");

            migrationBuilder.DropIndex(
                name: "IX_livros_AutorId",
                table: "livros");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "livros");

            migrationBuilder.CreateTable(
                name: "AutorLivro",
                columns: table => new
                {
                    AutoresId = table.Column<int>(type: "int", nullable: false),
                    LivrosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLivro", x => new { x.AutoresId, x.LivrosId });
                    table.ForeignKey(
                        name: "FK_AutorLivro_autores_AutoresId",
                        column: x => x.AutoresId,
                        principalTable: "autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorLivro_livros_LivrosId",
                        column: x => x.LivrosId,
                        principalTable: "livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorLivro_LivrosId",
                table: "AutorLivro",
                column: "LivrosId");
        }
    }
}
