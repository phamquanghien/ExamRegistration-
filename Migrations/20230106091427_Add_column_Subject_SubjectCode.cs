using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamRegistration.Migrations
{
    public partial class Add_column_Subject_SubjectCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubjectCode",
                table: "Subject",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectCode",
                table: "Subject");
        }
    }
}
