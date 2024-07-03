using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ing.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTbMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InExib",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "DateAdd",
                table: "Movies",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Movies",
                newName: "DateAdd");

            migrationBuilder.AddColumn<bool>(
                name: "InExib",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
