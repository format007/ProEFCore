using Microsoft.EntityFrameworkCore.Migrations;

namespace Ch20.Migrations
{
    public partial class AddProd2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sup",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prods",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Color = table.Column<int>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    SupplierId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prods_Sup_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Sup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prods_SupplierId",
                table: "Prods",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prods");

            migrationBuilder.DropTable(
                name: "Sup");
        }
    }
}
