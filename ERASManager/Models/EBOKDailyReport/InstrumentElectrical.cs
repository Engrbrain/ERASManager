using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class InstrumentElectrical
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string Report { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }



    }
}