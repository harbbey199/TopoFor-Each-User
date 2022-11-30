﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEEK7APIFINALSOULTION.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Starttime",
                table: "Activitives",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Starttime",
                table: "Activitives",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
