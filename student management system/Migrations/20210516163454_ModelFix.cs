using Microsoft.EntityFrameworkCore.Migrations;

namespace student_management_system.Migrations
{
    public partial class ModelFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_studentInfo_ImgId",
                table: "studentInfo");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "ProfileImage",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentInfo_ImgId",
                table: "studentInfo",
                column: "ImgId",
                unique: true,
                filter: "[ImgId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileImage_StudentId",
                table: "ProfileImage",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileImage_studentInfo_StudentId",
                table: "ProfileImage",
                column: "StudentId",
                principalTable: "studentInfo",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileImage_studentInfo_StudentId",
                table: "ProfileImage");

            migrationBuilder.DropIndex(
                name: "IX_studentInfo_ImgId",
                table: "studentInfo");

            migrationBuilder.DropIndex(
                name: "IX_ProfileImage_StudentId",
                table: "ProfileImage");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ProfileImage");

            migrationBuilder.CreateIndex(
                name: "IX_studentInfo_ImgId",
                table: "studentInfo",
                column: "ImgId");
        }
    }
}
