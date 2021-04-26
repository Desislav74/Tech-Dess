using Microsoft.EntityFrameworkCore.Migrations;

namespace TechDess.Data.Migrations
{
    public partial class ChangeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharacteristic_Characteristic_CharacteristicId",
                table: "ProductCharacteristic");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharacteristic_Products_ProductId",
                table: "ProductCharacteristic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCharacteristic",
                table: "ProductCharacteristic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characteristic",
                table: "Characteristic");

            migrationBuilder.RenameTable(
                name: "ProductCharacteristic",
                newName: "ProductCharacteristics");

            migrationBuilder.RenameTable(
                name: "Characteristic",
                newName: "Characteristics");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCharacteristic_ProductId",
                table: "ProductCharacteristics",
                newName: "IX_ProductCharacteristics_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCharacteristic_CharacteristicId",
                table: "ProductCharacteristics",
                newName: "IX_ProductCharacteristics_CharacteristicId");

            migrationBuilder.RenameIndex(
                name: "IX_Characteristic_IsDeleted",
                table: "Characteristics",
                newName: "IX_Characteristics_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCharacteristics",
                table: "ProductCharacteristics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characteristics",
                table: "Characteristics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharacteristics_Characteristics_CharacteristicId",
                table: "ProductCharacteristics",
                column: "CharacteristicId",
                principalTable: "Characteristics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharacteristics_Products_ProductId",
                table: "ProductCharacteristics",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharacteristics_Characteristics_CharacteristicId",
                table: "ProductCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCharacteristics_Products_ProductId",
                table: "ProductCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCharacteristics",
                table: "ProductCharacteristics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Characteristics",
                table: "Characteristics");

            migrationBuilder.RenameTable(
                name: "ProductCharacteristics",
                newName: "ProductCharacteristic");

            migrationBuilder.RenameTable(
                name: "Characteristics",
                newName: "Characteristic");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCharacteristics_ProductId",
                table: "ProductCharacteristic",
                newName: "IX_ProductCharacteristic_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCharacteristics_CharacteristicId",
                table: "ProductCharacteristic",
                newName: "IX_ProductCharacteristic_CharacteristicId");

            migrationBuilder.RenameIndex(
                name: "IX_Characteristics_IsDeleted",
                table: "Characteristic",
                newName: "IX_Characteristic_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCharacteristic",
                table: "ProductCharacteristic",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Characteristic",
                table: "Characteristic",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharacteristic_Characteristic_CharacteristicId",
                table: "ProductCharacteristic",
                column: "CharacteristicId",
                principalTable: "Characteristic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCharacteristic_Products_ProductId",
                table: "ProductCharacteristic",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
