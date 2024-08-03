using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpgredReserveDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReserveDates_HotelRooms_HotelRoomId",
                table: "ReserveDates");

            migrationBuilder.DropIndex(
                name: "IX_ReserveDates_HotelRoomId",
                table: "ReserveDates");

            migrationBuilder.DropColumn(
                name: "HotelRoomId",
                table: "ReserveDates");

            migrationBuilder.CreateIndex(
                name: "IX_ReserveDates_RoomId",
                table: "ReserveDates",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveDates_HotelRooms_RoomId",
                table: "ReserveDates",
                column: "RoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReserveDates_HotelRooms_RoomId",
                table: "ReserveDates");

            migrationBuilder.DropIndex(
                name: "IX_ReserveDates_RoomId",
                table: "ReserveDates");

            migrationBuilder.AddColumn<long>(
                name: "HotelRoomId",
                table: "ReserveDates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ReserveDates_HotelRoomId",
                table: "ReserveDates",
                column: "HotelRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReserveDates_HotelRooms_HotelRoomId",
                table: "ReserveDates",
                column: "HotelRoomId",
                principalTable: "HotelRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
