using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEEK7APIFINALSOULTION.Migrations
{
    /// <inheritdoc />
    public partial class week8update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_users_UserId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_UserId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Activitives",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activitives_UserId",
                table: "Activitives",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitives_users_UserId",
                table: "Activitives",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitives_users_UserId",
                table: "Activitives");

            migrationBuilder.DropIndex(
                name: "IX_Activitives_UserId",
                table: "Activitives");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Activitives");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_UserId",
                table: "users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_users_UserId",
                table: "users",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }
    }
}
