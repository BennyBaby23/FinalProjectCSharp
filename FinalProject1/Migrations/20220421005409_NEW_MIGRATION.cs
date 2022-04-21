using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject1.Migrations
{
    public partial class NEW_MIGRATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FinalProject",
                table: "FinalProject");

            migrationBuilder.RenameTable(
                name: "FinalProject",
                newName: "AboutProduct");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "BuyerInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "BuyerInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuyerID",
                table: "AboutProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductStoreID",
                table: "AboutProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductoverviewID",
                table: "AboutProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutProduct",
                table: "AboutProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_AboutProduct_BuyerID",
                table: "AboutProduct",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_AboutProduct_ProductoverviewID",
                table: "AboutProduct",
                column: "ProductoverviewID");

            migrationBuilder.CreateIndex(
                name: "IX_AboutProduct_ProductStoreID",
                table: "AboutProduct",
                column: "ProductStoreID");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutProduct_BuyerInfo_BuyerID",
                table: "AboutProduct",
                column: "BuyerID",
                principalTable: "BuyerInfo",
                principalColumn: "BuyerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutProduct_ProuctOverview_ProductoverviewID",
                table: "AboutProduct",
                column: "ProductoverviewID",
                principalTable: "ProuctOverview",
                principalColumn: "ProductoverviewID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutProduct_ProuctSore_ProductStoreID",
                table: "AboutProduct",
                column: "ProductStoreID",
                principalTable: "ProuctSore",
                principalColumn: "ProductStoreID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BuyerInfo_PaymentInfo_BuyerID",
                table: "BuyerInfo",
                column: "BuyerID",
                principalTable: "PaymentInfo",
                principalColumn: "PaymentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutProduct_BuyerInfo_BuyerID",
                table: "AboutProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutProduct_ProuctOverview_ProductoverviewID",
                table: "AboutProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutProduct_ProuctSore_ProductStoreID",
                table: "AboutProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BuyerInfo_PaymentInfo_BuyerID",
                table: "BuyerInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutProduct",
                table: "AboutProduct");

            migrationBuilder.DropIndex(
                name: "IX_AboutProduct_BuyerID",
                table: "AboutProduct");

            migrationBuilder.DropIndex(
                name: "IX_AboutProduct_ProductoverviewID",
                table: "AboutProduct");

            migrationBuilder.DropIndex(
                name: "IX_AboutProduct_ProductStoreID",
                table: "AboutProduct");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "BuyerInfo");

            migrationBuilder.DropColumn(
                name: "BuyerID",
                table: "AboutProduct");

            migrationBuilder.DropColumn(
                name: "ProductStoreID",
                table: "AboutProduct");

            migrationBuilder.DropColumn(
                name: "ProductoverviewID",
                table: "AboutProduct");

            migrationBuilder.RenameTable(
                name: "AboutProduct",
                newName: "FinalProject");

            migrationBuilder.AlterColumn<int>(
                name: "BuyerID",
                table: "BuyerInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinalProject",
                table: "FinalProject",
                column: "ProductID");
        }
    }
}
