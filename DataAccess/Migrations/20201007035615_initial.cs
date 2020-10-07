using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    HospitalId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.HospitalId);
                });

            migrationBuilder.CreateTable(
                name: "ItemVendor",
                columns: table => new
                {
                    ItemVendorId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVendor", x => x.ItemVendorId);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    PharmacyId = table.Column<Guid>(nullable: false),
                    HospitalId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.PharmacyId);
                    table.ForeignKey(
                        name: "FK_Pharmacy_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospital",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(nullable: false),
                    ItemVendorId = table.Column<Guid>(nullable: false),
                    ItemNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Upc = table.Column<string>(nullable: true),
                    ItemDescription = table.Column<string>(nullable: true),
                    MinimumOrderQuantity = table.Column<int>(nullable: false),
                    PurchaseUnitOfMeasure = table.Column<string>(nullable: true),
                    ItemCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_ItemVendor_ItemVendorId",
                        column: x => x.ItemVendorId,
                        principalTable: "ItemVendor",
                        principalColumn: "ItemVendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyInventory",
                columns: table => new
                {
                    PharmacyInventoryId = table.Column<Guid>(nullable: false),
                    PharmacyId = table.Column<Guid>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false),
                    ItemNumber = table.Column<int>(nullable: false),
                    QuantityOnHand = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    ReorderQuantity = table.Column<int>(nullable: false),
                    SellingUnitOfMeasure = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyInventory", x => x.PharmacyInventoryId);
                    table.ForeignKey(
                        name: "FK_PharmacyInventory_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PharmacyInventory_Pharmacy_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacy",
                        principalColumn: "PharmacyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemNumber",
                table: "Item",
                column: "ItemNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemVendorId",
                table: "Item",
                column: "ItemVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacy_HospitalId",
                table: "Pharmacy",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyInventory_ItemId",
                table: "PharmacyInventory",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyInventory_PharmacyId",
                table: "PharmacyInventory",
                column: "PharmacyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyInventory");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Pharmacy");

            migrationBuilder.DropTable(
                name: "ItemVendor");

            migrationBuilder.DropTable(
                name: "Hospital");
        }
    }
}
