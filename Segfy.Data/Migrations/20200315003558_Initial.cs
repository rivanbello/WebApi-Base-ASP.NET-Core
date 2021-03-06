﻿using System;
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
                    youtubeId = table.Column<string>(type: "varchar(200)", nullable: false),
                    Title = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "varchar(200)", nullable: false),
                    IsChannel = table.Column<bool>(type: "boolean", nullable: false),
                    ChannelName = table.Column<string>(type: "varchar(200)", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp", nullable: false)
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
