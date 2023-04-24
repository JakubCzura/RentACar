namespace RentACar.WebAPI.Helper
{
    public static class TotalCostCalculation
    {
        public static decimal Calculate(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            TimeSpan time = endDate - startDate;
            //insted of int numberOfDays = time.Days
            //as for example when a person returned a car being late, they should pay extra money for the next day
            int numberOfDays = Convert.ToInt32(Math.Ceiling(time.TotalDays));
            decimal totalCost = numberOfDays * dailyRate;
            return totalCost;
        }
    }
}