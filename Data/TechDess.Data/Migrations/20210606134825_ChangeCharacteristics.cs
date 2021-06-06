using Microsoft.EntityFrameworkCore.Migrations;

namespace TechDess.Data.Migrations
{
    public partial class ChangeCharacteristics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "ProductCharacteristics",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Battery",
                table: "ProductCharacteristics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CallNotificationsAndMessages",
                table: "ProductCharacteristics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "ProductCharacteristics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CoolingPower",
                table: "ProductCharacteristics",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "D3",
                table: "ProductCharacteristics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DualSim",
                table: "ProductCharacteristics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "ProductCharacteristics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gps",
                table: "ProductCharacteristics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HeatingPower",
                table: "ProductCharacteristics",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Illumination",
                table: "ProductCharacteristics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Microphone",
                table: "ProductCharacteristics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrintingSpeed",
                table: "ProductCharacteristics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReactionTime",
                table: "ProductCharacteristics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Speaker",
                table: "ProductCharacteristics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Technology",
                table: "ProductCharacteristics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wifi",
                table: "ProductCharacteristics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Wlan",
                table: "ProductCharacteristics",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Battery",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "CallNotificationsAndMessages",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "CoolingPower",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "D3",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "DualSim",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "Format",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "Gps",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "HeatingPower",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "Illumination",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "Microphone",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "PrintingSpeed",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "ReactionTime",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "Speaker",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "Technology",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "Wifi",
                table: "ProductCharacteristics");

            migrationBuilder.DropColumn(
                name: "Wlan",
                table: "ProductCharacteristics");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "ProductCharacteristics",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
