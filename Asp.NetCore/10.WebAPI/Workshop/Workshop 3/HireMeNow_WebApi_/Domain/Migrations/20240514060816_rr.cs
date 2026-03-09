using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class rr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_JobProviderCompany",
                table: "CompanyUser");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Interviews");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "JobSeekers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Company",
                table: "CompanyUser",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "AuthUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OnlineStatus",
                table: "AuthUser",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MessageGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    newCount = table.Column<int>(type: "int", nullable: false),
                    IsNewMessages = table.Column<bool>(type: "bit", nullable: false),
                    Members = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMember_MessageGroups_MessageGroupId",
                        column: x => x.MessageGroupId,
                        principalTable: "MessageGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MessageGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToGroup = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_MessageGroups_MessageGroupId",
                        column: x => x.MessageGroupId,
                        principalTable: "MessageGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_MessageGroupId",
                table: "GroupMember",
                column: "MessageGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageGroupId",
                table: "Messages",
                column: "MessageGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_JobProviderCompany",
                table: "CompanyUser",
                column: "Company",
                principalTable: "JobProviderCompany",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUser_JobProviderCompany",
                table: "CompanyUser");

            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MessageGroups");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "JobSeekers");

            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "AuthUser");

            migrationBuilder.DropColumn(
                name: "OnlineStatus",
                table: "AuthUser");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "Company",
                table: "CompanyUser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUser_JobProviderCompany",
                table: "CompanyUser",
                column: "Company",
                principalTable: "JobProviderCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
