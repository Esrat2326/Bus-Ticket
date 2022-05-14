﻿// <auto-generated />
using System;
using BTMS.DataLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BTMS.DataLib.Migrations
{
    [DbContext(typeof(BusDbContext))]
    [Migration("20220425031648_bd_2")]
    partial class bd_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BTMS.DataLib.Models.BoardingPoint", b =>
                {
                    b.Property<int>("BoardingPointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int?>("BusRouteId")
                        .HasColumnType("int");

                    b.Property<string>("PointName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("BoardingPointId");

                    b.HasIndex("BusRouteId");

                    b.ToTable("BoardingPoints");
                });

            modelBuilder.Entity("BTMS.DataLib.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("date");

                    b.Property<bool>("BookingStatus")
                        .HasColumnType("bit");

                    b.Property<decimal>("FareAmount")
                        .HasColumnType("money");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("money");

                    b.HasKey("BookingId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BTMS.DataLib.Models.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("BusPlateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BusType")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Features")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("BusId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("BTMS.DataLib.Models.BusRoute", b =>
                {
                    b.Property<int>("BusRouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("BusRouteId");

                    b.ToTable("BusRoutes");
                });

            modelBuilder.Entity("BTMS.DataLib.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("CompanyEmail")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CompanyPhoneNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BTMS.DataLib.Models.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<int>("BusRouteId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("DepartureTime")
                        .HasColumnType("time");

                    b.Property<decimal>("FareAmount")
                        .HasColumnType("money");

                    b.Property<DateTime>("JourneyDate")
                        .HasColumnType("date");

                    b.Property<int>("MinTimeToReportBeforeDeparture")
                        .HasColumnType("int");

                    b.HasKey("ScheduleId");

                    b.HasIndex("BusId");

                    b.HasIndex("BusRouteId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("BTMS.DataLib.Models.BoardingPoint", b =>
                {
                    b.HasOne("BTMS.DataLib.Models.BusRoute", "BusRoute")
                        .WithMany("BoardingPoints")
                        .HasForeignKey("BusRouteId");
                });

            modelBuilder.Entity("BTMS.DataLib.Models.Booking", b =>
                {
                    b.HasOne("BTMS.DataLib.Models.Schedule", "Schedule")
                        .WithMany("Bookings")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BTMS.DataLib.Models.Bus", b =>
                {
                    b.HasOne("BTMS.DataLib.Models.Company", "Company")
                        .WithMany("Buses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BTMS.DataLib.Models.Schedule", b =>
                {
                    b.HasOne("BTMS.DataLib.Models.Bus", "Bus")
                        .WithMany("Schedules")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BTMS.DataLib.Models.BusRoute", "BusRoute")
                        .WithMany("Schedules")
                        .HasForeignKey("BusRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
