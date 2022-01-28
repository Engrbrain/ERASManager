using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKTranformedData
{
    public class WaterInjectorRateLineItem
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double ChokeSize { get; set; }
        public double UpTime { get; set; }
        public double THIP { get; set; }
        public double THSP { get; set; }
        public double FLP { get; set; }
        public double HP { get; set; }
        public double INJRate { get; set; }
        public double CumINJRate { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
        public WaterInjectorRateLineItem()
        {
            this.THSP = 0;
        }

    }

    public class WaterInjectorRateLineItemStaging
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public string IndicatorDate { get; set; }
        public string ChokeSize { get; set; }
        public string UpTime { get; set; }
        public string THIP { get; set; }
        public string THSP { get; set; }
        public string FLP { get; set; }
        public string HP { get; set; }
        public string INJRate { get; set; }
        public string CumINJRate { get; set; }
        public DateTime ReportDate { get; set; }
        public string UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
    }
}