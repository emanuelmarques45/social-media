using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Api.Migrations
{
    /// <inheritdoc />
    public partial class Likes_Primary_Key : Migration
    {
        private static readonly string[] Columns = new[] { "PostId", "UserId" };

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            _ = migrationBuilder.DropIndex(
                name: "IX_Likes_PostId",
                table: "Likes");

            _ = migrationBuilder.DropColumn(
                name: "Id",
                table: "Likes");

            _ = migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                columns: Columns);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            _ = migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            _ = migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");
        }
    }
}
