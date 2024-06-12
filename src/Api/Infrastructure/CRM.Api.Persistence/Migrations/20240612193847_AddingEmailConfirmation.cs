using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Api.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingEmailConfirmation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "emailconfirmation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OldEmailAddress = table.Column<string>(type: "text", nullable: false),
                    NewEmailAddress = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailconfirmation", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emailconfirmation",
                schema: "dbo");
        }
    }
}
