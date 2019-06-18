using System.Threading;
using System.Threading.Tasks;
using Moq;
using NPVCalculator.Application.Projections.Commands.CalculateProjection;
using NUnit.Framework;
using static NPVCalculator.Application.Projections.Commands.CalculateProjection.CalculateProjectionCommand;
using System.Collections.Generic;
using System;

namespace NPVCalculator.Application.Test.Projections.Commands
{
    /// <summary>
    /// Calculate projection command handler test.
    /// </summary>
    [TestFixture]
    public class CalculateProjectionCommandTest
    {
        /// <summary>
        /// Should return ProjectionListViewModel when called.
        /// </summary>
        [Test]
        public async Task Should_Return_ProjectionListViewModel()
        {
            //Arrange
            var calculationProjectionCommand = new Handler();
            var calculateProjectionCommand = new CalculateProjectionCommand()
            {
                CashFlowAmount = new List<double>(){1000.00, 2000.00, 3000.00},
                LowerBoundDiscountRate = 3.0,
                UpperBoundDiscountRate = 5.0, 
                DiscountRateIncrement = 1.0,
                InitialAmount = 1000.00
            };

            //Act
            var result = await calculationProjectionCommand.Handle(calculateProjectionCommand,new CancellationToken()).ConfigureAwait(false);

            //Assert
            Assert.NotNull(result);
        }

        /// <summary>
        /// Shoulds the throw exception when calculate projection command is null.
        /// </summary>
        /// <returns>The throw exception when calculate projection command is null.</returns>
        [Test]
        public void Should_Throw_Exception_When_CalculateProjection_Command_Is_Null()
        {
            //Arrange
            var calculationProjectionCommand = new Handler();

            //Act
            //Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => calculationProjectionCommand.Handle(It.IsAny<CalculateProjectionCommand>(), new CancellationToken()));
        }

    }
}
