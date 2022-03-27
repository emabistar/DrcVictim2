using Microsoft.EntityFrameworkCore.Migrations;

namespace VictimData.Migrations
{
    public partial class Adding_VictimCategory_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VictimCategory",
                table: "Victims",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VictimCategory",
                table: "Victims");
        }
    }
}
