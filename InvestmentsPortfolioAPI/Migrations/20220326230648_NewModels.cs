using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestmentsPortfolioAPI.Migrations
{
    public partial class NewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuoteDate",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "UnitValue",
                table: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AverageValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockQuote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(type: "int", nullable: true),
                    QuoteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockQuote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockQuote_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockQuote_StockId",
                table: "StockQuote",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "StockQuote");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stock");

            migrationBuilder.AddColumn<DateTime>(
                name: "QuoteDate",
                table: "Stock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "UnitValue",
                table: "Stock",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
