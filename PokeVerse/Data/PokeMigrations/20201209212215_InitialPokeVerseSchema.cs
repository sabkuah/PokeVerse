using Microsoft.EntityFrameworkCore.Migrations;

namespace PokeVerse.Data.PokeMigrations
{
    public partial class InitialPokeVerseSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokedexPokemons_Pokemons_PokemonId",
                table: "PokedexPokemons");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTypes_Pokemons_PokemonId",
                table: "PokemonTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pokemons",
                table: "Pokemons");

            migrationBuilder.RenameTable(
                name: "Pokemons",
                newName: "Pokemon");

            migrationBuilder.AddColumn<int>(
                name: "PokeNumber",
                table: "Pokemon",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pokemon",
                table: "Pokemon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokedexPokemons_Pokemon_PokemonId",
                table: "PokedexPokemons",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTypes_Pokemon_PokemonId",
                table: "PokemonTypes",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PokedexPokemons_Pokemon_PokemonId",
                table: "PokedexPokemons");

            migrationBuilder.DropForeignKey(
                name: "FK_PokemonTypes_Pokemon_PokemonId",
                table: "PokemonTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pokemon",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "PokeNumber",
                table: "Pokemon");

            migrationBuilder.RenameTable(
                name: "Pokemon",
                newName: "Pokemons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pokemons",
                table: "Pokemons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PokedexPokemons_Pokemons_PokemonId",
                table: "PokedexPokemons",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PokemonTypes_Pokemons_PokemonId",
                table: "PokemonTypes",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
