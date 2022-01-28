using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class CONSUMABLESANALYSIS
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Parameters { get; set; }
        public string PrevROB { get; set; }
        public DateTime Produced { get; set; }
        public String Received { get; set; }
        public DateTime DailyConsumption { get; set; }
        public String ROB { get; set; }
        public DateTime ConsumptionYTD { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }


    }
}