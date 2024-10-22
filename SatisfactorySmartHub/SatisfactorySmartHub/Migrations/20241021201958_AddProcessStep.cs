using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SatisfactorySmartHub.Migrations
{
    /// <inheritdoc />
    public partial class AddProcessStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BranchId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecipeId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Target_ItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    Target_Amount = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessStep_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessStep_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MachineryConfigItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ClockSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    ProcessStepId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineryConfigItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineryConfigItem_ProcessStep_ProcessStepId",
                        column: x => x.ProcessStepId,
                        principalTable: "ProcessStep",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineryConfigItem_ProcessStepId",
                table: "MachineryConfigItem",
                column: "ProcessStepId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStep_BranchId",
                table: "ProcessStep",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStep_RecipeId",
                table: "ProcessStep",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineryConfigItem");

            migrationBuilder.DropTable(
                name: "ProcessStep");

            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
