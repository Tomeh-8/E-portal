using Microsoft.EntityFrameworkCore.Migrations;

namespace student_management_system.Migrations
{
    public partial class ModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentCourse_AspNetUsers_EmployeeId",
                table: "studentCourse");

            migrationBuilder.DropTable(
                name: "studentBiodata");

            migrationBuilder.DropIndex(
                name: "IX_studentCourse_EmployeeId",
                table: "studentCourse");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "studentCourse");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "hobby",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "studentInfo",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StateOfOrigin = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentInfo", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_studentInfo_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentInfo");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "studentCourse",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hobby",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "studentBiodata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentBiodata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentBiodata_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentCourse_EmployeeId",
                table: "studentCourse",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_studentBiodata_EmployeeId",
                table: "studentBiodata",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentCourse_AspNetUsers_EmployeeId",
                table: "studentCourse",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
