using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApiSrc.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { 4000, "Computer Science Dept" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { 4001, "Mathematics Dept" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[] { 4002, "Business and Language Dept" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "DepartmentId", "DepartmentId1" },
                values: new object[,]
                {
                    { 3000, "Data Structure", 4000, null },
                    { 3001, "Calculus", 4001, null },
                    { 3002, "English Conversation", 4002, null }
                });

            migrationBuilder.InsertData(
                table: "Lecturers",
                columns: new[] { "Id", "DepartmentId", "Email", "LecturerType", "Name" },
                values: new object[,]
                {
                    { 2000, 4000, "kim@kkk.com", "Professor", "Kim" },
                    { 2001, 4001, "lee@kkk.com", "Professor", "Lee" },
                    { 2002, 4002, "park@kkk.com", "Professor", "Park" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DepartmentId", "Email", "Name", "StudentType" },
                values: new object[,]
                {
                    { 1000, 4000, "st1@abc.com", "Student1", "Freshman" },
                    { 1001, 4001, "st2@abc.com", "Student2", "Junior" },
                    { 1002, 4002, "st3@abc.com", "Student3", "Senior" }
                });

            migrationBuilder.InsertData(
                table: "CourseAssignments",
                columns: new[] { "CourseId", "LecturerId", "Id" },
                values: new object[,]
                {
                    { 3000, 2000, 0 },
                    { 3001, 2001, 0 },
                    { 3002, 2002, 0 }
                });

            migrationBuilder.InsertData(
                table: "courseEnrollments",
                columns: new[] { "CourseId", "StudentId", "Id" },
                values: new object[,]
                {
                    { 3000, 1000, 0 },
                    { 3001, 1001, 0 },
                    { 3002, 1002, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseAssignments",
                keyColumns: new[] { "CourseId", "LecturerId" },
                keyValues: new object[] { 3000, 2000 });

            migrationBuilder.DeleteData(
                table: "CourseAssignments",
                keyColumns: new[] { "CourseId", "LecturerId" },
                keyValues: new object[] { 3001, 2001 });

            migrationBuilder.DeleteData(
                table: "CourseAssignments",
                keyColumns: new[] { "CourseId", "LecturerId" },
                keyValues: new object[] { 3002, 2002 });

            migrationBuilder.DeleteData(
                table: "courseEnrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3000, 1000 });

            migrationBuilder.DeleteData(
                table: "courseEnrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3001, 1001 });

            migrationBuilder.DeleteData(
                table: "courseEnrollments",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3002, 1002 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3000);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3001);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3002);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 2000);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 2001);

            migrationBuilder.DeleteData(
                table: "Lecturers",
                keyColumn: "Id",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4000);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4001);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4002);
        }
    }
}
