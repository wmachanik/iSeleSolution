using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iSele.Services.Migrations
{
    public partial class DBCheckV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecurringOrders_CustomerID",
                schema: "iSele",
                table: "RecurringOrders");

            migrationBuilder.AddColumn<int>(
                name: "GroupItemID",
                schema: "iSele",
                table: "UsedItemGroups",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "iSele",
                table: "UsedItemGroups",
                rowVersion: true,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsedItemGroups_CustomerID",
                schema: "iSele",
                table: "UsedItemGroups",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_UsedItemGroups_GroupItemID",
                schema: "iSele",
                table: "UsedItemGroups",
                column: "GroupItemID");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringOrders_CustomerID",
                schema: "iSele",
                table: "RecurringOrders",
                column: "CustomerID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrices_ItemID",
                schema: "iSele",
                table: "ItemPrices",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPrices_Items_ItemID",
                schema: "iSele",
                table: "ItemPrices",
                column: "ItemID",
                principalSchema: "iSele",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecurringOrders_Customers_CustomerID",
                schema: "iSele",
                table: "RecurringOrders",
                column: "CustomerID",
                principalSchema: "iSele",
                principalTable: "Customers",
                principalColumn: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_UsedItemGroups_Customers_CustomerID",
                schema: "iSele",
                table: "UsedItemGroups",
                column: "CustomerID",
                principalSchema: "iSele",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsedItemGroups_Items_GroupItemID",
                schema: "iSele",
                table: "UsedItemGroups",
                column: "GroupItemID",
                principalSchema: "iSele",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPrices_Items_ItemID",
                schema: "iSele",
                table: "ItemPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_RecurringOrders_Customers_CustomerID",
                schema: "iSele",
                table: "RecurringOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_UsedItemGroups_Customers_CustomerID",
                schema: "iSele",
                table: "UsedItemGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UsedItemGroups_Items_GroupItemID",
                schema: "iSele",
                table: "UsedItemGroups");

            migrationBuilder.DropIndex(
                name: "IX_UsedItemGroups_CustomerID",
                schema: "iSele",
                table: "UsedItemGroups");

            migrationBuilder.DropIndex(
                name: "IX_UsedItemGroups_GroupItemID",
                schema: "iSele",
                table: "UsedItemGroups");

            migrationBuilder.DropIndex(
                name: "IX_RecurringOrders_CustomerID",
                schema: "iSele",
                table: "RecurringOrders");

            migrationBuilder.DropIndex(
                name: "IX_ItemPrices_ItemID",
                schema: "iSele",
                table: "ItemPrices");

            migrationBuilder.DropColumn(
                name: "GroupItemID",
                schema: "iSele",
                table: "UsedItemGroups");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "iSele",
                table: "UsedItemGroups");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringOrders_CustomerID",
                schema: "iSele",
                table: "RecurringOrders",
                column: "CustomerID");
        }
    }
}
