using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmailSender.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailStories",
                columns: table => new
                {
                    MailStoryId = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    Recipients = table.Column<string[]>(nullable: true),
                    MailFrom = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    FailedMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailStories", x => x.MailStoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailStories");
        }
    }
}
