using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class BackAllocationQlestSummary
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double CFBLiquidPotential { get; set; }
        public double WFBLiquidPotential { get; set; }
        public double TQlest { get; set; }

    }
}