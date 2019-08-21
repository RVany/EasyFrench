using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyFrench.Data.Migrations
{
    public partial class onetomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_ApplicationUserTypeID",
                table: "ApplicationUser");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_ApplicationUserTypeID",
                table: "ApplicationUser",
                column: "ApplicationUserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationUser_ApplicationUserTypeID",
                table: "ApplicationUser");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_ApplicationUserTypeID",
                table: "ApplicationUser",
                column: "ApplicationUserTypeID",
                unique: true);
        }
    }
}
