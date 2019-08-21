using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFrench.Data.Migrations
{
    public partial class RemoveAlternateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_Title",
                table: "Level");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionEnglish",
                table: "Question",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Level",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuestionEnglish",
                table: "Question",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Level",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_Title",
                table: "Level",
                column: "Title");
        }
    }
}
