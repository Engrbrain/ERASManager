using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class PressurePlotTCM
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public string RSV { get; set; }
        public string Well { get; set; }
        public double PWF { get; set; }
    }
}