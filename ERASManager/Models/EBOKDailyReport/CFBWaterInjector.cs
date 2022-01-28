using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class CFBWaterInjector
    {
        public int Id { get; set; }
        public string WaterInjector { get; set; }
        public string Choke { get; set; }
        public string D_Time { get; set; }
        public string THP { get; set; }
        public string FLP { get; set; }
        public string VolumeInjected { get; set; }
        public string Remarks { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }


    }
}