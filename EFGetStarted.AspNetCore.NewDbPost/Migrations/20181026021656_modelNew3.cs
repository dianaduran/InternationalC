using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.AspNetCore.NewDbPost.Migrations
{
    public partial class modelNew3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualPayment",
                table: "Locals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AnnualPayment",
                table: "Locals",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
