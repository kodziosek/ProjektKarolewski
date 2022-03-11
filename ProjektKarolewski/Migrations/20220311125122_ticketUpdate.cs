using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektKarolewski.Migrations
{
    public partial class ticketUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Replies_ReplyId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ReplyId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ReplyId",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Replies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Replies_TicketId",
                table: "Replies",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Tickets_TicketId",
                table: "Replies",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Tickets_TicketId",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Replies_TicketId",
                table: "Replies");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Replies");

            migrationBuilder.AddColumn<int>(
                name: "ReplyId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReplyId",
                table: "Tickets",
                column: "ReplyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Replies_ReplyId",
                table: "Tickets",
                column: "ReplyId",
                principalTable: "Replies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
