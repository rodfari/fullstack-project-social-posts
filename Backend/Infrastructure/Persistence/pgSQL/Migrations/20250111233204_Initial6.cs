using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pgSQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repost_User_UserId",
                table: "Repost");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Repost",
                newName: "RepostAuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Repost_UserId",
                table: "Repost",
                newName: "IX_Repost_RepostAuthorId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Repost",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostAuthorId",
                table: "Repost",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Repost_User_RepostAuthorId",
                table: "Repost",
                column: "RepostAuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repost_User_AuthorId",
                table: "Repost");

            migrationBuilder.DropForeignKey(
                name: "FK_Repost_User_RepostAuthorId",
                table: "Repost");

            migrationBuilder.DropIndex(
                name: "IX_Repost_AuthorId",
                table: "Repost");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Repost");

            migrationBuilder.DropColumn(
                name: "PostAuthorId",
                table: "Repost");

            migrationBuilder.RenameColumn(
                name: "RepostAuthorId",
                table: "Repost",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Repost_RepostAuthorId",
                table: "Repost",
                newName: "IX_Repost_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repost_User_UserId",
                table: "Repost",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
