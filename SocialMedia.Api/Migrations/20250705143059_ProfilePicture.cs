using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Api.Migrations
{
    /// <inheritdoc />
    public partial class ProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AppUser",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureContentType",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "ProfilePictureContentType",
                table: "AppUser");
        }
    }
}
