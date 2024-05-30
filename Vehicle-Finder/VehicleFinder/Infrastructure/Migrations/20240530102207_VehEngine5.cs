using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VehEngine5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_vehicle_vehicle_maintenanceId",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "vehicle_bodyId",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "vehicle_maintenanceId",
                table: "vehicle");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_body_id",
                table: "vehicle",
                column: "body_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_maintenance_id",
                table: "vehicle",
                column: "maintenance_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_vehicle_maintenance_id",
                table: "vehicle");

            migrationBuilder.AddColumn<Guid>(
                name: "vehicle_bodyId",
                table: "vehicle",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "vehicle_maintenanceId",
                table: "vehicle",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_vehicle_bodyId",
                table: "vehicle",
                column: "vehicle_bodyId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_vehicle_maintenanceId",
                table: "vehicle",
                column: "vehicle_maintenanceId");

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
    }
}
