using Microsoft.EntityFrameworkCore.Migrations;

namespace iSele.Services.Migrations
{
    public partial class ChangesToCityAndArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaDaySettings_Cities_CityID",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropIndex(
                name: "IX_AreaDaySettings_AreaName",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropIndex(
                name: "IX_AreaDaySettings_CityID",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropColumn(
                name: "AreaName",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropColumn(
                name: "CityID",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropColumn(
                name: "EstimateDeliveryDaily",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "iSele",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "iSele",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "iSele",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "iSele",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<int>(
                name: "AreaID",
                schema: "iSele",
                table: "AreaDaySettings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaID2",
                schema: "iSele",
                table: "AreaDaySettings",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "EstimateDeliveryDelay",
                schema: "iSele",
                table: "AreaDaySettings",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_AreaDaySettings_AreaID",
                schema: "iSele",
                table: "AreaDaySettings",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_AreaDaySettings_AreaID2",
                schema: "iSele",
                table: "AreaDaySettings",
                column: "AreaID2");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaDaySettings_Areas_AreaID",
                schema: "iSele",
                table: "AreaDaySettings",
                column: "AreaID",
                principalSchema: "iSele",
                principalTable: "Areas",
                principalColumn: "AreaID");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaDaySettings_Areas_AreaID2",
                schema: "iSele",
                table: "AreaDaySettings",
                column: "AreaID2",
                principalSchema: "iSele",
                principalTable: "Areas",
                principalColumn: "AreaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaDaySettings_Areas_AreaID",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_AreaDaySettings_Areas_AreaID2",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropIndex(
                name: "IX_AreaDaySettings_AreaID",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropIndex(
                name: "IX_AreaDaySettings_AreaID2",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropColumn(
                name: "AreaID",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropColumn(
                name: "AreaID2",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.DropColumn(
                name: "EstimateDeliveryDelay",
                schema: "iSele",
                table: "AreaDaySettings");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "iSele",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "iSele",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "iSele",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "iSele",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                schema: "iSele",
                table: "AreaDaySettings",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityID",
                schema: "iSele",
                table: "AreaDaySettings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "EstimateDeliveryDaily",
                schema: "iSele",
                table: "AreaDaySettings",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_AreaDaySettings_AreaName",
                schema: "iSele",
                table: "AreaDaySettings",
                column: "AreaName",
                unique: true,
                filter: "[AreaName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AreaDaySettings_CityID",
                schema: "iSele",
                table: "AreaDaySettings",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaDaySettings_Cities_CityID",
                schema: "iSele",
                table: "AreaDaySettings",
                column: "CityID",
                principalSchema: "iSele",
                principalTable: "Cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
