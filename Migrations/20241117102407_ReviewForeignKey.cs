using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WanderRoots_backend.Migrations
{
    /// <inheritdoc />
    public partial class ReviewForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Countries_CountryId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "uuid",
                table: "Reviews",
                newName: "Uuid");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Reviews",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Reviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ArticleId",
                table: "Reviews",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Id",
                table: "Articles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Articles_ArticleId",
                table: "Reviews",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Countries_CountryId",
                table: "Reviews",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Articles_ArticleId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Countries_CountryId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ArticleId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Articles_Id",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Uuid",
                table: "Reviews",
                newName: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Reviews",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Countries_CountryId",
                table: "Reviews",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
