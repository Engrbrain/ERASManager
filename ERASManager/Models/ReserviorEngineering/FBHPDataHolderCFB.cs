using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.ReserviorEngineering
{
    public class FBHPDataHolderCFB
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
        [MaxLength(150)] public string F21 { get; set; }
        [MaxLength(150)] public string F22 { get; set; }
        [MaxLength(150)] public string F23 { get; set; }
        [MaxLength(150)] public string F24 { get; set; }
        [MaxLength(150)] public string F25 { get; set; }
        [MaxLength(150)] public string F26 { get; set; }
        [MaxLength(150)] public string F27 { get; set; }
        [MaxLength(150)] public string F28 { get; set; }
        [MaxLength(150)] public string F29 { get; set; }
        [MaxLength(150)] public string F30 { get; set; }
        [MaxLength(150)] public string F31 { get; set; }
        [MaxLength(150)] public string F32 { get; set; }
        [MaxLength(150)] public string F33 { get; set; }
        [MaxLength(150)] public string F34 { get; set; }
        [MaxLength(150)] public string F35 { get; set; }
        [MaxLength(150)] public string F36 { get; set; }
        [MaxLength(150)] public string F37 { get; set; }
        [MaxLength(150)] public string F38 { get; set; }
        [MaxLength(150)] public string F39 { get; set; }
        [MaxLength(150)] public string F40 { get; set; }
        [MaxLength(150)] public string F41 { get; set; }
        [MaxLength(150)] public string F42 { get; set; }
        [MaxLength(150)] public string F43 { get; set; }
        [MaxLength(150)] public string F44 { get; set; }
        [MaxLength(150)] public string F45 { get; set; }
        [MaxLength(150)] public string F46 { get; set; }
        [MaxLength(150)] public string F47 { get; set; }
        [MaxLength(150)] public string F48 { get; set; }
        [MaxLength(150)] public string F49 { get; set; }
        [MaxLength(150)] public string F50 { get; set; }
        [MaxLength(150)] public string F51 { get; set; }
        [MaxLength(150)] public string F52 { get; set; }
        [MaxLength(150)] public string F53 { get; set; }
        [MaxLength(150)] public string F54 { get; set; }
        [MaxLength(150)] public string F55 { get; set; }
        [MaxLength(150)] public string F56 { get; set; }
        [MaxLength(150)] public string F57 { get; set; }
        [MaxLength(150)] public string F58 { get; set; }
        [MaxLength(150)] public string F59 { get; set; }
        [MaxLength(150)] public string F60 { get; set; }
        [MaxLength(150)] public string F61 { get; set; }
        [MaxLength(150)] public string F62 { get; set; }
        [MaxLength(150)] public string F63 { get; set; }
        [MaxLength(150)] public string F64 { get; set; }
        [MaxLength(150)] public string F65 { get; set; }
        [MaxLength(150)] public string F66 { get; set; }
        [MaxLength(150)] public string F67 { get; set; }
        [MaxLength(150)] public string F68 { get; set; }
        [MaxLength(150)] public string F69 { get; set; }
        [MaxLength(150)] public string F70 { get; set; }

        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

        public FBHPDataHolderCFB()
        {
            this.ReportDate = DateTime.Today.Date;
            this.UploadTime = DateTime.Now.ToString("h:mm:ss tt");
            this.TimeStamp = DateTime.Now;
            this.DayOftheWeek = DateTime.Today.DayOfWeek.ToString();

        }
    }

}
