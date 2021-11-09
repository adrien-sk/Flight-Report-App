﻿// <auto-generated />
using System;
using FlightReportApp.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightReportApp.API.Migrations
{
    [DbContext(typeof(FlightReportAppDbContext))]
    partial class FlightReportAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightReportApp.API.Model.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("code");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("country");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Airport");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "HND",
                            Country = "Japan",
                            Name = "Tokyo Haneda Airport"
                        },
                        new
                        {
                            Id = 2,
                            Code = "DEN",
                            Country = "United States",
                            Name = "Denver International Airport"
                        },
                        new
                        {
                            Id = 3,
                            Code = "BSL",
                            Country = "France",
                            Name = "EuroAirport Basel-Mulhouse-Freiburg"
                        });
                });

            modelBuilder.Entity("FlightReportApp.API.Model.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ArrivalDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("arrival_date");

                    b.Property<int>("ArrivalLocationId")
                        .HasColumnType("int")
                        .HasColumnName("arrival_location_id");

                    b.Property<DateTime?>("DepartureDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("departure_date");

                    b.Property<int>("DepartureLocationId")
                        .HasColumnType("int")
                        .HasColumnName("departure_location_id");

                    b.Property<int>("PlaneId")
                        .HasColumnType("int")
                        .HasColumnName("plane_id");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalLocationId");

                    b.HasIndex("DepartureLocationId");

                    b.HasIndex("PlaneId");

                    b.ToTable("Flight");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalDate = new DateTime(2019, 5, 22, 13, 40, 0, 0, DateTimeKind.Unspecified),
                            ArrivalLocationId = 2,
                            DepartureDate = new DateTime(2019, 5, 22, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartureLocationId = 1,
                            PlaneId = 1
                        },
                        new
                        {
                            Id = 2,
                            ArrivalDate = new DateTime(2019, 5, 23, 19, 30, 0, 0, DateTimeKind.Unspecified),
                            ArrivalLocationId = 3,
                            DepartureDate = new DateTime(2019, 5, 23, 17, 15, 0, 0, DateTimeKind.Unspecified),
                            DepartureLocationId = 1,
                            PlaneId = 3
                        },
                        new
                        {
                            Id = 3,
                            ArrivalDate = new DateTime(2020, 10, 10, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            ArrivalLocationId = 1,
                            DepartureDate = new DateTime(2020, 10, 10, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartureLocationId = 2,
                            PlaneId = 2
                        },
                        new
                        {
                            Id = 4,
                            ArrivalDate = new DateTime(2020, 10, 15, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            ArrivalLocationId = 2,
                            DepartureDate = new DateTime(2020, 10, 15, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            DepartureLocationId = 3,
                            PlaneId = 3
                        },
                        new
                        {
                            Id = 5,
                            ArrivalDate = new DateTime(2020, 11, 2, 22, 10, 0, 0, DateTimeKind.Unspecified),
                            ArrivalLocationId = 1,
                            DepartureDate = new DateTime(2020, 11, 2, 14, 45, 0, 0, DateTimeKind.Unspecified),
                            DepartureLocationId = 3,
                            PlaneId = 1
                        });
                });

            modelBuilder.Entity("FlightReportApp.API.Model.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("code");

                    b.Property<DateTime?>("FirstUseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("first_use_date");

                    b.HasKey("Id");

                    b.ToTable("Plane");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "H520",
                            FirstUseDate = new DateTime(2005, 5, 13, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Code = "J294",
                            FirstUseDate = new DateTime(2007, 2, 5, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Code = "V872",
                            FirstUseDate = new DateTime(2010, 11, 22, 9, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("FlightReportApp.API.Model.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightId")
                        .HasColumnType("int")
                        .HasColumnName("flight_id");

                    b.Property<int>("ReporterId")
                        .HasColumnType("int")
                        .HasColumnName("reporter_id");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("FlightReportApp.API.Model.Flight", b =>
                {
                    b.HasOne("FlightReportApp.API.Model.Airport", "ArrivalLocation")
                        .WithMany("ArrivalFlights")
                        .HasForeignKey("ArrivalLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FlightReportApp.API.Model.Airport", "DepartureLocation")
                        .WithMany("DepartureFlights")
                        .HasForeignKey("DepartureLocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FlightReportApp.API.Model.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArrivalLocation");

                    b.Navigation("DepartureLocation");

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("FlightReportApp.API.Model.Report", b =>
                {
                    b.HasOne("FlightReportApp.API.Model.Flight", "Flight")
                        .WithMany("Reports")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("FlightReportApp.API.Model.Airport", b =>
                {
                    b.Navigation("ArrivalFlights");

                    b.Navigation("DepartureFlights");
                });

            modelBuilder.Entity("FlightReportApp.API.Model.Flight", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("FlightReportApp.API.Model.Plane", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}