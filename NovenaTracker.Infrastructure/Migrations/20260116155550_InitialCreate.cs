using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NovenaTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Description = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: false),
                    DaysDuration = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novenas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NovenaCompletions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NovenaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DayNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovenaCompletions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NovenaCompletions_Novenas_NovenaId",
                        column: x => x.NovenaId,
                        principalTable: "Novenas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Novenas",
                columns: new[] { "Id", "CreatedDate", "DaysDuration", "Description", "Title" },
                values: new object[] { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "A nine-day prayer to Our Lady of Perpetual Help", "Novena to Our Lady of Perpetual Help" });

            migrationBuilder.InsertData(
                table: "NovenaDayPrayers",
                columns: new[] { "Id", "DayNumber", "NovenaId", "PrayerText", "PrayerTitle" },
                values: new object[,]
                {
                    { 1, 1, 1, "O Mother of Perpetual Help, grant that I may ever invoke your powerful name...", "Day 1 - Trust in Mary" },
                    { 2, 2, 1, "O Mary, you are the hope of Christians, hear the prayer of a sinner who loves you tenderly...", "Day 2 - Hope in Mary" },
                    { 3, 3, 1, "O Mother of Perpetual Help, I come to you with confidence and love...", "Day 3 - Love for Mary" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NovenaCompletions_NovenaId_DayNumber",
                table: "NovenaCompletions",
                columns: new[] { "NovenaId", "DayNumber" },
                unique: true);

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
