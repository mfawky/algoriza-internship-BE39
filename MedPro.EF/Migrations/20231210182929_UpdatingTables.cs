using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedPro.EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Bookings_BookingId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Specalizations_DoctorId",
                table: "Specalizations");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_BookingId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Specalizations_DoctorId",
                table: "Specalizations",
                column: "DoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DoctorId",
                table: "Bookings",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Doctors_DoctorId",
                table: "Bookings",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Doctors_DoctorId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Specalizations_DoctorId",
                table: "Specalizations");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DoctorId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specalizations_DoctorId",
                table: "Specalizations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_BookingId",
                table: "Doctors",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Bookings_BookingId",
                table: "Doctors",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
