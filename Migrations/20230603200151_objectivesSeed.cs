using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuliePro.Migrations
{
    public partial class objectivesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName", "StartWeight", "TrainerId" },
                values: new object[,]
                {
                    { 2, new DateTime(1980, 6, 3, 13, 12, 0, 0, DateTimeKind.Unspecified), "win@test.com", "Super", "Champion", null, 1 },
                    { 3, new DateTime(1972, 3, 2, 13, 12, 0, 0, DateTimeKind.Unspecified), "zen@test.com", "Master", "Zen", null, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 1,
                column: "DistanceKm",
                value: 8.0);

            migrationBuilder.UpdateData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Halthérophilie");

            migrationBuilder.InsertData(
                table: "Objective",
                columns: new[] { "Id", "AchievedDate", "CustomerId", "DistanceKm", "LostWeightKg", "Name" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 10, 4, 13, 12, 0, 0, DateTimeKind.Unspecified), 2, 8.0, null, "Course" },
                    { 4, new DateTime(2022, 10, 4, 13, 12, 0, 0, DateTimeKind.Unspecified), 2, 5.0, null, "Course" },
                    { 5, null, 3, null, 8.0, "Perte de poids" },
                    { 6, null, 3, null, 5.0, "Perte de poids" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Objective",
                keyColumn: "Id",
                keyValue: 1,
                column: "DistanceKm",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Speciality",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Althérophilie");
        }
    }
}
