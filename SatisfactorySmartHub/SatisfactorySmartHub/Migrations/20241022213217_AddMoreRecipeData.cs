using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatisfactorySmartHub.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreRecipeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a3e1febf-d514-43ab-a7d9-46297d5d4029"), "Wire" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: new Guid("a3e1febf-d514-43ab-a7d9-46297d5d4029"));
        }
    }
}
