﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240425205351_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Body", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ac_type")
                        .HasColumnType("integer")
                        .HasColumnName("ac_type");

                    b.Property<int>("body_shape")
                        .HasColumnType("integer")
                        .HasColumnName("body_shape");

                    b.Property<int>("door_count")
                        .HasColumnType("integer")
                        .HasColumnName("door_count");

                    b.Property<int>("equipment")
                        .HasColumnType("integer")
                        .HasColumnName("equipment");

                    b.Property<int>("seat_count")
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

                    b.Property<float>("consumption")
                        .HasColumnType("real")
                        .HasColumnName("consumption");

                    b.Property<int>("cylinder_count")
                        .HasColumnType("integer")
                        .HasColumnName("cylinder_count");

                    b.Property<string>("drive_type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("drive_type");

                    b.Property<int>("engine_capacity")
                        .HasColumnType("integer")
                        .HasColumnName("engine_capacity");

                    b.Property<string>("engine_name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("engine_name");

                    b.Property<int>("engine_power")
                        .HasColumnType("integer")
                        .HasColumnName("engine_power");

                    b.Property<int>("engine_type")
                        .HasColumnType("integer")
                        .HasColumnName("engine_type");

                    b.Property<int>("gear_count")
                        .HasColumnType("integer")
                        .HasColumnName("gear_count");

                    b.Property<int>("shifter_type")
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

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("img_directory")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("img_directory");

                    b.Property<bool>("is_sold")
                        .HasColumnType("boolean")
                        .HasColumnName("is_sold");

                    b.Property<DateTime>("post_datetime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("post_datetime");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("vehicle_id")
                        .HasColumnType("uuid")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id");

                    b.HasIndex("user_id");

                    b.HasIndex("vehicle_id");

                    b.ToTable("listing");
                });

            modelBuilder.Entity("Domain.Entities.Maintenance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("basic_cost")
                        .HasColumnType("real")
                        .HasColumnName("basic_cost");

                    b.Property<string>("basic_details")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("basic_details");

                    b.Property<float>("full_cost")
                        .HasColumnType("real")
                        .HasColumnName("full_cost");

                    b.Property<string>("full_details")
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

                    b.Property<DateTime>("birth_date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("password_hash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("user_name")
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

                    b.Property<int>("kilometers")
                        .HasColumnType("integer")
                        .HasColumnName("kilometers");

                    b.Property<string>("make")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("make");

                    b.Property<int>("manufacture_year")
                        .HasColumnType("integer")
                        .HasColumnName("manufacture_year");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<int>("model_year")
                        .HasColumnType("integer")
                        .HasColumnName("model_year");

                    b.Property<int>("owners_count")
                        .HasColumnType("integer")
                        .HasColumnName("owners_count");

                    b.Property<DateTime>("registration_until")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registration_until");

                    b.HasKey("Id");

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
#pragma warning restore 612, 618
        }
    }
}
