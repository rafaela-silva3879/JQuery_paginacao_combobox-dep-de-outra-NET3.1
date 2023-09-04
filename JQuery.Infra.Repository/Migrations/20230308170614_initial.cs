using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JQuery.Infra.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    IdState = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateAcronym = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.IdState);
                });

            migrationBuilder.CreateTable(
                name: "FRIEND",
                columns: table => new
                {
                    IDFRIEND = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FRIENDNAME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDSTATE = table.Column<int>(type: "int", nullable: false),
                    stateIdState = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FRIEND", x => x.IDFRIEND);
                    table.ForeignKey(
                        name: "FK_FRIEND_State_stateIdState",
                        column: x => x.stateIdState,
                        principalTable: "State",
                        principalColumn: "IdState",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FRIEND_FRIENDNAME",
                table: "FRIEND",
                column: "FRIENDNAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FRIEND_PHONE",
                table: "FRIEND",
                column: "PHONE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FRIEND_stateIdState",
                table: "FRIEND",
                column: "stateIdState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FRIEND");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
