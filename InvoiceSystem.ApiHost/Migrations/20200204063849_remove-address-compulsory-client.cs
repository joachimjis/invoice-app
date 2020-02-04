using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.ApiHost.Migrations
{
    public partial class removeaddresscompulsoryclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdressePhysique",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdressePhysique",
                table: "Clients",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
