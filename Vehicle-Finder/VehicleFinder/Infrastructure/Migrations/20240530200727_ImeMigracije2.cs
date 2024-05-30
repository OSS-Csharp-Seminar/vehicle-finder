using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImeMigracije2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_body_BodyId",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_engine_EngineId",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_maintenance_MaintenanceId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_BodyId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_EngineId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_MaintenanceId",
                table: "vehicle");

            migrationBuilder.RenameColumn(
                name: "MaintenanceId",
                table: "vehicle",
                newName: "VehicleMaintenanceId");

            migrationBuilder.RenameColumn(
                name: "EngineId",
                table: "vehicle",
                newName: "VehicleEngineId");

            migrationBuilder.RenameColumn(
                name: "BodyId",
                table: "vehicle",
                newName: "VehicleBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_VehicleBodyId",
                table: "vehicle",
                column: "VehicleBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_VehicleEngineId",
                table: "vehicle",
                column: "VehicleEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_VehicleMaintenanceId",
                table: "vehicle",
                column: "VehicleMaintenanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_body_VehicleBodyId",
                table: "vehicle",
                column: "VehicleBodyId",
                principalTable: "car_body",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_engine_VehicleEngineId",
                table: "vehicle",
                column: "VehicleEngineId",
                principalTable: "car_engine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_maintenance_VehicleMaintenanceId",
                table: "vehicle",
                column: "VehicleMaintenanceId",
                principalTable: "car_maintenance",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_body_VehicleBodyId",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_engine_VehicleEngineId",
                table: "vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicle_car_maintenance_VehicleMaintenanceId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_VehicleBodyId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_VehicleEngineId",
                table: "vehicle");

            migrationBuilder.DropIndex(
                name: "IX_vehicle_VehicleMaintenanceId",
                table: "vehicle");

            migrationBuilder.RenameColumn(
                name: "VehicleMaintenanceId",
                table: "vehicle",
                newName: "MaintenanceId");

            migrationBuilder.RenameColumn(
                name: "VehicleEngineId",
                table: "vehicle",
                newName: "EngineId");

            migrationBuilder.RenameColumn(
                name: "VehicleBodyId",
                table: "vehicle",
                newName: "BodyId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_BodyId",
                table: "vehicle",
                column: "BodyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_EngineId",
                table: "vehicle",
                column: "EngineId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_MaintenanceId",
                table: "vehicle",
                column: "MaintenanceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_body_BodyId",
                table: "vehicle",
                column: "BodyId",
                principalTable: "car_body",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_engine_EngineId",
                table: "vehicle",
                column: "EngineId",
                principalTable: "car_engine",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicle_car_maintenance_MaintenanceId",
                table: "vehicle",
                column: "MaintenanceId",
                principalTable: "car_maintenance",
                principalColumn: "Id");
        }
    }
}
