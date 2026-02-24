using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insurance_crud_api.Migrations
{
    /// <inheritdoc />
    public partial class FixTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Policies",
                table: "Policies");

            migrationBuilder.RenameTable(
                name: "Policies",
                newName: "CrudPolicies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrudPolicies",
                table: "CrudPolicies",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CrudPolicies",
                table: "CrudPolicies");

            migrationBuilder.RenameTable(
                name: "CrudPolicies",
                newName: "Policies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Policies",
                table: "Policies",
                column: "Id");
        }
    }
}
