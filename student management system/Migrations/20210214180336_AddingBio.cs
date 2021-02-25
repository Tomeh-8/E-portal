using Microsoft.EntityFrameworkCore.Migrations;

namespace student_management_system.Migrations
{
    public partial class AddingBio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "studentBiodata",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentBiodata_EmployeeId",
                table: "studentBiodata",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentBiodata_Employee_EmployeeId",
                table: "studentBiodata",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentBiodata_Employee_EmployeeId",
                table: "studentBiodata");

            migrationBuilder.DropIndex(
                name: "IX_studentBiodata_EmployeeId",
                table: "studentBiodata");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "studentBiodata");
        }
    }
}
