using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISG.TerminalConfiguration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TerminalSettingsInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clientID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TerminalId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    KioskID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalSettingsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerminalSecurity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminalId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    expirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalSecurity", x => x.id);
                    table.ForeignKey(
                        name: "FK_TerminalSecurity_TerminalSettingsInfo_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "TerminalSettingsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TerminalSecurity_TerminalId",
                table: "TerminalSecurity",
                column: "TerminalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerminalSecurity");

            migrationBuilder.DropTable(
                name: "TerminalSettingsInfo");
        }
    }
}
