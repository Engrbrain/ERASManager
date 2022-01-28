using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class DailySafetySummary
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public String SafetyReport { get; set; }
        public DateTime ReportDate { get; set; }
        [MaxLength(150)]
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        [MaxLength(150)]
        public string DayOftheWeek { get; set; }

    }
}