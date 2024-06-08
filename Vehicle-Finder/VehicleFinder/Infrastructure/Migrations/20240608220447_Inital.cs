﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "car_body",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    door_count = table.Column<int>(type: "integer", nullable: false),
                    seat_count = table.Column<int>(type: "integer", nullable: false),
                    ac_type = table.Column<int>(type: "integer", nullable: false),
                    equipment = table.Column<int>(type: "integer", nullable: false),
                    body_shape = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_body", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_engine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    engine_name = table.Column<string>(type: "text", nullable: false),
                    engine_type = table.Column<int>(type: "integer", nullable: false),
                    engine_power = table.Column<int>(type: "integer", nullable: false),
                    shifter_type = table.Column<int>(type: "integer", nullable: false),
                    gear_count = table.Column<int>(type: "integer", nullable: false),
                    drive_type = table.Column<int>(type: "integer", nullable: false),
                    engine_capacity = table.Column<int>(type: "integer", nullable: false),
                    cylinder_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_engine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "car_maintenance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    basic_cost = table.Column<float>(type: "real", nullable: false),
                    full_cost = table.Column<float>(type: "real", nullable: false),
                    basic_details = table.Column<string>(type: "text", nullable: false),
                    full_details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car_maintenance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    make = table.Column<string>(type: "text", nullable: false),
                    model = table.Column<string>(type: "text", nullable: false),
                    manufacture_year = table.Column<int>(type: "integer", nullable: false),
                    model_year = table.Column<int>(type: "integer", nullable: false),
                    registration_until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    kilometers = table.Column<int>(type: "integer", nullable: false),
                    owners_count = table.Column<int>(type: "integer", nullable: false),
                    consumption = table.Column<float>(type: "real", nullable: false),
                    VehicleEngineId = table.Column<Guid>(type: "uuid", nullable: true),
                    VehicleBodyId = table.Column<Guid>(type: "uuid", nullable: true),
                    VehicleMaintenanceId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicle_car_body_VehicleBodyId",
                        column: x => x.VehicleBodyId,
                        principalTable: "car_body",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_vehicle_car_engine_VehicleEngineId",
                        column: x => x.VehicleEngineId,
                        principalTable: "car_engine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_vehicle_car_maintenance_VehicleMaintenanceId",
                        column: x => x.VehicleMaintenanceId,
                        principalTable: "car_maintenance",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "listing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicle_id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicle_id1 = table.Column<Guid>(type: "uuid", nullable: false),
                    post_datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    is_sold = table.Column<bool>(type: "boolean", nullable: false),
                    img_directory = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_listing_user_user_id1",
                        column: x => x.user_id1,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_listing_vehicle_vehicle_id1",
                        column: x => x.vehicle_id1,
                        principalTable: "vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_listing_user_id1",
                table: "listing",
                column: "user_id1");

            migrationBuilder.CreateIndex(
                name: "IX_listing_vehicle_id1",
                table: "listing",
                column: "vehicle_id1");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "listing");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "vehicle");

            migrationBuilder.DropTable(
                name: "car_body");

            migrationBuilder.DropTable(
                name: "car_engine");

            migrationBuilder.DropTable(
                name: "car_maintenance");
        }
    }
}