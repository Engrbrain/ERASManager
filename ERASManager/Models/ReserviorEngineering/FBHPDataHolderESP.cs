using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.ReserviorEngineering
{
    public class FBHPDataHolderESP
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        [MaxLength(150)]
        public string F1 { get; set; }
        [MaxLength(150)] public string F2 { get; set; }
        [MaxLength(150)] public string F3 { get; set; }
        [MaxLength(150)] public string F4 { get; set; }
        [MaxLength(150)] public string F5 { get; set; }
        [MaxLength(150)] public string F6 { get; set; }
        [MaxLength(150)] public string F7 { get; set; }
        [MaxLength(150)] public string F8 { get; set; }
        [MaxLength(150)] public string F9 { get; set; }
        [MaxLength(150)] public string F10 { get; set; }
        [MaxLength(150)] public string F11 { get; set; }
        [MaxLength(150)] public string F12 { get; set; }
        [MaxLength(150)] public string F13 { get; set; }
        [MaxLength(150)] public string F14 { get; set; }
        [MaxLength(150)] public string F15 { get; set; }
        [MaxLength(150)] public string F16 { get; set; }
        [MaxLength(150)] public string F17 { get; set; }
        [MaxLength(150)] public string F18 { get; set; }
        [MaxLength(150)] public string F19 { get; set; }
        [MaxLength(150)] public string F20 { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

        public FBHPDataHolderESP()
        {
            this.ReportDate = DateTime.Today.Date;
            this.UploadTime = DateTime.Now.ToString("h:mm:ss tt");
            this.TimeStamp = DateTime.Now;
            this.DayOftheWeek = DateTime.Today.DayOfWeek.ToString();

        }
    }

}
