using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKTranformedData
{
    public class EKOBDailyProductionIndicator
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double ChokeSize { get; set; }
        public double Uptime { get; set; }
        public double THP { get; set; }
        public double FLP { get; set; }
        public double BSW { get; set; }
        public double BHT { get; set; }
        public double AnnulusPressure { get; set; }
        public double Frequency { get; set; }
        public double SAND { get; set; }
        public double GROSSAPI { get; set; }
        public double NETAPI { get; set; }
        public double PS { get; set; }
        public double PWF { get; set; }
        public double DP { get; set; }
        public double OilBOPD { get; set; }
        public double WaterBWPD { get; set; }
        public double GASMMSCFD { get; set; }
        public double PI { get; set; }
        public double MaxWaterCut { get; set; }
        public double GOR { get; set; }
        [MaxLength(1500)]
        public string REMARK { get; set; }
        public double BLPD { get; set; }
        public double GASMSCFD { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
    }

    public class EKOBDailyProductionIndicatorStaging
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public string IndicatorDate { get; set; }
        public string ChokeSize { get; set; }
        public string Uptime { get; set; }
        public string THP { get; set; }
        public string FLP { get; set; }
        public string BSW { get; set; }
        public string BHT { get; set; }
        public string AnnulusPressure { get; set; }
        public string Frequency { get; set; }
        public string SAND { get; set; }
        public string GROSSAPI { get; set; }
        public string NETAPI { get; set; }
        public string PS { get; set; }
        public string PWF { get; set; }
        public string DP { get; set; }
        public string OilBOPD { get; set; }
        public string WaterBWPD { get; set; }
        public string GASMMSCFD { get; set; }
        public string PI { get; set; }
        public string MaxWaterCut { get; set; }
        public string GOR { get; set; }
        [MaxLength(1500)]
        public string REMARK { get; set; }
        public string BLPD { get; set; }
        public string GASMSCFD { get; set; }
        public DateTime ReportDate { get; set; }
        public string UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
    }
}