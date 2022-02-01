using Microsoft.EntityFrameworkCore.Migrations;

namespace Grup22.Migrations
{
    public partial class FactoryUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fabrika Kullanıcısı",
                columns: table => new
                {
                    factoryUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    factoryUserEmail = table.Column<string>(maxLength: 30, nullable: false),
                    factoryUserPassword = table.Column<string>(nullable: false),
                    factoryUserName = table.Column<string>(maxLength: 50, nullable: false),
                    factoryUserAdress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrika Kullanıcısı", x => x.factoryUserId);
                });

            migrationBuilder.CreateTable(
                name: "Bayi",
                columns: table => new
                {
                    sellerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sellerEmail = table.Column<string>(maxLength: 30, nullable: false),
                    sellerPassword = table.Column<string>(nullable: false),
                    sellerName = table.Column<string>(maxLength: 50, nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Bayi_factoryUserId",
                table: "Bayi",
                column: "factoryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ürün_factoryUserId",
                table: "Ürün",
                column: "factoryUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bayi");

            migrationBuilder.DropTable(
                name: "Ürün");

            migrationBuilder.DropTable(
                name: "Fabrika Kullanıcısı");
        }
    }
}
