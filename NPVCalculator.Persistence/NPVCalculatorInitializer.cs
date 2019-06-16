using System;
using System.Collections.Generic;
using System.Linq;
using NPVCalculator.Domain.Entities;

namespace NPVCalculator.Persistence
{
    public class NPVCalculatorInitializer
    {
        private readonly Dictionary<int, Projection> Projections = new Dictionary<int, Projection>();

        /// <summary>
        /// Initialize context
        /// </summary>
        /// <param name="context">NPVCalculatorDbContext object</param>
        public static void Initialize(NPVCalculatorDbContext context)
        {
            var initializer = new NPVCalculatorInitializer();
            initializer.SeedEverything(context);
        }

        /// <summary>
        /// Method for seeding every table
        /// </summary>
        /// <param name="context">NPVCalculatorDbContext object</param>
        public void SeedEverything(NPVCalculatorDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Projections.Any())
            {
                return; // Db has been seeded
            }

            SeedUsers(context);

        }

        /// <summary>
        /// Method for seeding users table
        /// </summary>
        /// <param name="context">ExpenseTrackerDbContext object</param>
        public void SeedUsers(NPVCalculatorDbContext context)
        {
            var projections = new[]
            {
                new Projection {  CashflowAmount = 1000, DateAdded = DateTime.UtcNow, DiscountRateIncrement = .5,  LowerBoundDiscountRate = .5, UpperBoundDiscountRate = 1.5 },
                new Projection {  CashflowAmount = 2000, DateAdded = DateTime.UtcNow, DiscountRateIncrement = .5,  LowerBoundDiscountRate = .10, UpperBoundDiscountRate = 2.5 },
                new Projection {  CashflowAmount = 3000, DateAdded = DateTime.UtcNow, DiscountRateIncrement = .5,  LowerBoundDiscountRate = .15, UpperBoundDiscountRate = 3.5 }
            };

            context.Projections.AddRange(projections);

            context.SaveChanges();
        }
    }
}
