using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class BackAllocationQwSummary
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public string FaultBlock { get; set; }
        public string RSV { get; set; }
        public double Qw { get; set; }
    }
}