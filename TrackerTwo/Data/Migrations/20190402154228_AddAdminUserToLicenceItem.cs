using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackerTwo.Data.Migrations
{
    public partial class AddAdminUserToLicenceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminUser",
                table: "LicenceItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminUser",
                table: "LicenceItems");
        }
    }
}
