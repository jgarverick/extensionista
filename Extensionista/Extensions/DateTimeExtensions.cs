using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Extensionista
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Extension method used to compare two dates and their respective quarters.
        /// </summary>
        /// <param name="initialDate">The DateTime variable that will utilize the 
        /// extension method.</param>
        /// <param name="dateToCompare">The DateTime value to compare against.</param>
        /// <returns>True if both dates are within the same quarter; false if they are not.</returns>
        public static bool CompareQuarter(this DateTime initialDate, DateTime dateToCompare)
        {
            return initialDate.GetQuarter() == dateToCompare.GetQuarter();
        }

        /// <summary>
        /// Extension method used to retrieve the quarter associated with a date.
        /// </summary>
        /// <param name="dateToCheck">The DateTime variable that will utilize the extension
        /// method.</param>
        /// <returns>An integer (1,2,3,4) corresponding to the calendar quarter in which
        /// the date resides.</returns>
        public static int GetQuarter(this DateTime dateToCheck)
        {
            switch (dateToCheck.Month)
            {
                case 1:
                case 2:
                case 3:
                    return 1;
                case 4:
                case 5:
                case 6:
                    return 2;
                case 7:
                case 8:
                case 9:
                    return 3;
                case 10:
                case 11:
                case 12:
                    return 4;

            }
            return 0;

        }
        /// <summary>
        /// Extension method used to determine the closest working day to a specific date.
        /// </summary>
        /// <param name="dateToCheck">The DateTime variable that will use the extenison method.</param>
        /// <returns>A DateTime value that corresponds to the closest business day
        /// in relation to the supplied date. This does not take into consideration
        /// any holidays and assumes a Monday to Friday business week.</returns>
        public static DateTime ClosestBusinessDay(this DateTime dateToCheck)
        {
            if (dateToCheck.DayOfWeek == DayOfWeek.Saturday)
                return dateToCheck.AddDays(-1);
            else if (dateToCheck.DayOfWeek == DayOfWeek.Sunday)
                return dateToCheck.AddDays(1);
            else
                return dateToCheck;
        }


    }
}
