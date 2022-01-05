using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ETCWebApi.Migrations
{
    public partial class updatedUserMOdel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoiningDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PostedBy",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostedOn",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "JoiningDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "Users");
        }
    }
}
