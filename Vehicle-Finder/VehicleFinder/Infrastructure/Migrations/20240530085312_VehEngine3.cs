using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VehEngine3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "maintenance_id",
                table: "vehicle",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "body_id",
                table: "vehicle",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

            migrationBuilder.DropIndex(
                name: "IX_vehicle_vehicle_maintenanceId",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "vehicle_bodyId",
                table: "vehicle");

            migrationBuilder.DropColumn(
                name: "vehicle_maintenanceId",
                table: "vehicle");

            migrationBuilder.AlterColumn<Guid>(
                name: "maintenance_id",
                table: "vehicle",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "body_id",
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
