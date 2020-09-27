using Microsoft.EntityFrameworkCore.Migrations;

namespace Mmu.Mlh.TestingExtensions.FakeApp.Areas.DataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Individual_IndividualId",
                schema: "Core",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Street_Address_AddressId",
                schema: "Core",
                table: "Street");

            migrationBuilder.AlterColumn<long>(
                name: "AddressId",
                schema: "Core",
                table: "Street",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IndividualId",
                schema: "Core",
                table: "Address",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Individual_IndividualId",
                schema: "Core",
                table: "Address",
                column: "IndividualId",
                principalSchema: "Core",
                principalTable: "Individual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Street_Address_AddressId",
                schema: "Core",
                table: "Street",
                column: "AddressId",
                principalSchema: "Core",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Individual_IndividualId",
                schema: "Core",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Street_Address_AddressId",
                schema: "Core",
                table: "Street");

            migrationBuilder.AlterColumn<long>(
                name: "AddressId",
                schema: "Core",
                table: "Street",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "IndividualId",
                schema: "Core",
                table: "Address",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Individual_IndividualId",
                schema: "Core",
                table: "Address",
                column: "IndividualId",
                principalSchema: "Core",
                principalTable: "Individual",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Street_Address_AddressId",
                schema: "Core",
                table: "Street",
                column: "AddressId",
                principalSchema: "Core",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
