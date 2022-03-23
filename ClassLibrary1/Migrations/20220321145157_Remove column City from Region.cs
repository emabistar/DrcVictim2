using Microsoft.EntityFrameworkCore.Migrations;

namespace VictimData.Migrations
{
    public partial class RemovecolumnCityfromRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Regions");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Victims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Victims");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Regions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
