using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finances.Migrations
{
    /// <inheritdoc />
    public partial class Database3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Debitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InstituicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debitos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debitos_Instituicoes_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Debitos_InstituicaoId",
                table: "Debitos",
                column: "InstituicaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debitos");
        }
    }
}
