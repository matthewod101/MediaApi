using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MediaItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 150, nullable: true),
                    Kind = table.Column<string>(nullable: true),
                    RecommendedBy = table.Column<string>(nullable: true),
                    Consumed = table.Column<bool>(nullable: false),
                    DateConsumed = table.Column<DateTime>(nullable: true),
                    Removed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MediaItems",
                columns: new[] { "Id", "Consumed", "DateConsumed", "Kind", "RecommendedBy", "Removed", "Title" },
                values: new object[] { 1, false, null, "game", "Henry", false, "Super Mario Kart" });

            migrationBuilder.InsertData(
                table: "MediaItems",
                columns: new[] { "Id", "Consumed", "DateConsumed", "Kind", "RecommendedBy", "Removed", "Title" },
                values: new object[] { 2, true, new DateTime(2020, 6, 18, 13, 29, 30, 32, DateTimeKind.Local).AddTicks(9704), "show", "Donna", false, "Game ofThrones" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MediaItems");
        }
    }
}
