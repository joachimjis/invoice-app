using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.ApiHost.Migrations
{
    public partial class removetauxtva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TauxTVA",
                table: "InvoiceLines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TauxTVA",
                table: "InvoiceLines",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
