using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class WFBMaintenanceData
    {
        public int Id { get; set; }
        public string Parameters { get; set; }
        public string DailyTotal { get; set; }
        public string PreviousTotal { get; set; }
        public string Cummulative { get; set; }
        public String Comment { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }


    }
}