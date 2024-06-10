using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingEmailConfirmed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                schema: "dbo",
                table: "users",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "dbo",
                table: "users");
        }
    }
}
