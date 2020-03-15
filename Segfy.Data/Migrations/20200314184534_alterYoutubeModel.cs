using Microsoft.EntityFrameworkCore.Migrations;

namespace Segfy.Data.Migrations
{
    public partial class alterYoutubeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "Yoututbe",
                newName: "youtubeId");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUrl",
                table: "Yoututbe",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailUrl",
                table: "Yoututbe");

            migrationBuilder.RenameColumn(
                name: "youtubeId",
                table: "Yoututbe",
                newName: "Thumbnail");
        }
    }
}
