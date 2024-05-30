using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VehEnginev8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_body_vehicle_bodyId",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_engine_vehicle_engineId",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_maintenance_vehicle_maintenanceId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_vehicle_bodyId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_vehicle_engineId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_vehicle_maintenanceId",
                table: "vehicle");

            migrationBuilder.RenameColumn(
                name: "vehicle_maintenanceId",
                table: "vehicle",
                newName: "maintenance_id");

            migrationBuilder.RenameColumn(
                name: "vehicle_engineId",
                table: "vehicle",
                newName: "engine_id");

            migrationBuilder.RenameColumn(
                name: "vehicle_bodyId",
                table: "vehicle",
                newName: "body_id");

            migrationBuilder.AddColumn<Guid>(
                name: "EngineId",
                table: "vehicle",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_body_id",
                table: "vehicle",
                column: "body_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_engine_id",
                table: "vehicle",
                column: "engine_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_EngineId",
                table: "vehicle",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_maintenance_id",
                table: "vehicle",
                column: "maintenance_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_body_body_id",
                table: "vehicle",
                column: "body_id",
                principalTable: "car_body",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_engine_EngineId",
                table: "vehicle",
                column: "EngineId",
                principalTable: "car_engine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_engine_engine_id",
                table: "vehicle",
                column: "engine_id",
                principalTable: "car_engine",
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
                name: "FK_vehicle_car_engine_EngineId",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_engine_engine_id",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_maintenance_maintenance_id",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_body_id",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_engine_id",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_EngineId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_maintenance_id",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "vehicle");

            migrationBuilder.RenameColumn(
                name: "maintenance_id",
                table: "vehicle",
                newName: "vehicle_maintenanceId");

            migrationBuilder.RenameColumn(
                name: "engine_id",
                table: "vehicle",
                newName: "vehicle_engineId");

            migrationBuilder.RenameColumn(
                name: "body_id",
                table: "vehicle",
                newName: "vehicle_bodyId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_vehicle_bodyId",
                table: "vehicle",
                column: "vehicle_bodyId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_vehicle_engineId",
                table: "vehicle",
                column: "vehicle_engineId");

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
                name: "FK_vehicle_car_engine_vehicle_engineId",
                table: "vehicle",
                column: "vehicle_engineId",
                principalTable: "car_engine",
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
