using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class currencyToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "IsVoid",
                table: "Payments",
                newName: "PaymentType");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Accounts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "Payments",
                newName: "IsVoid");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Payments",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");
        }
    }
}
