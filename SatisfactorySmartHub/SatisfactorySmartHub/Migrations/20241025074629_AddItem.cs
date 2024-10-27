using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatisfactorySmartHub.Migrations
{
    /// <inheritdoc />
    public partial class AddItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MachineId",
                table: "Recipe",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PowerConsumption = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_MachineId",
                table: "Recipe",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Machine_MachineId",
                table: "Recipe",
                column: "MachineId",
                principalTable: "Machine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Machine_MachineId",
                table: "Recipe");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_MachineId",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Recipe");
        }
    }
}
