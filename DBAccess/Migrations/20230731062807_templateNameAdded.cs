using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBAccess.Migrations
{
    /// <inheritdoc />
    public partial class templateNameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "CourseTemplete",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TemplateName",
                table: "CourseTemplete",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TemplateName",
                table: "ContactTemplete",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "AboutTemplete",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TemplateName",
                table: "AboutTemplete",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "CourseTemplete");

            migrationBuilder.DropColumn(
                name: "TemplateName",
                table: "CourseTemplete");

            migrationBuilder.DropColumn(
                name: "TemplateName",
                table: "ContactTemplete");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "AboutTemplete");

            migrationBuilder.DropColumn(
                name: "TemplateName",
                table: "AboutTemplete");
        }
    }
}
