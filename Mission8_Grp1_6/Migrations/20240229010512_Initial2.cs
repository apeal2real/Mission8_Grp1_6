using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mission8_Grp1_6.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskID", "Category", "Completed", "DueDate", "Quadrant", "TaskName" },
                values: new object[,]
                {
                    { 1, "Home", false, null, 1, "Task 1 Name" },
                    { 2, "School", false, null, 2, "Task 2 Name" },
                    { 3, "Work", false, null, 3, "Task 3 Name" },
                    { 4, "Church", false, null, 4, "Task 4 Name" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskID",
                keyValue: 4);
        }
    }
}
