using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektKarolewski.Migrations
{
    public partial class reply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_TicketStatuses_TicketStatusId",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Replies_TicketStatusId",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "TicketStatusId",
                table: "Replies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketStatusId",
                table: "Replies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Replies_TicketStatusId",
                table: "Replies",
                column: "TicketStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_TicketStatuses_TicketStatusId",
                table: "Replies",
                column: "TicketStatusId",
                principalTable: "TicketStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
