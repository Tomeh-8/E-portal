using Microsoft.EntityFrameworkCore.Migrations;

namespace student_management_system.Migrations
{
    public partial class AddingEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "studentCourse",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentCourse_EmployeeId",
                table: "studentCourse",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentCourse_Employee_EmployeeId",
                table: "studentCourse",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentCourse_Employee_EmployeeId",
                table: "studentCourse");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_studentCourse_EmployeeId",
                table: "studentCourse");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "studentCourse");
        }
    }
}
