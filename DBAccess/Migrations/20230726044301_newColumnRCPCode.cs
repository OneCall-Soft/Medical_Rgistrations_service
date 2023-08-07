using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBAccess.Migrations
{
    /// <inheritdoc />
    public partial class newColumnRCPCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletePart",
                table: "Registrations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RCPCode",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ReadTermsCondition",
                table: "Registrations",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletePart",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "RCPCode",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "ReadTermsCondition",
                table: "Registrations");
        }
    }
}
