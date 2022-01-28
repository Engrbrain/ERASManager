using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class EHSSVEER
    {
        public int Id { get; set; }
        public string ParameterCategory { get; set; }
        public string Parameter { get; set; }
        public string Today { get; set; }
        public string CurrentWeek { get; set; }
        public string Month { get; set; }
        public string Cummulative { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }


    }
}