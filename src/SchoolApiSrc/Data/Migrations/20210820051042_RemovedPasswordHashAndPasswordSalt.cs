using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApiSrc.Migrations
{
    public partial class RemovedPasswordHashAndPasswordSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AppLoginInfos");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "AppLoginInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "AppLoginInfos",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "AppLoginInfos",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
