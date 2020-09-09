using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WouldYouGetItDone.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Criteria = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagKey = table.Column<string>(maxLength: 50, nullable: false),
                    TagValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagKey);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    TypeId = table.Column<int>(maxLength: 100, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GeTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.TypeId);
                    table.ForeignKey(
                        name: "FK_Type_Type_GeTypeId",
                        column: x => x.GeTypeId,
                        principalTable: "Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    GoodsId = table.Column<Guid>(nullable: false, defaultValueSql: "newid()"),
                    GoodsName = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Discount = table.Column<byte>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    Imgs = table.Column<string>(nullable: true),
                    Details = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: true),
                    ReviewScore = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.GoodsId);
                    table.ForeignKey(
                        name: "FK_Goods_Type_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Type",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "GetReviewGoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReviewDay = table.Column<DateTime>(nullable: false),
                    ReviewScore = table.Column<byte>(nullable: false),
                    Criteria = table.Column<int>(nullable: false),
                    GoodsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetReviewGoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GetReviewGoods_Reviews_Criteria",
                        column: x => x.Criteria,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GetReviewGoods_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodsTag",
                columns: table => new
                {
                    TagKey = table.Column<string>(nullable: false),
                    GoodsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsTag", x => new { x.TagKey, x.GoodsId });
                    table.ForeignKey(
                        name: "FK_GoodsTag_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodsTag_Tag_TagKey",
                        column: x => x.TagKey,
                        principalTable: "Tag",
                        principalColumn: "TagKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    GoodsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubImg_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GetReviewGoods_Criteria",
                table: "GetReviewGoods",
                column: "Criteria");

            migrationBuilder.CreateIndex(
                name: "IX_GetReviewGoods_GoodsId",
                table: "GetReviewGoods",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_GoodsName",
                table: "Goods",
                column: "GoodsName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goods_TypeId",
                table: "Goods",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsTag_GoodsId",
                table: "GoodsTag",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_SubImg_GoodsId",
                table: "SubImg",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_GeTypeId",
                table: "Type",
                column: "GeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetReviewGoods");

            migrationBuilder.DropTable(
                name: "GoodsTag");

            migrationBuilder.DropTable(
                name: "SubImg");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Type");
        }
    }
}
