using iSele.Models.Lookups;
using iSele.Repository.Interfaces;
using QOnTMSSql.Models;
using QOnTMSSql.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace QOnT2iSeleMigration.Classes
{
    public class MigrateWeekDays
    {
        private List<WeekDaysTbl> SourceWeekDays { get; set; }
        private IFancyGenericRepository<WeekDay> TargetDays { get; set; }
        public MigrateWeekDays(List<WeekDaysTbl> QOnTWeekDays,
            IFancyGenericRepository<WeekDay> iSeleWeekDay)
        {
            SourceWeekDays = QOnTWeekDays;
            TargetDays = iSeleWeekDay;
        }


        public async Task<bool> AddWeekDay(WeekDay weekDay)
        {
            try
            {
                await TargetDays.AddWithIDOnAsync(weekDay, "iSele.WeekDays");
                return true;
            }
            catch
            {
                // ? log stuff?
                return false;
            }

        }

        public async Task<bool> UpdateWeekDay(WeekDay weekDay)
        {
            try
            {
                await TargetDays.UpdateAsync(weekDay);
                return true;
            }
            catch
            {
                // ? log stuff?
                return false;
            }
                
        }


        public async Task<bool> AddOrUpdateWeekDays()
        {
            bool success = false;
            foreach (var srcWeekDay in SourceWeekDays)
            {
                WeekDay weekDay = await TargetDays.FindAsync(wk => wk.WeekDayID == srcWeekDay.WeekDaysId);

                if (weekDay == null)
                {
                    success = await AddWeekDay(new WeekDay
                    {
                        WeekDayID = srcWeekDay.WeekDaysId,
                        WeekDayName = srcWeekDay.WeekDayName,
                        IsDispatchDay = (srcWeekDay.WeekDaysId > 1) || (srcWeekDay.WeekDaysId < 7)   // we assume 1=sun and 7=sat
                    });
                }
                else
                {
                    weekDay.WeekDayName = srcWeekDay.WeekDayName;
                    success = await UpdateWeekDay(weekDay);
                }

            }

            return success;
        }


    }
}
