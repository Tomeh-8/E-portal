using Microsoft.EntityFrameworkCore.Migrations;

namespace student_management_system.Migrations
{
    public partial class ImageFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentInfo_ProfileImage_ImgId",
                table: "studentInfo");

            migrationBuilder.DropIndex(
                name: "IX_studentInfo_ImgId",
                table: "studentInfo");

            migrationBuilder.DropColumn(
                name: "ImgId",
                table: "studentInfo");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "studentInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "studentInfo");

            migrationBuilder.AddColumn<string>(
                name: "ImgId",
                table: "studentInfo",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentInfo_ImgId",
                table: "studentInfo",
                column: "ImgId",
                unique: true,
                filter: "[ImgId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_studentInfo_ProfileImage_ImgId",
                table: "studentInfo",
                column: "ImgId",
                principalTable: "ProfileImage",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
