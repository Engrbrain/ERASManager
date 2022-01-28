using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKOutputData
{
    public class EBOKProductionSurveillance
    {
        public int Id { get; set; }
        public string Well { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double BSW { get; set; }
        public double OilBOPD { get; set; }
        public double GASMSCFD { get; set; }
        public double CumOil { get; set; }
        public double CumOilkbbls { get; set; }
    }
}