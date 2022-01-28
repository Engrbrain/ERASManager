using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class GasTrend
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double WFBPROCESSTOTAL { get; set; }
        public double TOTALGasLift { get; set; }
        public double CalcuatedInjectedGas { get; set; }
        public double MeteredGasInjected { get; set; }
        public double GASUtilizationTotal { get; set; }
        public double GASFLAREDTOTAL { get; set; }
    }
}