using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rsvp.Migrations
{
    public partial class mf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_guest",
                table: "guest");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "guest");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "guest",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_guest",
                table: "guest",
                column: "Phone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_guest",
                table: "guest");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "guest",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "guest",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_guest",
                table: "guest",
                column: "Id");
        }
    }
}
