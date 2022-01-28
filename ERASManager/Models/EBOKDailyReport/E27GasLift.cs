using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class E27GasLift
    {
        public int Id { get; set; }
        public string GasLift { get; set; }
        public string Blpd { get; set; }
        public string InterpolationResult { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }


    }
}