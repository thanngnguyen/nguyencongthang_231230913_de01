using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nguyencongthang_231230913_de01.Migrations
{
    /// <inheritdoc />
    public partial class nctComputer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nctComputers",
                columns: table => new
                {
                    nctComId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nctComName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nctComPrice = table.Column<double>(type: "float", nullable: true),
                    nctComImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nctComStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nctComputers", x => x.nctComId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nctComputers");
        }
    }
}
