using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedPro.EF.Migrations
{
    /// <inheritdoc />
    public partial class EditingNamesAndAddingSomeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecName",
                table: "Specalizations",
                newName: "DoctorSpecialization");

            migrationBuilder.RenameColumn(
                name: "RequestState",
                table: "Bookings",
                newName: "BookingStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DoctorSpecialization",
                table: "Specalizations",
                newName: "SpecName");

            migrationBuilder.RenameColumn(
                name: "BookingStatus",
                table: "Bookings",
                newName: "RequestState");
        }
    }
}
