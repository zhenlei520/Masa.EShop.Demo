using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Masa.EShop.Service.Catalog.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogBrand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Creator = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modifier = table.Column<int>(type: "INTEGER", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationEventLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    TimesSent = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    TransactionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RowVersion = table.Column<string>(type: "TEXT", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationEventLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    PictureFileName = table.Column<string>(type: "TEXT", nullable: true),
                    CatalogTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CatalogBrandId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AvailableStock = table.Column<int>(type: "INTEGER", nullable: false),
                    RestockThreshold = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxStockThreshold = table.Column<int>(type: "INTEGER", nullable: false),
                    Creator = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modifier = table.Column<int>(type: "INTEGER", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogBrand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catalog_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogBrandId",
                table: "Catalog",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalog_CatalogTypeId",
                table: "Catalog",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventId_Version",
                table: "IntegrationEventLog",
                columns: new[] { "EventId", "RowVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_State_MTime",
                table: "IntegrationEventLog",
                columns: new[] { "State", "ModificationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_State_TimesSent_MTime",
                table: "IntegrationEventLog",
                columns: new[] { "State", "TimesSent", "ModificationTime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropTable(
                name: "IntegrationEventLog");

            migrationBuilder.DropTable(
                name: "CatalogBrand");

            migrationBuilder.DropTable(
                name: "CatalogType");
        }
    }
}
