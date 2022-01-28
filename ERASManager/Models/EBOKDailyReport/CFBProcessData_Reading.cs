using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKDailyReport
{
    public class CFBProcessData_Reading
    {
        public int Id { get; set; }
        public string GasSource { get; set; }
        public string Pressure { get; set; }
        public string Temperature { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
    }
}