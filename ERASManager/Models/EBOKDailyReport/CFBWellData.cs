using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class CFBWellData
    {
        public int Id { get; set; }
        public string Rsv { get; set; }
        public string Well { get; set; }
        public string CHOKE { get; set; }
        public string HOURS_Online { get; set; }
        public string HOURS_Offline { get; set; }
        public string THP { get; set; }
        public string FLP { get; set; }
        public string BSW { get; set; }
        public string Ps { get; set; }
        public string Pwf { get; set; }
        public string BHT { get; set; }
        public string DP { get; set; }
        public double OIL { get; set; }
        public double GAS { get; set; }
        public double WATER { get; set; }
        public string API { get; set; }
        public string PumpFrequency { get; set; }
        public string Comment { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

    }
}