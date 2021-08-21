using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApiSrc.Migrations
{
    public partial class AddAppLoginInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppLoginId",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Lecturers");

            migrationBuilder.AddColumn<int>(
                name: "AppLoginInfoID",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppLoginInfoID",
                table: "Lecturers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppLoginInfos",
                columns: table => new
                {
                    AppLoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLoginInfos", x => x.AppLoginId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_AppLoginInfoID",
                table: "Students",
                column: "AppLoginInfoID");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_AppLoginInfoID",
                table: "Lecturers",
                column: "AppLoginInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecturers_AppLoginInfos_AppLoginInfoID",
                table: "Lecturers",
                column: "AppLoginInfoID",
                principalTable: "AppLoginInfos",
                principalColumn: "AppLoginId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AppLoginInfos_AppLoginInfoID",
                table: "Students",
                column: "AppLoginInfoID",
                principalTable: "AppLoginInfos",
                principalColumn: "AppLoginId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecturers_AppLoginInfos_AppLoginInfoID",
                table: "Lecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AppLoginInfos_AppLoginInfoID",
                table: "Students");

            migrationBuilder.DropTable(
                name: "AppLoginInfos");

            migrationBuilder.DropIndex(
                name: "IX_Students_AppLoginInfoID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Lecturers_AppLoginInfoID",
                table: "Lecturers");

            migrationBuilder.DropColumn(
                name: "AppLoginInfoID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AppLoginInfoID",
                table: "Lecturers");

            migrationBuilder.AddColumn<int>(
                name: "AppLoginId",
                table: "Lecturers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Lecturers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Lecturers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Lecturers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Lecturers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
