namespace RentACar.WebAPI.Helper
{
    public static class TotalCostCalculation
    {
        public static decimal Calculate(DateTime startDate, DateTime endDate, decimal dailyRate)
        {
            TimeSpan time = endDate - startDate;
            if(time.TotalDays <= 0)
            {
                throw new ArgumentException("End date can't be before start date");
            }
            //insted of int numberOfDays = time.Days
            //as for example when a person returned a car being late, they should pay extra money for the next day
            int numberOfDays = Convert.ToInt32(Math.Ceiling(time.TotalDays));
            decimal totalCost = numberOfDays * dailyRate;
            return totalCost;
        }
    }
}