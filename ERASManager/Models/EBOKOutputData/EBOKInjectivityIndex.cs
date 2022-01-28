using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class EBOKInjectivityIndex
    {
        public int Id { get; set; }
        public string Well { get; set; }
        public double UpTime { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double INJRate { get; set; }
        public double THIP { get; set; }
        public double THSP { get; set; }
        public double ScaledupRate { get; set; }
        public double InjectivityIndex { get; set; }

    }
}