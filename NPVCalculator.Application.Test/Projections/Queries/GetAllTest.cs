using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NPVCalculator.Application.Interfaces;
using NPVCalculator.Application.Projections.Queries;
using NPVCalculator.Domain.Entities;
using NUnit.Framework;

namespace NPVCalculator.Application.Test.Projections.Queries
{
    /// <summary>
    /// Get all test.
    /// </summary>
    [TestFixture]
    public class GetAllProjectionsQueryHandlerTest
    {
        private Mock<INPVCalculatorDbContext> mockNPVCalculatorDbContext;
        private Mock<IMapper> mockMapper;

        /// <summary>
        /// Should return ProjectionListViewModel when called.
        /// </summary>
        //[Test]
        public async Task Should_Return_ProjectionListViewModel()
        {
            var getAllProjectionsQueryHandler = new GetAllProjectionsQueryHandler(mockNPVCalculatorDbContext.Object,
                mockMapper.Object);
        }

            private void SetupEnvironment()
        {

        }
    }
}
