using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBAccess.Migrations
{
    /// <inheritdoc />
    public partial class GallaryGroupForTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GallaryGroupId",
                table: "CourseTemplete",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GallaryGroupId",
                table: "ContactTemplete",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GallaryGroupId",
                table: "AboutTemplete",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GallaryGroupId",
                table: "CourseTemplete");

            migrationBuilder.DropColumn(
                name: "GallaryGroupId",
                table: "ContactTemplete");

            migrationBuilder.DropColumn(
                name: "GallaryGroupId",
                table: "AboutTemplete");
        }
    }
}
