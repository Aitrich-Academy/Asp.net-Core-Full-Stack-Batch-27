using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "SystemUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "SystemUsers");

            migrationBuilder.DropColumn(
                name: "OnlineStatus",
                table: "SystemUsers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "SystemUsers");

            migrationBuilder.CreateTable(
                name: "AuthUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnlineStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthUsers_SystemUsers_Id",
                        column: x => x.Id,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthUsers");

            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "SystemUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "SystemUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "OnlineStatus",
                table: "SystemUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "SystemUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
