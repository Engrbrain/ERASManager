using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.ReserviorEngineering
{
    public class ReserviorWellsData
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public double ChokeSize { get; set; }
        public double FBHP { get; set; }
        public double DP { get; set; }
        public double FBHT { get; set; }
        public double FTHP { get; set; }
        public double FLP { get; set; }
        public double InnerAnnulus { get; set; }
        public double OuterAnnulus { get; set; }
        public double FLT { get; set; }
        public double Frequency { get; set; }
        public double GasLiftChoke { get; set; }
        public double GLMeter { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

        public ReserviorWellsData()
        {
            this.ReportDate = DateTime.Today.Date;
            this.UploadTime = DateTime.Now.ToString("h:mm:ss tt");
            this.TimeStamp = DateTime.Now;
            this.DayOftheWeek = DateTime.Today.DayOfWeek.ToString();

        }
    }

}
