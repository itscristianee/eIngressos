using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ing.Migrations
{
    /// <inheritdoc />
    public partial class Updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsMovies_Movies_FilmeId",
                table: "ActorsMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "FuncId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Movies",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Produtor",
                table: "Movies",
                newName: "Producer");

            migrationBuilder.RenameColumn(
                name: "FilmeCategoria",
                table: "Movies",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "EmExib",
                table: "Movies",
                newName: "InExib");

            migrationBuilder.RenameColumn(
                name: "Duracao",
                table: "Movies",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Movies",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DataAdd",
                table: "Movies",
                newName: "DateAdd");

            migrationBuilder.RenameColumn(
                name: "ClassificacaoEtaria",
                table: "Movies",
                newName: "AgeRating");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "Movies",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Usuarios",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Telemovel",
                table: "Usuarios",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "DataNasc",
                table: "Usuarios",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "Telemovel",
                table: "Clients",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "DataNasc",
                table: "Clients",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "ActorsMovies",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsMovies_FilmeId",
                table: "ActorsMovies",
                newName: "IX_ActorsMovies_MovieId");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureURL",
                table: "Actors",
                newName: "ProfilePicture");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Usuarios",
                column: "NIF");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsMovies_Movies_MovieId",
                table: "ActorsMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorsMovies_Movies_MovieId",
                table: "ActorsMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Producer",
                table: "Movies",
                newName: "Produtor");

            migrationBuilder.RenameColumn(
                name: "InExib",
                table: "Movies",
                newName: "EmExib");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Movies",
                newName: "FilmeCategoria");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Movies",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "DateAdd",
                table: "Movies",
                newName: "DataAdd");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Movies",
                newName: "Duracao");

            migrationBuilder.RenameColumn(
                name: "AgeRating",
                table: "Movies",
                newName: "ClassificacaoEtaria");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movies",
                newName: "FilmeId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Usuarios",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Usuarios",
                newName: "Telemovel");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Usuarios",
                newName: "DataNasc");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Clients",
                newName: "Telemovel");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Clients",
                newName: "DataNasc");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "ActorsMovies",
                newName: "FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_ActorsMovies_MovieId",
                table: "ActorsMovies",
                newName: "IX_ActorsMovies_FilmeId");

            migrationBuilder.RenameColumn(
                name: "ProfilePicture",
                table: "Actors",
                newName: "ProfilePictureURL");

            migrationBuilder.AddColumn<int>(
                name: "FuncId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Usuarios",
                column: "FuncId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorsMovies_Movies_FilmeId",
                table: "ActorsMovies",
                column: "FilmeId",
                principalTable: "Movies",
                principalColumn: "FilmeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
