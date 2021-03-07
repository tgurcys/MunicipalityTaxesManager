using MunicipalityTaxesManager.Enums;
using MunicipalityTaxesManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalityTaxesManager.DataLayer
{
    public class TaxPeriodProvider
    {
        public TaxPeriod CreateNewPeriod(DateTime date, int taxType)
        {
            TaxPeriod result = new TaxPeriod();

            if (taxType == (int)Tax.Yearly)
            {
                result.DateFrom = new DateTime(date.Year, 1, 1);
                result.DateTo = new DateTime(date.Year, 12, 31);
                return result;
            }
            else if (taxType == (int)Tax.Monthly)
            {
                result.DateFrom = new DateTime(date.Year, date.Month, 1);
                result.DateTo = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
                return result;
            }
            else if (taxType == (int)Tax.Weekly)
            {
                CultureInfo cultureInfo = new CultureInfo("da-DK");

                var firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;

                int offset = firstDayOfWeek - date.DayOfWeek;
                if (offset != 1)
                {
                    DateTime weekStart = date.AddDays(offset);
                    DateTime endOfWeek = weekStart.AddDays(6);
                    result.DateFrom = weekStart;
                    result.DateTo = endOfWeek;
                }
                else
                {
                    result.DateFrom = date.AddDays(-6);
                    result.DateTo = date;
                }

                return result;
            }
            else
            {
                result.DateFrom = result.DateTo = new DateTime(date.Year, date.Month, date.Day);
                return result;
            }
        }
    }
}
