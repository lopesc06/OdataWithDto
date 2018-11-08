using Microsoft.EntityFrameworkCore.Migrations;

namespace ODataDto.Migrations
{
    public partial class LastNameFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastame",
                table: "Students",
                newName: "Lastname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Students",
                newName: "Lastame");
        }
    }
}
