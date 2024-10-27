using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatisfactorySmartHub.Migrations
{
    /// <inheritdoc />
    public partial class AddCompleteRecipeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("bb7bde8d-b9ce-4d68-a852-b16e621fa3a6"), "Iron Plate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("bb7bde8d-b9ce-4d68-a852-b16e621fa3a6"));
        }
    }
}
