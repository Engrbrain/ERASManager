using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class DailyProductionSummary
    {
        public int id { get; set; }
        public string ReportParameter { get; set; }
        public string MopuMeter { get; set; }
        public string WaterInjection { get; set; }
        public string Oilinventory { get; set; }
        public string GasProduced { get; set; }
        public string GasUtilized { get; set; }
        public string GasFlared { get; set; }
        public string ProducedWater { get; set; }
        public string WfbUptime { get; set; }
        public string MopuUptime { get; set; }
        public string WaterInjectionUptime { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

    }
}