using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactProAltair.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContactDate_0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedName",
                table: "Contacts",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Contacts",
                newName: "CreatedName");
        }
    }
}
