using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class EHSSReport
    {
        public int Id { get; set; }
        public string ReportCategory { get; set; }
        public string ReportParameter { get; set; }
        public string ReportValue { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

    }
}