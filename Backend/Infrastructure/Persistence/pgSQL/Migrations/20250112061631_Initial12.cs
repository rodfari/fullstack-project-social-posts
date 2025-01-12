using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pgSQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepostCount",
                table: "tb_posts",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Post",
                type: "character varying(777)",
                maxLength: 777,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(777)",
                oldMaxLength: 777,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepostCount",
                table: "tb_posts");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Post",
                type: "character varying(777)",
                maxLength: 777,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(777)",
                oldMaxLength: 777);
        }
    }
}
