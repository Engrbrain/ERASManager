using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class LastAvialableWellTest
    {
        public int Id { get; set; }
        public string Well { get; set; }
        public string GrossLiquid { get; set; }
        public string Oil { get; set; }
        public string Gas { get; set; }
        public string Water { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

    }
}