using Microsoft.EntityFrameworkCore.Migrations;

namespace CV_Send.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Programing_Skills",
                table: "Programer",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Programing_Skills",
                table: "Programer");
        }
    }
}
