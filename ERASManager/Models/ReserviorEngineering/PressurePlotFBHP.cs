using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.ReserviorEngineering
{
    public class PressurePlotFBHP
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public double Pressure { get; set; }
        public double Temperature { get; set; }
        public double DischargePressure { get; set; }
        public double MotorTemperature { get; set; }
        public double Frequency { get; set; }
        public double AvgVSDCurrent { get; set; }
        public double DriveVolts { get; set; }
        public double SysCurrent { get; set; }
        public double XVibration { get; set; }
        public double YVibration { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

        public PressurePlotFBHP()
        {
            this.ReportDate = DateTime.Today.Date;
            this.UploadTime = DateTime.Now.ToString("h:mm:ss tt");
            this.TimeStamp = DateTime.Now;
            this.DayOftheWeek = DateTime.Today.DayOfWeek.ToString();

        }
    }

}
