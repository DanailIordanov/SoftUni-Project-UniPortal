using Microsoft.EntityFrameworkCore.Migrations;

namespace UniPortal.Data.Migrations
{
    public partial class AddColumnPasswordToTableCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Courses");
        }
    }
}
