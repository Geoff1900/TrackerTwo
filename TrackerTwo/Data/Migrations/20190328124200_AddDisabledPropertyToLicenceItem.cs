using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackerTwo.Data.Migrations
{
    public partial class AddDisabledPropertyToLicenceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "LicenceItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "LicenceItems");
        }
    }
}
