using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

            context.Database.Migrate();
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

            //SeedUsers(context);

        }

        /// <summary>
        /// Method for seeding users table
        /// </summary>
        /// <param name="context">ExpenseTrackerDbContext object</param>
        //public void SeedUsers(NPVCalculatorDbContext context)
        //{
        //    var projections = new[]
        //    {
        //        new Projection {Id = Guid.NewGuid(),  DateAdded = DateTime.UtcNow, DiscountRateIncrement = .5,  LowerBoundDiscountRate = .5, UpperBoundDiscountRate = 1.5 }
        //    };

        //    context.Projections.AddRange(projections);

        //    context.SaveChanges();
        //}
    }
}
