using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class CFBCrudeExportMeter
    {
        public int Id { get; set; }
        public string MeterName { get; set; }
        public string CurrentEightHours { get; set; }
        public string MeterFactor { get; set; }
        public string GrossCorr { get; set; }
        public string BSW { get; set; }
        public string NetOil { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

    }
}