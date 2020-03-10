using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Segfy.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yoututbe",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    Thumbnail = table.Column<string>(type: "varchar(200)", nullable: false),
                    IsChannel = table.Column<bool>(type: "bit", nullable: false),
                    ChannelName = table.Column<string>(type: "varchar(200)", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yoututbe", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yoututbe");
        }
    }
}
