using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestmentsPortfolioAPI.Migrations
{
    public partial class NewStockModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Stock");

            migrationBuilder.AddColumn<DateTime>(
                name: "QuoteDate",
                table: "Stock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuoteDate",
                table: "Stock");

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Stock",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
