using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKTranformedData
{
    public class GasInjectorDailyIndicators
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double ChokeSize { get; set; }
        public double Uptime { get; set; }
        public string Well { get; set; }
        public double CompDischPress { get; set; }
        public double GasInject { get; set; }
        public double IFLP { get; set; }
        public double IFLSkinTemp { get; set; }
        public double ITHP { get; set; }
        public double IBHP { get; set; }
        public double IBHT { get; set; }
        public string Remark { get; set; }
        public DateTime ReportDate { get; set; }
        public string UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
    }

    public class GasInjectorDailyIndicatorsStaging
    {
        public int Id { get; set; }
        public string IndicatorDate { get; set; }
        public string ChokeSize { get; set; }
        public string Uptime { get; set; }
        public string Well { get; set; }
        public string CompDischPress { get; set; }
        public string GasInject { get; set; }
        public string IFLP { get; set; }
        public string IFLSkinTemp { get; set; }
        public string ITHP { get; set; }
        public string IBHP { get; set; }
        public string IBHT { get; set; }
        public string Remark { get; set; }
        public DateTime ReportDate { get; set; }
        public string UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
    }
}