using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class WellTestEnrichmentData
    {
        public int Id { get; set; }
        [MaxLength(15)]
        public string Well { get; set; }
        [MaxLength(15)]
        public string Rsv { get; set; }
        [MaxLength(15)]
        public string FaultBlock { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}