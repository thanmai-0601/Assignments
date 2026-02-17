using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CountriesAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    SId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CntryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.SId);
                    table.ForeignKey(
                        name: "FK_States_Countries_CntryId",
                        column: x => x.CntryId,
                        principalTable: "Countries",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CId", "CCode", "CName" },
                values: new object[,]
                {
                    { 1, "IND", "India" },
                    { 2, "AUS", "Australia" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "SId", "CntryId", "SName" },
                values: new object[,]
                {
                    { 1, 1, "Odisha" },
                    { 2, 1, "Delhi" },
                    { 3, 2, "New South Wales" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_States_CntryId",
                table: "States",
                column: "CntryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
