using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PokeVerse.Data.PokeMigrations
{
    public partial class SecondSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokeDex",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainerId = table.Column<int>(nullable: false),
                    PokedexId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokeDex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PokeDex_PokeDex_PokedexId",
                        column: x => x.PokedexId,
                        principalTable: "PokeDex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DateJoined = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokedexPokemons",
                columns: table => new
                {
                    PokedexId = table.Column<int>(nullable: false),
                    PokemonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokedexPokemons", x => new { x.PokedexId, x.PokemonId });
                    table.ForeignKey(
                        name: "FK_PokedexPokemons_PokeDex_PokedexId",
                        column: x => x.PokedexId,
                        principalTable: "PokeDex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokedexPokemons_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokeDex_PokedexId",
                table: "PokeDex",
                column: "PokedexId");

            migrationBuilder.CreateIndex(
                name: "IX_PokedexPokemons_PokemonId",
                table: "PokedexPokemons",
                column: "PokemonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokedexPokemons");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "PokeDex");
        }
    }
}
