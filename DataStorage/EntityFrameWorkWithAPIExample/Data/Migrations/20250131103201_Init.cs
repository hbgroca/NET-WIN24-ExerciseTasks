using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GameDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: true),
                    GameEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameDetails_Games_GameEntityId",
                        column: x => x.GameEntityId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameEntityGenreEntity",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameEntityGenreEntity", x => new { x.GamesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_GameEntityGenreEntity_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameEntityGenreEntity_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Description", "EndedDate", "Name", "StartedDate" },
                values: new object[,]
                {
                    { 1, "Blizzard Entertainment, Inc. is an American video game developer and publisher based in Irvine, California.", null, "Blizzard Entertainment", new DateOnly(1991, 2, 1) },
                    { 2, "Valve Corporation is an American video game developer, publisher, and digital distribution company headquartered in Bellevue, Washington.", null, "Valve Corporation", new DateOnly(1996, 8, 24) },
                    { 3, "Rockstar Games, Inc. is an American video game publisher based in New York City.", null, "Rockstar Games", new DateOnly(1998, 12, 1) },
                    { 4, "Electronic Arts Inc. is an American video game company headquartered in Redwood City, California.", null, "Electronic Arts", new DateOnly(1982, 5, 28) },
                    { 5, "Ubisoft Entertainment SA is a French video game company headquartered in Montreuil with several development studios across the world.", null, "Ubisoft", new DateOnly(1986, 3, 12) },
                    { 6, "Square Enix Holdings Co., Ltd. is a Japanese video game developer, publisher, and distribution company known for its Final Fantasy, Dragon Quest, and Kingdom Hearts role-playing video game franchises.", null, "Square Enix", new DateOnly(2003, 4, 1) },
                    { 7, "Capcom Co., Ltd. is a Japanese video game developer and publisher known for creating multi-million-selling franchises such as Resident Evil, Street Fighter, and Monster Hunter.", null, "Capcom", new DateOnly(1979, 5, 30) },
                    { 8, "Naughty Dog, LLC is an American first-party video game developer based in Santa Monica, California.", null, "Naughty Dog", new DateOnly(1984, 9, 27) },
                    { 9, "Bungie, Inc. is an American video game developer based in Bellevue, Washington.", null, "Bungie", new DateOnly(1991, 5, 1) },
                    { 10, "CD Projekt Red is a Polish video game developer based in Warsaw, founded in 2002.", null, "CD Projekt Red", new DateOnly(2002, 2, 1) },
                    { 11, "Bethesda Game Studios is an American video game developer and a studio of ZeniMax Media based in Rockville, Maryland.", null, "Bethesda Game Studios", new DateOnly(2001, 10, 1) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Genre" },
                values: new object[,]
                {
                    { 1, "FPS" },
                    { 2, "RPG" },
                    { 3, "Action" },
                    { 4, "Adventure" },
                    { 5, "Strategy" },
                    { 6, "Simulation" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "DeveloperId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Diablo 2: Lord Of Destruction" },
                    { 2, 2, "Half-Life 2" },
                    { 3, 3, "Grand Theft Auto V" },
                    { 4, 4, "The Sims 4" },
                    { 5, 5, "Assassin's Creed Valhalla" },
                    { 6, 6, "Final Fantasy XV" },
                    { 7, 7, "Resident Evil Village" },
                    { 8, 8, "The Last of Us Part II" },
                    { 9, 9, "Destiny 2" },
                    { 10, 10, "Cyberpunk 2077" }
                });

            migrationBuilder.InsertData(
                table: "GameDetails",
                columns: new[] { "Id", "Description", "GameEntityId", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Diablo 2: Lord Of Destruction", 1, new DateOnly(2000, 6, 30) },
                    { 2, "Half-Life 2", 2, new DateOnly(2004, 11, 16) },
                    { 3, "Grand Theft Auto V", 3, new DateOnly(2013, 9, 17) },
                    { 4, "The Sims 4", 4, new DateOnly(2014, 9, 2) },
                    { 5, "Assassin's Creed Valhalla", 5, new DateOnly(2020, 11, 10) },
                    { 6, "Final Fantasy XV", 6, new DateOnly(2016, 11, 29) },
                    { 7, "Resident Evil Village", 7, new DateOnly(2021, 5, 7) },
                    { 8, "The Last of Us Part II", 8, new DateOnly(2020, 6, 19) },
                    { 9, "Destiny 2", 9, new DateOnly(2017, 9, 6) },
                    { 10, "Cyberpunk 2077", 10, new DateOnly(2020, 12, 10) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameDetails_GameEntityId",
                table: "GameDetails",
                column: "GameEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameEntityGenreEntity_GenresId",
                table: "GameEntityGenreEntity",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                column: "DeveloperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameDetails");

            migrationBuilder.DropTable(
                name: "GameEntityGenreEntity");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}
