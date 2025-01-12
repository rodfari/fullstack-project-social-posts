using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pgSQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repost_User_AuthorId",
                table: "Repost");

            migrationBuilder.DropIndex(
                name: "IX_Repost_AuthorId",
                table: "Repost");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Repost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Repost",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repost_AuthorId",
                table: "Repost",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repost_User_AuthorId",
                table: "Repost",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
