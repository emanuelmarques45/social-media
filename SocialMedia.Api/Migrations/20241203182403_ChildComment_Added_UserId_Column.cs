using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChildComment_Added_UserId_Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ChildComment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ChildComment_UserId",
                table: "ChildComment",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildComment_Users_UserId",
                table: "ChildComment",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildComment_Users_UserId",
                table: "ChildComment");

            migrationBuilder.DropIndex(
                name: "IX_ChildComment_UserId",
                table: "ChildComment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChildComment");
        }
    }
}
