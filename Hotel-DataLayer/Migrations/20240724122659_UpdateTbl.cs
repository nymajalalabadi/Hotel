using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "Hotels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "Hotels",
                type: "datetime2",
                nullable: true);
        }
    }
}
