using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRent.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: false),
                    Address_Country = table.Column<string>(type: "TEXT", nullable: false),
                    Address_State = table.Column<string>(type: "TEXT", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: false),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: false),
                    BikeCost_Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    BikeCost_Currency = table.Column<string>(type: "TEXT", nullable: false),
                    PricePerSecond_Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PricePerSecond_Currency = table.Column<string>(type: "TEXT", nullable: false),
                    LastRentedOnUtc = table.Column<DateTime>(type: "TEXT", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 320, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BikeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AdditionalServices = table.Column<string>(type: "TEXT", nullable: false),
                    Duration_Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Duration_End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PriceForPeriod_Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PriceForPeriod_Currency = table.Column<string>(type: "TEXT", nullable: false),
                    InsuranceFee_Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    InsuranceFee_Currency = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalServicesUpCharge_Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    AdditionalServicesUpCharge_Currency = table.Column<string>(type: "TEXT", nullable: false),
                    TotalPrice_Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalPrice_Currency = table.Column<string>(type: "TEXT", nullable: false),
                    RentalStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ConfirmedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RejectedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompletedOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CancelledOnUtc = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rental_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rental_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_BikeId",
                table: "Rental",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_UserId",
                table: "Rental",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rental");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
