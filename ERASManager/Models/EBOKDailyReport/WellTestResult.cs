using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class WellTestResult
    {
        public int Id { get; set; }
        public string Rsv { get; set; }
        public string Well { get; set; }
        public string TestDate { get; set; }
        public string Choke { get; set; }
        public string Hours { get; set; }
        public string THP { get; set; }
        public string FLP { get; set; }
        public string BSW { get; set; }
        public string API { get; set; }
        public Double GROSSLIQUID {get; set;}
    public Double OIL { get; set; }
    public Double GAS { get; set; }
    public Double WATER { get; set; }
    public string GOR { get; set; }
    public string GLR { get; set; }
    public string Ps { get; set; }
    public string Pwf { get; set; }
    public string FREQ { get; set; }
        public string NETOILPOTENTIAL { get; set; }
        public string Comment { get; set; }
    public DateTime ReportDate { get; set; }
    public String UploadTime { get; set; }
    public DateTime TimeStamp { get; set; }
    public string DayOftheWeek { get; set; }


}
}