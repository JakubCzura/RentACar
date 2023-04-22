using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentACar.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DailyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Kind = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DropoffLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropoffLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PickupLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickupLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PickupLocationId = table.Column<int>(type: "int", nullable: false),
                    DropoffLocationId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_DropoffLocations_DropoffLocationId",
                        column: x => x.DropoffLocationId,
                        principalTable: "DropoffLocations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_PickupLocation_PickupLocationId",
                        column: x => x.PickupLocationId,
                        principalTable: "PickupLocation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "DailyRate", "IsAvailable", "Kind", "Make", "Model", "PlateNumber" },
                values: new object[,]
                {
                    { 1, 402m, true, "Passenger", "Tesla", "Super", "" },
                    { 2, 432m, true, "Passenger", "Tesla", "Super X", "X412" },
                    { 3, 213m, true, "Passenger", "Tesla", "Super Y", "D212" },
                    { 4, 531m, true, "Passenger", "Tesla", "Huge", "DL212" },
                    { 5, 402m, true, "Passenger", "Tesla", "Huge", "D242" },
                    { 6, 421m, true, "Passenger", "Tesla", "Great", "DR212" },
                    { 7, 402m, true, "Passenger", "Tesla", "Super", "D211" },
                    { 8, 421m, true, "Passenger", "Tesla", "Super X", "D210" },
                    { 9, 342m, true, "Passenger", "Tesla", "Super Huge", "D212" },
                    { 10, 533m, true, "Passenger", "Tesla", "Super", "D212" },
                    { 11, 533m, true, "Passenger", "Tesla", "Super Huge", "DF212" },
                    { 12, 531m, true, "Passenger", "Tesla", "Great Huge", "DR212" },
                    { 13, 123m, true, "Passenger", "Tesla", "Super", "D2312" },
                    { 14, 402m, true, "Passenger", "Tesla", "Super", "D212" }
                });

            migrationBuilder.InsertData(
                table: "DropoffLocations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Palma Airpot" },
                    { 2, "Palma City Center" },
                    { 3, "Acludia" },
                    { 4, "Manacor" }
                });

            migrationBuilder.InsertData(
                table: "PickupLocation",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Palma Airpot" },
                    { 2, "Palma City Center" },
                    { 3, "Acludia" },
                    { 4, "Manacor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_DropoffLocationId",
                table: "Reservations",
                column: "DropoffLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PickupLocationId",
                table: "Reservations",
                column: "PickupLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "DropoffLocations");

            migrationBuilder.DropTable(
                name: "PickupLocation");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
