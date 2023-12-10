using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedPro.EF.Migrations
{
    /// <inheritdoc />
    public partial class NamingVoucherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Patients_PatientId",
                table: "Voucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voucher",
                table: "Voucher");

            migrationBuilder.RenameTable(
                name: "Voucher",
                newName: "Vouchers");

            migrationBuilder.RenameIndex(
                name: "IX_Voucher_PatientId",
                table: "Vouchers",
                newName: "IX_Vouchers_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vouchers_Patients_PatientId",
                table: "Vouchers",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vouchers_Patients_PatientId",
                table: "Vouchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vouchers",
                table: "Vouchers");

            migrationBuilder.RenameTable(
                name: "Vouchers",
                newName: "Voucher");

            migrationBuilder.RenameIndex(
                name: "IX_Vouchers_PatientId",
                table: "Voucher",
                newName: "IX_Voucher_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voucher",
                table: "Voucher",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Patients_PatientId",
                table: "Voucher",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
