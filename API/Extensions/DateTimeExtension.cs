namespace API.Extensions
{
    public static class DateTimeExtension
    {

        public static int CalculateAge(this DateOnly db)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var age = today.Year - db.Year; 

            if(today.AddYears(-age) < db) age--;

            return age;
            
        }
    }
}
