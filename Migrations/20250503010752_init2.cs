using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lost_and_Found.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FinderEmail",
                table: "FindPhones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FinderEmail",
                table: "FindCards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinderEmail",
                table: "FindPhones");

            migrationBuilder.DropColumn(
                name: "FinderEmail",
                table: "FindCards");
        }
    }
}
