using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRanktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserRankId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserRanks",
                columns: table => new
                {
                    UserRankId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRanks", x => x.UserRankId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRankId",
                table: "Users",
                column: "UserRankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRanks_UserRankId",
                table: "Users",
                column: "UserRankId",
                principalTable: "UserRanks",
                principalColumn: "UserRankId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRanks_UserRankId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserRanks");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserRankId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRankId",
                table: "Users");
        }
    }
}
