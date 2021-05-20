using Microsoft.EntityFrameworkCore.Migrations;

namespace student_management_system.Migrations
{
    public partial class AddedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "studentInfo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "studentInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageImageId",
                table: "studentInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentInfo_ProfileImageImageId",
                table: "studentInfo",
                column: "ProfileImageImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentInfo_ProfileImage_ProfileImageImageId",
                table: "studentInfo",
                column: "ProfileImageImageId",
                principalTable: "ProfileImage",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentInfo_ProfileImage_ProfileImageImageId",
                table: "studentInfo");

            migrationBuilder.DropIndex(
                name: "IX_studentInfo_ProfileImageImageId",
                table: "studentInfo");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "studentInfo");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "studentInfo");

            migrationBuilder.DropColumn(
                name: "ProfileImageImageId",
                table: "studentInfo");
        }
    }
}
