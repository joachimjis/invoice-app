using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceSystem.ApiHost.Migrations
{
    public partial class UpdateParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Parametres");

            migrationBuilder.CreateIndex(
                name: "IX_Parametres_UserId",
                table: "Parametres",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parametres_Users_UserId",
                table: "Parametres",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parametres_Users_UserId",
                table: "Parametres");

            migrationBuilder.DropIndex(
                name: "IX_Parametres_UserId",
                table: "Parametres");

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Parametres",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
