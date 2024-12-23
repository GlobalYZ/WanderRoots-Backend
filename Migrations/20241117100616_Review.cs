﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WanderRoots_backend.Migrations
{
    /// <inheritdoc />
    public partial class Review : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Articles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArticleImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    base64 = table.Column<string>(type: "TEXT", nullable: false),
                    contryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    uuid = table.Column<string>(type: "TEXT", nullable: false),
                    Rate = table.Column<int>(type: "INTEGER", nullable: false),
                    Content = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArticleImages",
                columns: new[] { "Id", "base64", "contryName" },
                values: new object[,]
                {
                    { 1, "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", "default" },
                    { 2, "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", "Australia" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CountryId",
                table: "Articles",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CountryId",
                table: "Reviews",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Countries_CountryId",
                table: "Articles",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Countries_CountryId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleImages");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Name",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CountryId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Articles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
