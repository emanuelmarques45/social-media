using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Api.Migrations
{
    /// <inheritdoc />
    public partial class Follower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Follower",
                columns: table => new
                {
                    FollowerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowingId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follower", x => new { x.FollowerId, x.FollowingId });
                    table.ForeignKey(
                        name: "FK_Follower_Users_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Follower_Users_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Follower_FollowingId",
                table: "Follower",
                column: "FollowingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follower");
        }
    }
}
