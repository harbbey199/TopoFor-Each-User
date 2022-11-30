using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEEK7APIFINALSOULTION.Migrations
{
    /// <inheritdoc />
    public partial class fifty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Activitives",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Activitives",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Activitives",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Activitives",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
