using Microsoft.EntityFrameworkCore.Migrations;

namespace student_management_system.Migrations
{
    public partial class addingProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "hobby",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hobby",
                table: "AspNetUsers");
        }
    }
}
