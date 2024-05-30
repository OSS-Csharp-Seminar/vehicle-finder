using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VehEngine7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_body_body_id",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_maintenance_maintenance_id",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_body_id",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "body_id",
                table: "vehicle");

            migrationBuilder.RenameColumn(
                name: "maintenance_id",
                table: "vehicle",
                newName: "vehicle_maintenanceId");

            migrationBuilder.RenameColumn(
                name: "engine_id",
                table: "vehicle",
                newName: "vehicle_bodyId");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_maintenance_id",
                table: "vehicle",
                newName: "IX_vehicle_vehicle_maintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_vehicle_bodyId",
                table: "vehicle",
                column: "vehicle_bodyId");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_body_vehicle_bodyId",
                table: "vehicle",
                column: "vehicle_bodyId",
                principalTable: "car_body",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_maintenance_vehicle_maintenanceId",
                table: "vehicle",
                column: "vehicle_maintenanceId",
                principalTable: "car_maintenance",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_body_vehicle_bodyId",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_maintenance_vehicle_maintenanceId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_vehicle_bodyId",
                table: "vehicle");

            migrationBuilder.RenameColumn(
                name: "vehicle_maintenanceId",
                table: "vehicle",
                newName: "maintenance_id");

            migrationBuilder.RenameColumn(
                name: "vehicle_bodyId",
                table: "vehicle",
                newName: "engine_id");

            migrationBuilder.RenameIndex(
                name: "IX_vehicle_vehicle_maintenanceId",
                table: "vehicle",
                newName: "IX_vehicle_maintenance_id");

            migrationBuilder.AddColumn<Guid>(
                name: "body_id",
                table: "vehicle",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_body_id",
                table: "vehicle",
                column: "body_id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_body_body_id",
                table: "vehicle",
                column: "body_id",
                principalTable: "car_body",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_maintenance_maintenance_id",
                table: "vehicle",
                column: "maintenance_id",
                principalTable: "car_maintenance",
                principalColumn: "Id");
        }
    }
}
