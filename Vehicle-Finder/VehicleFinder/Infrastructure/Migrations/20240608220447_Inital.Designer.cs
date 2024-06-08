﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240608220447_Inital")]
    partial class Inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Body", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AcType")
                        .HasColumnType("integer")
                        .HasColumnName("ac_type");

                    b.Property<int>("BodyShape")
                        .HasColumnType("integer")
                        .HasColumnName("body_shape");

                    b.Property<int>("DoorCount")
                        .HasColumnType("integer")
                        .HasColumnName("door_count");

                    b.Property<int>("Equipment")
                        .HasColumnType("integer")
                        .HasColumnName("equipment");

                    b.Property<int>("SeatCount")
                        .HasColumnType("integer")
                        .HasColumnName("seat_count");

                    b.HasKey("Id");

                    b.ToTable("car_body");
                });

            modelBuilder.Entity("Domain.Entities.Engine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CylinderCount")
                        .HasColumnType("integer")
                        .HasColumnName("cylinder_count");

                    b.Property<int>("DriveType")
                        .HasColumnType("integer")
                        .HasColumnName("drive_type");

                    b.Property<int>("EngineCapacity")
                        .HasColumnType("integer")
                        .HasColumnName("engine_capacity");

                    b.Property<string>("EngineName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("engine_name");

                    b.Property<int>("EnginePower")
                        .HasColumnType("integer")
                        .HasColumnName("engine_power");

                    b.Property<int>("EngineType")
                        .HasColumnType("integer")
                        .HasColumnName("engine_type");

                    b.Property<int>("GearCount")
                        .HasColumnType("integer")
                        .HasColumnName("gear_count");

                    b.Property<int>("ShifterType")
                        .HasColumnType("integer")
                        .HasColumnName("shifter_type");

                    b.HasKey("Id");

                    b.ToTable("car_engine");
                });

            modelBuilder.Entity("Domain.Entities.Listing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImgDirectory")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("img_directory");

                    b.Property<bool>("IsSold")
                        .HasColumnType("boolean")
                        .HasColumnName("is_sold");

                    b.Property<DateTime>("PostDatetime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("post_datetime");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uuid")
                        .HasColumnName("vehicle_id");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("vehicle_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("user_id");

                    b.HasIndex("vehicle_id");

                    b.ToTable("listing", t =>
                        {
                            t.Property("user_id")
                                .HasColumnName("user_id1");

                            t.Property("vehicle_id")
                                .HasColumnName("vehicle_id1");
                        });
                });

            modelBuilder.Entity("Domain.Entities.Maintenance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("BasicCost")
                        .HasColumnType("real")
                        .HasColumnName("basic_cost");

                    b.Property<string>("BasicDetails")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("basic_details");

                    b.Property<float>("FullCost")
                        .HasColumnType("real")
                        .HasColumnName("full_cost");

                    b.Property<string>("FullDetails")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("full_details");

                    b.HasKey("Id");

                    b.ToTable("car_maintenance");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Domain.Entities.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("Consumption")
                        .HasColumnType("real")
                        .HasColumnName("consumption");

                    b.Property<int>("Kilometers")
                        .HasColumnType("integer")
                        .HasColumnName("kilometers");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("make");

                    b.Property<int>("ManufactureYear")
                        .HasColumnType("integer")
                        .HasColumnName("manufacture_year");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<int>("ModelYear")
                        .HasColumnType("integer")
                        .HasColumnName("model_year");

                    b.Property<int>("OwnersCount")
                        .HasColumnType("integer")
                        .HasColumnName("owners_count");

                    b.Property<DateTime>("RegistrationUntil")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registration_until");

                    b.Property<Guid?>("VehicleBodyId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("VehicleEngineId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("VehicleMaintenanceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VehicleBodyId");

                    b.HasIndex("VehicleEngineId");

                    b.HasIndex("VehicleMaintenanceId");

                    b.ToTable("vehicle");
                });

            modelBuilder.Entity("Domain.Entities.Listing", b =>
                {
                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("vehicle_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("Domain.Entities.Body", "VehicleBody")
                        .WithMany()
                        .HasForeignKey("VehicleBodyId");

                    b.HasOne("Domain.Entities.Engine", "VehicleEngine")
                        .WithMany()
                        .HasForeignKey("VehicleEngineId");

                    b.HasOne("Domain.Entities.Maintenance", "VehicleMaintenance")
                        .WithMany()
                        .HasForeignKey("VehicleMaintenanceId");

                    b.Navigation("VehicleBody");

                    b.Navigation("VehicleEngine");

                    b.Navigation("VehicleMaintenance");
                });
#pragma warning restore 612, 618
        }
    }
}