using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SatisfactorySmartHub.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Recipe",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05cd0d20-dc9d-4d5e-b798-4fcd4a9f90cc"), "Iron Rod" },
                    { new Guid("75121144-cdbf-4a3b-a859-ccf80d8664b6"), "Iron Plate" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: new Guid("05cd0d20-dc9d-4d5e-b798-4fcd4a9f90cc"));

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: new Guid("75121144-cdbf-4a3b-a859-ccf80d8664b6"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Recipe");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }
    }
}
