using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace pgSQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OriginalPostId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: true),
                    Content = table.Column<string>(type: "character varying(777)", maxLength: 777, nullable: true),
                    IsRepost = table.Column<bool>(type: "boolean", nullable: false),
                    RepostCount = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_posts_tb_posts_OriginalPostId",
                        column: x => x.OriginalPostId,
                        principalTable: "tb_posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_posts_tb_users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "tb_users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_posts_tb_users_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_posts_AuthorId",
                table: "tb_posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_posts_OriginalPostId",
                table: "tb_posts",
                column: "OriginalPostId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_posts_UserId",
                table: "tb_posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_posts");

            migrationBuilder.DropTable(
                name: "tb_users");
        }
    }
}
