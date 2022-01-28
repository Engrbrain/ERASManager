using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class CFBWaterInjectorMeter
    {
        public int Id { get; set; }
        public string MeterName { get; set; }
        public string CurrentEightHours { get; set; }
        public string PreviousEightHours { get; set; }
        public string TwentyFourHours { get; set; }
        public string Press { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

    }
}