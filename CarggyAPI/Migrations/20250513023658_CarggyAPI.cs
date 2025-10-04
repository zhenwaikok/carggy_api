using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarggyAPI.Migrations
{
    /// <inheritdoc />
    public partial class CarggyAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceLog",
                columns: table => new
                {
                    serviceLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    serviceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    serviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    serviceDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    serviceDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servicePrice = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    serviceImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehicleId = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLog", x => x.serviceLogId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    imageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    vehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehicleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    vehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehicleBrand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    plateNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    year = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    vehicleImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.vehicleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceLog");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
