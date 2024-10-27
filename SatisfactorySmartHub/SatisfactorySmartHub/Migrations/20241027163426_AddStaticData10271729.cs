using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SatisfactorySmartHub.Migrations
{
    /// <inheritdoc />
    public partial class AddStaticData10271729 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corporations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PowerConsumption = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CorporationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Corporations_CorporationId",
                        column: x => x.CorporationId,
                        principalTable: "Corporations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MachineId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ByProducts",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecipeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ByProducts", x => new { x.RecipeId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ByProducts_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ByProducts_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecipeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => new { x.RecipeId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_Ingredients_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MainProducts",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecipeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainProducts", x => new { x.RecipeId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_MainProducts_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainProducts_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProcessSteps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BranchId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RecipeId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessSteps_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProcessSteps_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MachineConfigItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ClockSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    ProcessStepId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineConfigItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineConfigItems_ProcessSteps_ProcessStepId",
                        column: x => x.ProcessStepId,
                        principalTable: "ProcessSteps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProcessStepTargets",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProcessStepId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessStepTargets", x => new { x.ProcessStepId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_ProcessStepTargets_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessStepTargets_ProcessSteps_ProcessStepId",
                        column: x => x.ProcessStepId,
                        principalTable: "ProcessSteps",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6c944ca5-c6ba-4df4-a08e-c06134ba1472"), "Iron Ore" },
                    { new Guid("bb7bde8d-b9ce-4d68-a852-b16e621fa3a6"), "Iron Plate" },
                    { new Guid("be5c74ec-52aa-400c-a1b4-3fd3ac9a5ee5"), "Iron Ingot" }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "Name", "PowerConsumption" },
                values: new object[,]
                {
                    { new Guid("629893a3-3ae2-408f-8af5-70bcea9c1d19"), "Smelter", 4 },
                    { new Guid("9a874da3-3ea4-427d-8552-fc26dccba215"), "Constructor", 4 }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "MachineId", "Name" },
                values: new object[,]
                {
                    { new Guid("34f401c1-1fbf-4d31-aff2-f04fa40f1831"), new Guid("9a874da3-3ea4-427d-8552-fc26dccba215"), "Iron Plate" },
                    { new Guid("6b95911b-3711-470a-84ff-f843825eb3e6"), new Guid("629893a3-3ae2-408f-8af5-70bcea9c1d19"), "Iron Ingot" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[,]
                {
                    { new Guid("be5c74ec-52aa-400c-a1b4-3fd3ac9a5ee5"), new Guid("34f401c1-1fbf-4d31-aff2-f04fa40f1831"), 3m },
                    { new Guid("6c944ca5-c6ba-4df4-a08e-c06134ba1472"), new Guid("6b95911b-3711-470a-84ff-f843825eb3e6"), 1m }
                });

            migrationBuilder.InsertData(
                table: "MainProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[,]
                {
                    { new Guid("bb7bde8d-b9ce-4d68-a852-b16e621fa3a6"), new Guid("34f401c1-1fbf-4d31-aff2-f04fa40f1831"), 2m },
                    { new Guid("be5c74ec-52aa-400c-a1b4-3fd3ac9a5ee5"), new Guid("6b95911b-3711-470a-84ff-f843825eb3e6"), 1m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CorporationId",
                table: "Branches",
                column: "CorporationId");

            migrationBuilder.CreateIndex(
                name: "IX_ByProducts_ItemId",
                table: "ByProducts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ItemId",
                table: "Ingredients",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineConfigItems_ProcessStepId",
                table: "MachineConfigItems",
                column: "ProcessStepId");

            migrationBuilder.CreateIndex(
                name: "IX_MainProducts_ItemId",
                table: "MainProducts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MainProducts_RecipeId",
                table: "MainProducts",
                column: "RecipeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessSteps_BranchId",
                table: "ProcessSteps",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessSteps_RecipeId",
                table: "ProcessSteps",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStepTargets_ItemId",
                table: "ProcessStepTargets",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessStepTargets_ProcessStepId",
                table: "ProcessStepTargets",
                column: "ProcessStepId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MachineId",
                table: "Recipes",
                column: "MachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ByProducts");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "MachineConfigItems");

            migrationBuilder.DropTable(
                name: "MainProducts");

            migrationBuilder.DropTable(
                name: "ProcessStepTargets");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ProcessSteps");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Corporations");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
