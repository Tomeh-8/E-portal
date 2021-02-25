using Microsoft.EntityFrameworkCore.Migrations;

namespace student_management_system.Migrations
{
    public partial class addingModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentBiodata_Employee_EmployeeId",
                table: "studentBiodata");

            migrationBuilder.DropForeignKey(
                name: "FK_studentCourse_Employee_EmployeeId",
                table: "studentCourse");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "studentCourse",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "studentBiodata",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_studentBiodata_AspNetUsers_EmployeeId",
                table: "studentBiodata",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_studentCourse_AspNetUsers_EmployeeId",
                table: "studentCourse",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentBiodata_AspNetUsers_EmployeeId",
                table: "studentBiodata");

            migrationBuilder.DropForeignKey(
                name: "FK_studentCourse_AspNetUsers_EmployeeId",
                table: "studentCourse");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "studentCourse",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "studentBiodata",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_studentBiodata_Employee_EmployeeId",
                table: "studentBiodata",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_studentCourse_Employee_EmployeeId",
                table: "studentCourse",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
