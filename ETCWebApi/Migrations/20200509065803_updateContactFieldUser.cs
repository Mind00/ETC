using Microsoft.EntityFrameworkCore.Migrations;

namespace ETCWebApi.Migrations
{
    public partial class updateContactFieldUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactNo",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactNo",
                table: "Users");
        }
    }
}
