using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.ApiHost.Migrations
{
    public partial class updateinvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontantTTC",
                table: "InvoiceLines");

            migrationBuilder.DropColumn(
                name: "MontantTVA",
                table: "InvoiceLines");

            migrationBuilder.AddColumn<decimal>(
                name: "MontantHT",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantTTC",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantTVA",
                table: "Invoices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TauxTVA",
                table: "InvoiceLines",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "InvoiceLines",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MontantHT",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "MontantTTC",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "MontantTVA",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "TauxTVA",
                table: "InvoiceLines");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "InvoiceLines");

            migrationBuilder.AddColumn<decimal>(
                name: "MontantTTC",
                table: "InvoiceLines",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MontantTVA",
                table: "InvoiceLines",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
