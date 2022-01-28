using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class EBOKHallPlotData
    {
        public int Id { get; set; }
        public string Well { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double BWPD { get; set; }
        public double CUMMMBBL { get; set; }
        public double FTHP { get; set; }
        public double THSP { get; set; }
        public double DTDays { get; set; }
        public double II { get; set; }
        public double HallCal { get; set; }
        public double HallCal2 { get; set; }
        public double HallCal3 { get; set; }
        public double HallCal4 { get; set; }
        public double Hall { get; set; }

    }
}