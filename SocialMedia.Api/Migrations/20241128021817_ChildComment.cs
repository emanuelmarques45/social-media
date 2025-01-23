using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChildComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            _ = migrationBuilder.CreateTable(
                name: "ChildComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ChildComment", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_ChildComment_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id");
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_ChildComment_CommentId",
                table: "ChildComment",
                column: "CommentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "ChildComment");

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
    }
}
