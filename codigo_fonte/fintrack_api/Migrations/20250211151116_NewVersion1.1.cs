using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fintrack_api.Migrations
{
    /// <inheritdoc />
    public partial class NewVersion11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "Instituicoes",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Instituicoes");
        }
    }
}
