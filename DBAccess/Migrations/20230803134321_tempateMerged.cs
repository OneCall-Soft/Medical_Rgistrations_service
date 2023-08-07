using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBAccess.Migrations
{
    /// <inheritdoc />
    public partial class tempateMerged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AboutTemplete");

            //migrationBuilder.DropTable(
            //    name: "ContactTemplete");

            //migrationBuilder.DropTable(
            //    name: "CourseTemplete");

            migrationBuilder.CreateTable(
                name: "Templetes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HtmlContent = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    GallaryGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templetes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Templetes");


        }
    }
}
