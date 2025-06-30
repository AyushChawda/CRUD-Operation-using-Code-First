using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_Operation_using_Code_First.Migrations
{
    /// <inheritdoc />
    public partial class Student_CRUD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student_List",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "varchar(200)", nullable: false),
                    StudentAge = table.Column<int>(type: "int", nullable: false),
                    StudentGander = table.Column<string>(type: "varchar(20)", nullable: false),
                    StudentClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_List", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_List");
        }
    }
}
