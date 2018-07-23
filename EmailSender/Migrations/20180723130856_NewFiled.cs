using Microsoft.EntityFrameworkCore.Migrations;

namespace EmailSender.Migrations
{
    public partial class NewFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "MailStories",
                newName: "SendAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SendAt",
                table: "MailStories",
                newName: "CreateAt");
        }
    }
}
