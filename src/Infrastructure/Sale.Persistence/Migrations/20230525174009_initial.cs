using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    origin = table.Column<string>(type: "text", nullable: true),
                    taxRate = table.Column<int>(type: "integer", nullable: true),
                    maxLevel = table.Column<int>(type: "integer", nullable: true),
                    minLevel = table.Column<int>(type: "integer", nullable: true),
                    createDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
