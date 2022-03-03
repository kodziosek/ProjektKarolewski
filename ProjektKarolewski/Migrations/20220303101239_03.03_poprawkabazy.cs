using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektKarolewski.Migrations
{
    public partial class _0303_poprawkabazy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.AlterColumn<string>(
                name: "Scan",
                table: "Inspections",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TicketStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: false),
                    ReplyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplyProtocol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_TicketStatuses_TicketStatusId",
                        column: x => x.TicketStatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    ReplyId = table.Column<int>(type: "int", nullable: false),
                    TicketStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Replies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Replies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TicketStatuses_TicketStatusId",
                        column: x => x.TicketStatusId,
                        principalTable: "TicketStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Replies_TicketStatusId",
                table: "Replies",
                column: "TicketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DeviceId",
                table: "Tickets",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReplyId",
                table: "Tickets",
                column: "ReplyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketStatusId",
                table: "Tickets",
                column: "TicketStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "TicketStatuses");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Scan",
                table: "Inspections",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairDate = table.Column<DateTime>(type: "datetime2", maxLength: 30, nullable: false),
                    RepairDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairProtocol = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    FaultDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaultDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faults_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faults_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faults_DeviceId",
                table: "Faults",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_RepairId",
                table: "Faults",
                column: "RepairId",
                unique: true);
        }
    }
}
