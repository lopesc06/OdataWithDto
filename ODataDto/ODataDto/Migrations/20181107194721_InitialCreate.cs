using Microsoft.EntityFrameworkCore.Migrations;

namespace ODataDto.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CourseLevel = table.Column<int>(nullable: false),
                    Teacher = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Alias = table.Column<string>(maxLength: 30, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Lastame = table.Column<string>(maxLength: 25, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Class = table.Column<string>(nullable: true),
                    MycourseCourseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Alias);
                    table.ForeignKey(
                        name: "FK_Students_Courses_MycourseCourseName",
                        column: x => x.MycourseCourseName,
                        principalTable: "Courses",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_MycourseCourseName",
                table: "Students",
                column: "MycourseCourseName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
