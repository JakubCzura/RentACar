﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentACar.WebAPI.Database;

#nullable disable

namespace RentACar.WebAPI.Migrations
{
    [DbContext(typeof(RentACarDbContext))]
    [Migration("20230425201323_fixReservation")]
    partial class fixReservation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RentACar.WebAPI.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DailyRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Kind")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DailyRate = 402m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Super",
                            PlateNumber = ""
                        },
                        new
                        {
                            Id = 2,
                            DailyRate = 432m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Super X",
                            PlateNumber = "X412"
                        },
                        new
                        {
                            Id = 3,
                            DailyRate = 213m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Super Y",
                            PlateNumber = "D212"
                        },
                        new
                        {
                            Id = 4,
                            DailyRate = 531m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Huge",
                            PlateNumber = "DL212"
                        },
                        new
                        {
                            Id = 5,
                            DailyRate = 402m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Huge",
                            PlateNumber = "D242"
                        },
                        new
                        {
                            Id = 6,
                            DailyRate = 421m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Great",
                            PlateNumber = "DR212"
                        },
                        new
                        {
                            Id = 7,
                            DailyRate = 402m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Super",
                            PlateNumber = "D211"
                        },
                        new
                        {
                            Id = 8,
                            DailyRate = 421m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Super X",
                            PlateNumber = "D210"
                        },
                        new
                        {
                            Id = 9,
                            DailyRate = 342m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Super Huge",
                            PlateNumber = "D212"
                        },
                        new
                        {
                            Id = 10,
                            DailyRate = 533m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Super",
                            PlateNumber = "D212"
                        },
                        new
                        {
                            Id = 11,
                            DailyRate = 533m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Super Huge",
                            PlateNumber = "DF212"
                        },
                        new
                        {
                            Id = 12,
                            DailyRate = 531m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Great Huge",
                            PlateNumber = "DR212"
                        },
                        new
                        {
                            Id = 13,
                            DailyRate = 123m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Super",
                            PlateNumber = "D2312"
                        },
                        new
                        {
                            Id = 14,
                            DailyRate = 402m,
                            IsAvailable = true,
                            Kind = "Passenger",
                            Make = "Tesla",
                            Model = "Super",
                            PlateNumber = "D212"
                        });
                });

            modelBuilder.Entity("RentACar.WebAPI.Models.DropoffLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("DropoffLocations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Palma Airpot"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Palma City Center"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Acludia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Manacor"
                        });
                });

            modelBuilder.Entity("RentACar.WebAPI.Models.PickupLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PickupLocation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Palma Airpot"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Palma City Center"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Acludia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Manacor"
                        });
                });

            modelBuilder.Entity("RentACar.WebAPI.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("DropoffLocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PickupLocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("DropoffLocationId");

                    b.HasIndex("PickupLocationId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RentACar.WebAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RentACar.WebAPI.Models.Reservation", b =>
                {
                    b.HasOne("RentACar.WebAPI.Models.Car", "Car")
                        .WithMany("Reservations")
                        .HasForeignKey("CarId");

                    b.HasOne("RentACar.WebAPI.Models.DropoffLocation", "DropoffLocation")
                        .WithMany("Reservations")
                        .HasForeignKey("DropoffLocationId");

                    b.HasOne("RentACar.WebAPI.Models.PickupLocation", "PickupLocation")
                        .WithMany("Reservations")
                        .HasForeignKey("PickupLocationId");

                    b.HasOne("RentACar.WebAPI.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId");

                    b.Navigation("Car");

                    b.Navigation("DropoffLocation");

                    b.Navigation("PickupLocation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RentACar.WebAPI.Models.Car", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RentACar.WebAPI.Models.DropoffLocation", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RentACar.WebAPI.Models.PickupLocation", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RentACar.WebAPI.Models.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
