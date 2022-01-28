using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.ReserviorEngineering
{
    public class ReserviorWellExportLineData
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public double ChokeSize { get; set; }
        public double WFBLiquidtoMOPU { get; set; }
        public double WFBGastoMOPU { get; set; }
        public double GasLiftHeaderPre { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

        public ReserviorWellExportLineData()
        {
            this.ReportDate = DateTime.Today.Date;
            this.UploadTime = DateTime.Now.ToString("h:mm:ss tt");
            this.TimeStamp = DateTime.Now;
            this.DayOftheWeek = DateTime.Today.DayOfWeek.ToString();

        }
    }

}
