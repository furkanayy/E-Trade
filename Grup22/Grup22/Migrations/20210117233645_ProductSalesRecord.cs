using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grup22.Migrations
{
    public partial class ProductSalesRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ürün Satış Kaydı",
                columns: table => new
                {
                    salesRecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salesRecordConfirmation = table.Column<bool>(nullable: false),
                    salesRecordAmount = table.Column<int>(nullable: false),
                    orderCreationDate = table.Column<DateTime>(nullable: false),
                    orderCompletionDate = table.Column<DateTime>(nullable: true),
                    sellerId = table.Column<int>(nullable: true),
                    productId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ürün Satış Kaydı", x => x.salesRecordId);
                    table.ForeignKey(
                        name: "FK_Ürün Satış Kaydı_Ürün_productId",
                        column: x => x.productId,
                        principalTable: "Ürün",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ürün Satış Kaydı_Bayi_sellerId",
                        column: x => x.sellerId,
                        principalTable: "Bayi",
                        principalColumn: "sellerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ürün Satış Kaydı_productId",
                table: "Ürün Satış Kaydı",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Ürün Satış Kaydı_sellerId",
                table: "Ürün Satış Kaydı",
                column: "sellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ürün Satış Kaydı");
        }
    }
}
