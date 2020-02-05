using Microsoft.EntityFrameworkCore.Migrations;

namespace Ch20.Migrations
{
    public partial class AddReqSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prods_Sup_SupplierId",
                table: "Prods");

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                table: "Prods",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prods_Sup_SupplierId",
                table: "Prods",
                column: "SupplierId",
                principalTable: "Sup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prods_Sup_SupplierId",
                table: "Prods");

            migrationBuilder.AlterColumn<long>(
                name: "SupplierId",
                table: "Prods",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Prods_Sup_SupplierId",
                table: "Prods",
                column: "SupplierId",
                principalTable: "Sup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
