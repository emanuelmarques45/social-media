using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Api.Migrations
{
    /// <inheritdoc />
    public partial class CommentParentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Comment",
                type: "int",
                nullable: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentId",
                table: "Comment",
                column: "ParentId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Comment_Comment_ParentId",
                table: "Comment",
                column: "ParentId",
                principalTable: "Comment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_Comment_Comment_ParentId",
                table: "Comment");

            _ = migrationBuilder.DropIndex(
                name: "IX_Comment_ParentId",
                table: "Comment");

            _ = migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Comment");
        }
    }
}
