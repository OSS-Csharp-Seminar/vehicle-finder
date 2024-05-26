using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "vehicle_id",
                table: "car_engine",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_car_engine_vehicle_id",
                table: "car_engine",
                column: "vehicle_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_car_engine_vehicle_vehicle_id",
                table: "car_engine",
                column: "vehicle_id",
                principalTable: "vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_engine_vehicle_vehicle_id",
                table: "car_engine");

            migrationBuilder.DropIndex(
                name: "IX_car_engine_vehicle_id",
                table: "car_engine");

            migrationBuilder.DropColumn(
                name: "vehicle_id",
                table: "car_engine");
        }
    }
}
