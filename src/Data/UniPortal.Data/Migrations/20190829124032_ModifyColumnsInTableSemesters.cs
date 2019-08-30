using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniPortal.Data.Migrations
{
    public partial class ModifyColumnsInTableSemesters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "StudentSemesters");

            migrationBuilder.DropColumn(
                name: "isOpen",
                table: "Semesters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenUntil",
                table: "Semesters",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenFrom",
                table: "Semesters",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "Fee",
                table: "Semesters",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PaidAmount",
                table: "StudentSemesters",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenUntil",
                table: "Semesters",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OpenFrom",
                table: "Semesters",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Fee",
                table: "Semesters",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isOpen",
                table: "Semesters",
                nullable: false,
                defaultValue: false);
        }
    }
}
