using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEEK7APIFINALSOULTION.Migrations
{
    /// <inheritdoc />
    public partial class updateAssist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitives_users_UserId",
                table: "Activitives");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Activitives",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activitives_users_UserId",
                table: "Activitives",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitives_users_UserId",
                table: "Activitives");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Activitives",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitives_users_UserId",
                table: "Activitives",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
