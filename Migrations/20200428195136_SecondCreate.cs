using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkHoursTracker.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Time_Employee_EmployeeId",
                table: "Time");

            migrationBuilder.DropIndex(
                name: "IX_Time_EmployeeId",
                table: "Time");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentTimeId",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTimeId",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Time_EmployeeId",
                table: "Time",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Time_Employee_EmployeeId",
                table: "Time",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
