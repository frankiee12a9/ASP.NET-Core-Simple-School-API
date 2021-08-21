using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApiSrc.Migrations
{
    public partial class AddHashedPasswored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "AppLoginInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "AppLoginInfos");
        }
    }
}
