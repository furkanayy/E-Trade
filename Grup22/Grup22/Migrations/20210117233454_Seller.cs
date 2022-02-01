using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grup22.Migrations
{
    public partial class Seller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bayi",
                columns: table => new
                {
                    sellerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sellerEmail = table.Column<string>(maxLength: 30, nullable: false),
                    sellerPassword = table.Column<string>(nullable: false),
                    sellerName = table.Column<string>(maxLength: 50, nullable: false),
                    sellerOwnersName = table.Column<string>(maxLength: 50, nullable: false),
                    sellerCityName = table.Column<string>(maxLength: 100, nullable: false),
                    sellerTownName = table.Column<string>(maxLength: 50, nullable: false),
                    sellerAdress = table.Column<string>(nullable: false),
                    factoryUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bayi", x => x.sellerId);
                    table.ForeignKey(
                        name: "FK_Bayi_Fabrika Kullanıcısı_factoryUserId",
                        column: x => x.factoryUserId,
                        principalTable: "Fabrika Kullanıcısı",
                        principalColumn: "factoryUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ürün",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(maxLength: 30, nullable: false),
                    productDescription = table.Column<string>(nullable: false),
                    productStock = table.Column<int>(nullable: false),
                    productPrice = table.Column<double>(nullable: false),
                    productImageUrl = table.Column<string>(nullable: true),
                    factoryUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ürün", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Ürün_Fabrika Kullanıcısı_factoryUserId",
                        column: x => x.factoryUserId,
                        principalTable: "Fabrika Kullanıcısı",
                        principalColumn: "factoryUserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Bayi_factoryUserId",
                table: "Bayi",
                column: "factoryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ürün_factoryUserId",
                table: "Ürün",
                column: "factoryUserId");

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

            migrationBuilder.DropTable(
                name: "Ürün");

            migrationBuilder.DropTable(
                name: "Bayi");
        }
    }
}
