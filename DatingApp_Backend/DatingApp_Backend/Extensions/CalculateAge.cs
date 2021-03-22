using System;
namespace DatingApp_Backend.Extensions
{
    public static class CalculateAge
    {
        public static int CalculatedAge(this DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
