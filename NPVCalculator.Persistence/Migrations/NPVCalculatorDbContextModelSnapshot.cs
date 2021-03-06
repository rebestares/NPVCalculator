﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NPVCalculator.Persistence;

namespace NPVCalculator.Persistence.Migrations
{
    [DbContext(typeof(NPVCalculatorDbContext))]
    partial class NPVCalculatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NPVCalculator.Domain.Entities.Projection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("ComputedNetPresentValue");

                    b.Property<DateTime>("DateAdded");

                    b.Property<double>("DiscountRateIncrement");

                    b.Property<double>("ExpectedPresentCashflowValue");

                    b.Property<double>("LowerBoundDiscountRate");

                    b.Property<double>("ProjectedAmount");

                    b.Property<double>("UpperBoundDiscountRate");

                    b.HasKey("Id");

                    b.ToTable("Projections");
                });
#pragma warning restore 612, 618
        }
    }
}
