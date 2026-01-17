using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NovenaTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithWenantyNovena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Novenas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DaysDuration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novenas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NovenaDayPrayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NovenaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DayNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    PrayerText = table.Column<string>(type: "TEXT", nullable: false),
                    PrayerTitle = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovenaDayPrayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovenaDayPrayers_Novenas_NovenaId",
                        column: x => x.NovenaId,
                        principalTable: "Novenas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NovenaCompletions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NovenaId = table.Column<int>(type: "INTEGER", nullable: false),
                    NovenaDayPrayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovenaCompletions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovenaCompletions_NovenaDayPrayers_NovenaDayPrayerId",
                        column: x => x.NovenaDayPrayerId,
                        principalTable: "NovenaDayPrayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NovenaCompletions_Novenas_NovenaId",
                        column: x => x.NovenaId,
                        principalTable: "Novenas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Novenas",
                columns: new[] { "Id", "DaysDuration", "Description", "Title" },
                values: new object[] { 1, 9, "Nowenna do Wenantego Katarzyńca to 9-dniowa modlitwa (nowenna od łac. novem - dziewięć), przez którą wierni proszą o łaski za wstawiennictwem Sługi Bożego o. Wenantego, franciszkanina, często w intencjach związanych z pracą, finansami i trudnymi sprawami, a także za dusze w czyśćcu cierpiące, gdyż sam o. Wenanty był ich gorliwym orędownikiem.", "Dziewięciodniowa nowenna za wstawiennictwem Sługi Bożego o.Wenantego Katarzyńca" });

            migrationBuilder.InsertData(
                table: "NovenaDayPrayers",
                columns: new[] { "Id", "DayNumber", "NovenaId", "PrayerText", "PrayerTitle" },
                values: new object[,]
                {
                    { 1, 0, 1, "Boże w Trójcy Jedyny, bądź uwielbiony za wszelkie dobra, którymi napełniłeś sługę Twego Wenantego; on przez życie według rad ewangelicznych i gorliwą posługę kapłańską w Kościele stał się przykładem dla Twoich wiernych. Wynieś, Panie, tego sługę Twego na ołtarze, abyśmy lepiej mogli Tobie służyć, mnie zaś udziel łaski, o którą pokornie proszę za jego wstawiennictwem. Przez Chrystusa Pana naszego. Amen.", "Modlitwa początkowa" },
                    { 2, 1, 1, "[Treść modlitwy z https://wenanty.pl/nowenna/]", "Dzień 1 – Dobre życie" },
                    { 3, 2, 1, "[Treść modlitwy z https://wenanty.pl/nowenna/]", "Dzień 2 – Łaska" },
                    { 4, 3, 1, "[Treść modlitwy z https://wenanty.pl/nowenna/]", "Dzień 3 – Unikanie grzechów" },
                    { 5, 4, 1, "[Treść modlitwy z https://wenanty.pl/nowenna/]", "Dzień 4 – Cierpienie" },
                    { 6, 5, 1, "[Treść modlitwy z https://wenanty.pl/nowenna/]", "Dzień 5 – Wiara" },
                    { 7, 6, 1, "[Treść modlitwy z https://wenanty.pl/nowenna/]", "Dzień 6 – Nadzieja" },
                    { 8, 7, 1, "[Treść modlitwy z https://wenanty.pl/nowenna/]", "Dzień 7 – Modlitwa" },
                    { 9, 8, 1, "[Treść modlitwy z https://wenanty.pl/nowenna/]", "Dzień 8 – Maryja" },
                    { 10, 9, 1, "[Treść modlitwy z https://wenanty.pl/nowenna/]", "Dzień 9 – Niebo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NovenaCompletions_NovenaDayPrayerId",
                table: "NovenaCompletions",
                column: "NovenaDayPrayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NovenaCompletions_NovenaId",
                table: "NovenaCompletions",
                column: "NovenaId");

            migrationBuilder.CreateIndex(
                name: "IX_NovenaDayPrayers_NovenaId_DayNumber",
                table: "NovenaDayPrayers",
                columns: new[] { "NovenaId", "DayNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NovenaCompletions");

            migrationBuilder.DropTable(
                name: "NovenaDayPrayers");

            migrationBuilder.DropTable(
                name: "Novenas");
        }
    }
}
