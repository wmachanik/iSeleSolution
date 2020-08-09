using Microsoft.EntityFrameworkCore.Migrations;

namespace iSele.Services.Migrations
{
    public partial class DbV11AddOrderFFFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderFulfillments_OrderID",
                schema: "iSele",
                table: "Orders",
                column: "OrderID",
                principalSchema: "iSele",
                principalTable: "OrderFulfillments",
                principalColumn: "OrderFulfillmentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderFulfillments_OrderID",
                schema: "iSele",
                table: "Orders");
        }
    }
}
