using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aGate.Migrations
{
    /// <inheritdoc />
    public partial class database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "campaings",
                columns: table => new
                {
                    campaingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    campaingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    campaingStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    campaingEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    campaingBudget = table.Column<int>(type: "int", nullable: false),
                    campaingEstimatedPrice = table.Column<int>(type: "int", nullable: false),
                    campaingStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_campaings", x => x.campaingID);
                });

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    clientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clientAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    clientPhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.clientID);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                columns: table => new
                {
                    staffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staffLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    staffContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs", x => x.staffID);
                });

            migrationBuilder.CreateTable(
                name: "CampaingStaffs",
                columns: table => new
                {
                    CampaingStaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaingID = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaingStaffs", x => x.CampaingStaffID);
                    table.ForeignKey(
                        name: "FK_CampaingStaffs_campaings_CampaingID",
                        column: x => x.CampaingID,
                        principalTable: "campaings",
                        principalColumn: "campaingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaingStaffs_staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "staffs",
                        principalColumn: "staffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffNotes",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoteText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffNotes", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_StaffNotes_staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "staffs",
                        principalColumn: "staffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaingStaffs_CampaingID",
                table: "CampaingStaffs",
                column: "CampaingID");

            migrationBuilder.CreateIndex(
                name: "IX_CampaingStaffs_StaffID",
                table: "CampaingStaffs",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_StaffNotes_StaffID",
                table: "StaffNotes",
                column: "StaffID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaingStaffs");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "StaffNotes");

            migrationBuilder.DropTable(
                name: "campaings");

            migrationBuilder.DropTable(
                name: "staffs");
        }
    }
}
