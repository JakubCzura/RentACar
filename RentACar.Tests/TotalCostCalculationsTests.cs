using RentACar.WebAPI.Helper;

namespace RentACar.Tests
{
    public class TotalCostCalculationsTests
    {
        public static IEnumerable<object[]> ProperCalulcationData => new List<object[]>
        {
            new object[] { new DateTime(2023, 5, 10), new DateTime(2023, 5, 11), 100, 100 },
            new object[] { new DateTime(2023, 5, 10), new DateTime(2023, 5, 12), 100, 200 },
            new object[] { new DateTime(2023, 5, 10), new DateTime(2023, 5, 13), 200, 600 },
            new object[] { new DateTime(2023, 4, 30), new DateTime(2023, 5, 5), 150, 750 },
            new object[] { new DateTime(2023, 4, 29), new DateTime(2023, 5, 4), 200, 1000 },
            new object[] { new DateTime(2023, 12, 30), new DateTime(2024, 1, 4), 50, 250 },
            new object[] { new DateTime(2023, 12, 29), new DateTime(2023, 12, 31), 1120.43, 2240.86 },
            new object[] { new DateTime(2023, 10, 10), new DateTime(2023, 10, 11), 100, 100 },
            new object[] { new DateTime(2023, 12, 10), new DateTime(2023, 12, 12), 250, 500},
        };

        [Theory]
        [MemberData(nameof(ProperCalulcationData))]
        public void Calculate_ForProperData_ReturnsProperTotalCost(DateTime startDate, DateTime endDate, decimal dailyRate, decimal expected)
        {
            // Arrange

            // Act
            decimal result = TotalCostCalculation.Calculate(startDate, endDate, dailyRate);

            // Assert
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> EndDateBeforeStartDateData => new List<object[]>
        {
            new object[] { new DateTime(2023, 5, 12), new DateTime(2023, 5, 11), 100 },
            new object[] { new DateTime(2023, 5, 15), new DateTime(2023, 5, 12), 100 },
            new object[] { new DateTime(2024, 5, 10), new DateTime(2023, 5, 12), 200 },
        };

        [Theory]
        [MemberData(nameof(EndDateBeforeStartDateData))]
        public void Calculate_ForEndDateBeforeStartDate_ThrowsArgumentException(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            // Arrange

            // Act
            Action result = () => TotalCostCalculation.Calculate(startDate, endDate, dailyRate);

            // Assert
            Assert.Throws<ArgumentException>(result);
        }

        public static IEnumerable<object[]> StartDateEqualsEndDateData => new List<object[]>
        {
            new object[] { new DateTime(2023, 5, 10), new DateTime(2023, 5, 10), 100 },
            new object[] { new DateTime(2023, 5, 5), new DateTime(2023, 5, 5), 100 },
            new object[] { new DateTime(2023, 5, 1), new DateTime(2023, 5, 1), 200 },
        };

        [Theory]
        [MemberData(nameof(StartDateEqualsEndDateData))]
        public void Calculate_ForStartDateEqualsEndDate_ThrowsArgumentException(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            // Arrange

            // Act
            Action result = () => TotalCostCalculation.Calculate(startDate, endDate, dailyRate);

            // Assert
            Assert.Throws<ArgumentException>(result);
        }

        public static IEnumerable<object[]> EndDateEqualsTodayDateData => new List<object[]>
        {
            new object[] { DateTime.Today, DateTime.Today, 100 },
        };

        [Theory]
        [MemberData(nameof(EndDateEqualsTodayDateData))]
        public void Calculate_ForEndDateEqualsTodayDate_ThrowsArgumentException(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            // Arrange

            // Act
            Action result = () => TotalCostCalculation.Calculate(startDate, endDate, dailyRate);

            // Assert
            Assert.Throws<ArgumentException>(result);
        }

        public static IEnumerable<object[]> NegativeDailyRateData => new List<object[]>
        {
            new object[] { new DateTime(2023, 5, 10), new DateTime(2023, 5, 11), -3 },
            new object[] { new DateTime(2023, 5, 10), new DateTime(2023, 5, 11), -5 },
            new object[] { new DateTime(2023, 5, 10), new DateTime(2023, 5, 11), -5.5 },
        };

        [Theory]
        [MemberData(nameof(NegativeDailyRateData))]
        public void Calculate_ForNegativeDailyRate_ThrowsArgumentException(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            // Arrange

            // Act
            Action result = () => TotalCostCalculation.Calculate(startDate, endDate, dailyRate);

            // Assert
            Assert.Throws<ArgumentException>(result);
        }
    }
}