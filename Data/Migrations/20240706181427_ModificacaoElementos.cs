using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ing.Migrations
{
    /// <inheritdoc />
    public partial class ModificacaoElementos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Sessions_SessaoId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_SessaoId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SessaoId",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "NLugares",
                table: "Sessions",
                newName: "QuantitySits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantitySits",
                table: "Sessions",
                newName: "NLugares");

            migrationBuilder.AddColumn<int>(
                name: "SessaoId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SessaoId",
                table: "OrderItems",
                column: "SessaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Sessions_SessaoId",
                table: "OrderItems",
                column: "SessaoId",
                principalTable: "Sessions",
                principalColumn: "SessaoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
