using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrackerTwo.Data.Migrations
{
    public partial class AddLicences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    User = table.Column<string>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    ExpiresOn = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenceItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenceItems");
        }
    }
}
