using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ing.Migrations
{
    /// <inheritdoc />
    public partial class ModificacaoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Usuarios_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Movies_FilmeId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Persons");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "Sessions",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_FilmeId",
                table: "Sessions",
                newName: "IX_Sessions_MovieId");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Persons",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateStart",
                table: "Persons",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EmployeePosition",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Persons",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Persons",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Persons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Persons",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "NIF");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Persons_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Persons",
                principalColumn: "NIF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Movies_MovieId",
                table: "Sessions",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Persons_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Movies_MovieId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EmployeePosition",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Clients");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Sessions",
                newName: "FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_MovieId",
                table: "Sessions",
                newName: "IX_Sessions_FilmeId");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Clients",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "NIF");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    NIF = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.NIF);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Usuarios_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "NIF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Movies_FilmeId",
                table: "Sessions",
                column: "FilmeId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
