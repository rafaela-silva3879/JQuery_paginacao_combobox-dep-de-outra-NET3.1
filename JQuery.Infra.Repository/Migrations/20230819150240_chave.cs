using Microsoft.EntityFrameworkCore.Migrations;

namespace JQuery.Infra.Repository.Migrations
{
    public partial class chave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FRIEND_STATE_stateIdState",
                table: "FRIEND");

            migrationBuilder.DropIndex(
                name: "IX_FRIEND_stateIdState",
                table: "FRIEND");

            migrationBuilder.DropColumn(
                name: "stateIdState",
                table: "FRIEND");

            migrationBuilder.CreateIndex(
                name: "IX_FRIEND_IDSTATE",
                table: "FRIEND",
                column: "IDSTATE");

            migrationBuilder.AddForeignKey(
                name: "FK_FRIEND_STATE_IDSTATE",
                table: "FRIEND",
                column: "IDSTATE",
                principalTable: "STATE",
                principalColumn: "IDSTATE",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FRIEND_STATE_IDSTATE",
                table: "FRIEND");

            migrationBuilder.DropIndex(
                name: "IX_FRIEND_IDSTATE",
                table: "FRIEND");

            migrationBuilder.AddColumn<int>(
                name: "stateIdState",
                table: "FRIEND",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FRIEND_stateIdState",
                table: "FRIEND",
                column: "stateIdState");

            migrationBuilder.AddForeignKey(
                name: "FK_FRIEND_STATE_stateIdState",
                table: "FRIEND",
                column: "stateIdState",
                principalTable: "STATE",
                principalColumn: "IDSTATE",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
