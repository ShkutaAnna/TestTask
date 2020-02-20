using System;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (weekEnds != null)
                for (int i = 0; i < weekEnds.Length; i++)
                {
                    if (startDate < weekEnds[i].StartDate)
                    {
                        int span = (int)(weekEnds[i].StartDate - startDate).TotalDays;
                        if (span >= dayCount)
                        {
                            return startDate.AddDays(dayCount - 1);
                        }
                        else
                        {
                            dayCount -= span;
                            startDate = weekEnds[i].EndDate.AddDays(1);
                            continue;
                        }
                    }
                    else if (weekEnds[i].StartDate <= startDate && startDate <= weekEnds[i].EndDate)
                    {
                        startDate = weekEnds[i].EndDate.AddDays(1);
                        continue;
                    }
                    else if (startDate > weekEnds[i].EndDate)
                        continue;
                }
            
            return startDate.AddDays(dayCount - 1);
        }
        
    }
}
