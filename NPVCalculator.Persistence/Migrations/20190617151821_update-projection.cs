using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NPVCalculator.Persistence.Migrations
{
    public partial class updateprojection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CashflowAmount",
                table: "Projections",
                newName: "ExpectedPresentCashflowValue");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Projections",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<double>(
                name: "ComputedNetPresentValue",
                table: "Projections",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputedNetPresentValue",
                table: "Projections");

            migrationBuilder.RenameColumn(
                name: "ExpectedPresentCashflowValue",
                table: "Projections",
                newName: "CashflowAmount");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Projections",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
