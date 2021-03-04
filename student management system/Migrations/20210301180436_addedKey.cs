using Microsoft.EntityFrameworkCore.Migrations;

namespace student_management_system.Migrations
{
    public partial class addedKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefId",
                table: "studentCourse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentStudentCourse",
                columns: table => new
                {
                    StudentCoursesId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStudentCourse", x => new { x.StudentCoursesId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_StudentStudentCourse_studentCourse_StudentCoursesId",
                        column: x => x.StudentCoursesId,
                        principalTable: "studentCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStudentCourse_studentInfo_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "studentInfo",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentStudentCourse_StudentsStudentId",
                table: "StudentStudentCourse",
                column: "StudentsStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentStudentCourse");

            migrationBuilder.DropColumn(
                name: "RefId",
                table: "studentCourse");
        }
    }
}
