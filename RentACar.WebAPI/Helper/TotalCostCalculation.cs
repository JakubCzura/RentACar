﻿namespace RentACar.WebAPI.Helper
{
    public static class TotalCostCalculation
    {
        /// <summary>
        /// Calculates the cost of renting a car
        /// </summary>
        /// <param name="startDate">Date of picking up a car</param>
        /// <param name="endDate">Date of returning a car</param>
        /// <param name="dailyRate">Cost of renting a car for one day</param>
        /// <returns>Whole cost of renting a car</returns>
        /// <exception cref="ArgumentException"></exception>
        public static decimal Calculate(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            TimeSpan time = endDate - startDate;
            if (time.TotalDays < 0)
            {
                throw new ArgumentException("End date can't be before start date");
            }
            if (startDate.Date < DateTime.Today)
            {
                throw new ArgumentException("Start date can't be before today date");
            }
            if (dailyRate < 0)
            {
                throw new ArgumentException("Daily rate can't be negative");
            }
            // Add 1 day as user pays for each day, for example May 12-14 gives 3 days
            int days = time.Days + 1;
            decimal totalCost = days * dailyRate;
            return totalCost;
        }
    }
}