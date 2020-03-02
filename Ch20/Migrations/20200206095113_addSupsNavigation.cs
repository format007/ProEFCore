using Microsoft.EntityFrameworkCore.Migrations;

namespace Ch20.Migrations
{
    public partial class addSupsNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prods_Sup_SupplierId",
                table: "Prods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sup",
                table: "Sup");

            migrationBuilder.RenameTable(
                name: "Sup",
                newName: "Sups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sups",
                table: "Sups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prods_Sups_SupplierId",
                table: "Prods",
                column: "SupplierId",
                principalTable: "Sups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prods_Sups_SupplierId",
                table: "Prods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sups",
                table: "Sups");

            migrationBuilder.RenameTable(
                name: "Sups",
                newName: "Sup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sup",
                table: "Sup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prods_Sup_SupplierId",
                table: "Prods",
                column: "SupplierId",
                principalTable: "Sup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
