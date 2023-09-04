using Microsoft.EntityFrameworkCore.Migrations;

namespace JQuery.Infra.Repository.Migrations
{
    public partial class coluna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FRIEND_State_stateIdState",
                table: "FRIEND");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                table: "State");

            migrationBuilder.RenameTable(
                name: "State",
                newName: "STATE");

            migrationBuilder.RenameColumn(
                name: "StateAcronym",
                table: "STATE",
                newName: "STATEACRONYM");

            migrationBuilder.RenameColumn(
                name: "IdState",
                table: "STATE",
                newName: "IDSTATE");

            migrationBuilder.AlterColumn<string>(
                name: "STATEACRONYM",
                table: "STATE",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_STATE",
                table: "STATE",
                column: "IDSTATE");

            migrationBuilder.AddForeignKey(
                name: "FK_FRIEND_STATE_stateIdState",
                table: "FRIEND",
                column: "stateIdState",
                principalTable: "STATE",
                principalColumn: "IDSTATE",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FRIEND_STATE_stateIdState",
                table: "FRIEND");

            migrationBuilder.DropPrimaryKey(
                name: "PK_STATE",
                table: "STATE");

            migrationBuilder.RenameTable(
                name: "STATE",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "STATEACRONYM",
                table: "State",
                newName: "StateAcronym");

            migrationBuilder.RenameColumn(
                name: "IDSTATE",
                table: "State",
                newName: "IdState");

            migrationBuilder.AlterColumn<string>(
                name: "StateAcronym",
                table: "State",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                table: "State",
                column: "IdState");

            migrationBuilder.AddForeignKey(
                name: "FK_FRIEND_State_stateIdState",
                table: "FRIEND",
                column: "stateIdState",
                principalTable: "State",
                principalColumn: "IdState",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
