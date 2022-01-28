using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.RevisedBackAllocation
{
    public class RBackAllocationMaster
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        [MaxLength(50)]
        public string Well { get; set; }
        public virtual EBOKDailyReport.WellTestEnrichmentData WellTestEnrichmentData { get; set; }
        public double BLPD { get; set; }
        public double BSW { get; set; }
        public double GOR { get; set; }
        public double CFBStrinkageFactor { get; set; }
        public double WFBStrinkageFactor { get; set; }
        public DateTime TimeStamp { get; set; }
        public RBackAllocationMaster()
        {
            this.TimeStamp = DateTime.Now;
        }
    }

}