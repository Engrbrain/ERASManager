using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class BackAllocationGasAllocationSummary
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public string FaultBlock { get; set; }
        public string RSV { get; set; }
        public double GasAllocation { get; set; }
        public double ActualGasProduced { get; set; }
        public double GasDifference { get; set; }

    }
}