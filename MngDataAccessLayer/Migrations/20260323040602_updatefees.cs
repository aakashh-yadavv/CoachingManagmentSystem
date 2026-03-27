using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MngDataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class updatefees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Fees",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<decimal>(
                name: "PaidAmount",
                table: "Fees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainingAmount",
                table: "Fees",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidAmount",
                table: "Fees");

            migrationBuilder.DropColumn(
                name: "RemainingAmount",
                table: "Fees");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Fees",
                newName: "Amount");
        }
    }
}
