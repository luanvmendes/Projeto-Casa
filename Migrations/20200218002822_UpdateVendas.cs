using Microsoft.EntityFrameworkCore.Migrations;

namespace CasaShow.Migrations
{
    public partial class UpdateVendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaVendas_Vendas_VendaId",
                table: "ListaVendas");

            migrationBuilder.DropIndex(
                name: "IX_ListaVendas_VendaId",
                table: "ListaVendas");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "ListaVendas");

            migrationBuilder.AddColumn<int>(
                name: "VendasId",
                table: "ListaVendas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListaVendas_VendasId",
                table: "ListaVendas",
                column: "VendasId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaVendas_Vendas_VendasId",
                table: "ListaVendas",
                column: "VendasId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaVendas_Vendas_VendasId",
                table: "ListaVendas");

            migrationBuilder.DropIndex(
                name: "IX_ListaVendas_VendasId",
                table: "ListaVendas");

            migrationBuilder.DropColumn(
                name: "VendasId",
                table: "ListaVendas");

            migrationBuilder.AddColumn<int>(
                name: "VendaId",
                table: "ListaVendas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListaVendas_VendaId",
                table: "ListaVendas",
                column: "VendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaVendas_Vendas_VendaId",
                table: "ListaVendas",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
