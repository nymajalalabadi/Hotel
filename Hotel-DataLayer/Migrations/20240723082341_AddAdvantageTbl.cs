using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddAdvantageTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvantageRooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvantageRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectedRoomToAdvantages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelRoomId = table.Column<long>(type: "bigint", nullable: false),
                    AdvantageRoomId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedRoomToAdvantages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedRoomToAdvantages_AdvantageRooms_AdvantageRoomId",
                        column: x => x.AdvantageRoomId,
                        principalTable: "AdvantageRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedRoomToAdvantages_HotelRooms_HotelRoomId",
                        column: x => x.HotelRoomId,
                        principalTable: "HotelRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectedRoomToAdvantages_AdvantageRoomId",
                table: "SelectedRoomToAdvantages",
                column: "AdvantageRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedRoomToAdvantages_HotelRoomId",
                table: "SelectedRoomToAdvantages",
                column: "HotelRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedRoomToAdvantages");

            migrationBuilder.DropTable(
                name: "AdvantageRooms");
        }
    }
}
