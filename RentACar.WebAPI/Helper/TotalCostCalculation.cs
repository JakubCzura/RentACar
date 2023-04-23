namespace RentACar.WebAPI.Helper
{
    public static class TotalCostCalculation
    {
        public static decimal Calculate(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            TimeSpan time = endDate - startDate;
            int numberOfDays = Convert.ToInt32(Math.Ceiling(time.TotalDays));
            decimal totalCost = numberOfDays * dailyRate;
            return totalCost;
        }
    }
}
