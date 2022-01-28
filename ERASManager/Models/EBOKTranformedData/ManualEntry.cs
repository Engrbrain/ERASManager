using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKTranformedData
{
    public class ManualEntry
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double BLPD { get; set; }
        public double AssumedGOR { get; set; }
        public double WaterOverboard { get; set; }
        public double Pumpablecargo { get; set; }
        public double FreeWaterReceived { get; set; }
        public double UllageMeasurement { get; set; }
      
    }
}