using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TTask.Migrations
{
    /// <inheritdoc />
    public partial class tasks_redacted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectKey",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectKey",
                table: "Tasks",
                column: "ProjectKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectKey",
                table: "Tasks",
                column: "ProjectKey",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectKey",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectKey",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProjectKey",
                table: "Tasks");
        }
    }
}
