using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class FSCargoWPData
    {
        public int Id { get; set; }
        public string Parameters { get; set; }
        public string ParameterValue { get; set; }
        public string ParameterUnit { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

    }
}