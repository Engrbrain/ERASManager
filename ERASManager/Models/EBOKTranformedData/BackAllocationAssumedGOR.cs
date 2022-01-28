using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKTranformedData
{
    public class BackAllocationAssumedGOR
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public string IndicatorDate { get; set; }
        public double AssumedGOR { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

        public BackAllocationAssumedGOR()
        {
            this.ReportDate = DateTime.Today.Date;
            this.UploadTime = DateTime.Now.ToString("h:mm:ss tt");
            this.TimeStamp = DateTime.Now;
            this.DayOftheWeek = DateTime.Today.DayOfWeek.ToString();

        }
    }


    public class BackAllocationAssumedGORStaging
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public string IndicatorDate { get; set; }
        public string AssumedGOR { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
    }
}