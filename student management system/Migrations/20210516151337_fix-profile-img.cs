using Microsoft.EntityFrameworkCore.Migrations;

namespace student_management_system.Migrations
{
    public partial class fixprofileimg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentInfo_ProfileImage_ProfileImageImageId",
                table: "studentInfo");

            migrationBuilder.RenameColumn(
                name: "ProfileImageImageId",
                table: "studentInfo",
                newName: "ImgId");

            migrationBuilder.RenameIndex(
                name: "IX_studentInfo_ProfileImageImageId",
                table: "studentInfo",
                newName: "IX_studentInfo_ImgId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentInfo_ProfileImage_ImgId",
                table: "studentInfo",
                column: "ImgId",
                principalTable: "ProfileImage",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentInfo_ProfileImage_ImgId",
                table: "studentInfo");

            migrationBuilder.RenameColumn(
                name: "ImgId",
                table: "studentInfo",
                newName: "ProfileImageImageId");

            migrationBuilder.RenameIndex(
                name: "IX_studentInfo_ImgId",
                table: "studentInfo",
                newName: "IX_studentInfo_ProfileImageImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentInfo_ProfileImage_ProfileImageImageId",
                table: "studentInfo",
                column: "ProfileImageImageId",
                principalTable: "ProfileImage",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
