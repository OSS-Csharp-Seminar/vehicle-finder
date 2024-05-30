using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VehEngine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "engine_id",
                table: "vehicle",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "vehicle_engineId",
                table: "vehicle",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_vehicle_engineId",
                table: "vehicle",
                column: "vehicle_engineId");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_engine_vehicle_engineId",
                table: "vehicle",
                column: "vehicle_engineId",
                principalTable: "car_engine",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_engine_vehicle_engineId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_vehicle_engineId",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "vehicle_engineId",
                table: "vehicle");

            migrationBuilder.AlterColumn<Guid>(
                name: "engine_id",
                table: "vehicle",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }
    }
}
