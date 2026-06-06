using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace employeeproj.Migrations
{
    /// <inheritdoc />
    public partial class ff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Tasks_TaskId",
                table: "Details");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Details",
                newName: "EmployeeTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Details_TaskId",
                table: "Details",
                newName: "IX_Details_EmployeeTaskId");

            migrationBuilder.CreateTable(
                name: "EmployeeTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmployeeTasks",
                columns: new[] { "Id", "TaskName" },
                values: new object[,]
                {
                    { 1, "MVC" },
                    { 2, "API" },
                    { 3, "React" },
                    { 4, "Angular" },
                    { 5, "MAUI" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Details_EmployeeTasks_EmployeeTaskId",
                table: "Details",
                column: "EmployeeTaskId",
                principalTable: "EmployeeTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_EmployeeTasks_EmployeeTaskId",
                table: "Details");

            migrationBuilder.DropTable(
                name: "EmployeeTasks");

            migrationBuilder.RenameColumn(
                name: "EmployeeTaskId",
                table: "Details",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Details_EmployeeTaskId",
                table: "Details",
                newName: "IX_Details_TaskId");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "TaskName" },
                values: new object[,]
                {
                    { 1, "MVC" },
                    { 2, "API" },
                    { 3, "React" },
                    { 4, "Angular" },
                    { 5, "MAUI" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Tasks_TaskId",
                table: "Details",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
