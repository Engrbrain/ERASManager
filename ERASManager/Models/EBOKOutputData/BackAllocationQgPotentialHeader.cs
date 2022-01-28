using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class BackAllocationQgPotentialHeader
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double QgPotential { get; set; }

    }
}