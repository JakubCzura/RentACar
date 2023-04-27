using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentACar.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Model S", "X4142" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Model",
                value: "Model S");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Model S", "D2512" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Model S", "D8L212" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Model",
                value: "Model S");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Model X", "D1R212" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "Model",
                value: "Model X");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Model X", "D2510" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Model X", "D2612" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                column: "Model",
                value: "Model Y");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Model Y", "D98212" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Model Y", "D7R212" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Model Y", "D62312" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Model Y", "D6212" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Super", "" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Model",
                value: "Super X");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Super Y", "D212" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Huge", "DL212" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5,
                column: "Model",
                value: "Huge");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Great", "DR212" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7,
                column: "Model",
                value: "Super");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Super X", "D210" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Super Huge", "D212" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10,
                column: "Model",
                value: "Super");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Super Huge", "DF212" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Great Huge", "DR212" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Super", "D2312" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Model", "PlateNumber" },
                values: new object[] { "Super", "D212" });
        }
    }
}
