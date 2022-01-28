using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class BackAllocationQoestHeader
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double ProdOil { get; set; }
        public double WFBOilPotential { get; set; }
        public double CFBOilPotential { get; set; }
        public double CFBPlatformPotential { get; set; }
        public double WFBPlatformPotential { get; set; }
        public double WellTestPOtential { get; set; }
        public double CFBAllocatedProduction { get; set; }
        public double WFBAllocatedProduction { get; set; }
        public double WellTestActual { get; set; }
        public double CalWFBSF { get; set; }
    }
}