using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.AspNetCore.NewDbPost.Migrations
{
    public partial class modelNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Blogs",
                newName: "CompanyId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Blogs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SSNCompany",
                table: "Blogs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Blogs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Locals",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpaceID = table.Column<string>(nullable: false),
                    SquareFoot = table.Column<int>(nullable: false),
                    PricebySF = table.Column<double>(nullable: false),
                    MonthlyPayment = table.Column<double>(nullable: false),
                    AnnualPayment = table.Column<double>(nullable: false),
                    Deposit = table.Column<double>(nullable: false),
                    BussinesName = table.Column<string>(nullable: true),
                    ContractStart = table.Column<DateTime>(nullable: false),
                    ContractEnd = table.Column<DateTime>(nullable: false),
                    NameOwner = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locals", x => x.LocalId);
                    table.ForeignKey(
                        name: "FK_Locals_Blogs_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Blogs",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locals_CompanyId",
                table: "Locals",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locals");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "SSNCompany",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Blogs",
                newName: "BlogId");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");
        }
    }
}
