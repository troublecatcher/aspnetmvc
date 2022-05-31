using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_CRUD.Migrations
{
    public partial class kjlk3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "OrdersInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "OrdersInfo");
        }
    }
}
