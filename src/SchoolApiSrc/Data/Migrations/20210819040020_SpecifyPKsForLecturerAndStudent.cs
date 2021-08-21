using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApiSrc.Migrations
{
    public partial class SpecifyPKsForLecturerAndStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "LecturerId",
                table: "courseEnrollments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_courseEnrollments_LecturerId",
                table: "courseEnrollments",
                column: "LecturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_courseEnrollments_Lecturers_LecturerId",
                table: "courseEnrollments",
                column: "LecturerId",
                principalTable: "Lecturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courseEnrollments_Lecturers_LecturerId",
                table: "courseEnrollments");

            migrationBuilder.DropIndex(
                name: "IX_courseEnrollments_LecturerId",
                table: "courseEnrollments");

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

            migrationBuilder.DropColumn(
                name: "LecturerId",
                table: "courseEnrollments");
        }
    }
}
