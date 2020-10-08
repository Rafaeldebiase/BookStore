using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "varchar(200)", nullable: true),
                    sub_titulo = table.Column<string>(type: "varchar(200)", nullable: true),
                    primeiro_nome = table.Column<string>(type: "varchar(200)", nullable: true),
                    sobre_nome = table.Column<string>(type: "varchar(200)", nullable: true),
                    isbn = table.Column<string>(type: "char(13)", nullable: true),
                    ano_de_lancamento = table.Column<string>(type: "char(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
