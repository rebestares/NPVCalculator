using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NPVCalculator.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LowerBoundDiscountRate = table.Column<double>(nullable: false),
                    UpperBoundDiscountRate = table.Column<double>(nullable: false),
                    DiscountRateIncrement = table.Column<double>(nullable: false),
                    CashflowAmount = table.Column<double>(nullable: false),
                    ProjectedAmount = table.Column<double>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projections", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projections");
        }
    }
}
