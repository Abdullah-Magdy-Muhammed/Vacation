using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacation.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateInVaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_Departments_EmployeeId",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_EmployeeId",
                table: "Vacations");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Vacations");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_DepartmentId",
                table: "Vacations",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_Departments_DepartmentId",
                table: "Vacations",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacations_Departments_DepartmentId",
                table: "Vacations");

            migrationBuilder.DropIndex(
                name: "IX_Vacations_DepartmentId",
                table: "Vacations");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Vacations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_EmployeeId",
                table: "Vacations",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacations_Departments_EmployeeId",
                table: "Vacations",
                column: "EmployeeId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
