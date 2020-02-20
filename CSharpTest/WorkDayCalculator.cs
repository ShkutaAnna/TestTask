using System;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            if (weekEnds != null)
                for (int i = 0; i < weekEnds.Length; i++)
                {
                    if (endDate < weekEnds[i].StartDate)
                    {
                        int span = (int)(weekEnds[i].StartDate - endDate).TotalDays;
                        if (span >= dayCount)
                        {
                            return endDate.AddDays(dayCount - 1);
                        }
                        else
                        {
                            dayCount -= span;
                            endDate = weekEnds[i].EndDate.AddDays(1);
                            continue;
                        }
                    }
                    else if (weekEnds[i].StartDate <= endDate && endDate <= weekEnds[i].EndDate)
                    {
                        endDate = weekEnds[i].EndDate.AddDays(1);
                        continue;
                    }
                    else if (endDate > weekEnds[i].EndDate)
                        continue;
                }
            
            return endDate.AddDays(dayCount - 1);
        }
        
    }
}
