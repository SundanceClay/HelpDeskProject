using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDeskProject.Migrations
{
    public partial class AddedFieldsToTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RequestedBy",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResolvedBy",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestedBy",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ResolvedBy",
                table: "Tickets");
        }
    }
}
