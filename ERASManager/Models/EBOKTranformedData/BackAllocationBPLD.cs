using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKTranformedData
{
    public class BackAllocationBPLD
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public double BPLD { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }

        public BackAllocationBPLD()
        {
            this.ReportDate = DateTime.Today.Date;
            this.UploadTime = DateTime.Now.ToString("h:mm:ss tt");
            this.TimeStamp = DateTime.Now;
            this.DayOftheWeek = DateTime.Today.DayOfWeek.ToString();

        }
    }

    public class BackAllocationBPLDStaging
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public string BPLD { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
    }

    public class ConsolidatedBackAllocation
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        [MaxLength(150)]
        public string Well { get; set; }
        public double BPLD { get; set; }
        public double ActualGOR { get; set; }
        public double AssumedGOR { get; set; }
        public double BOPD { get; set; }
        public double BSW { get; set; }
        public double Uptime { get; set; }
        public double GasAllocation { get; set; }
        public double QgActual { get; set; }
        public double QgPotential { get; set; }
        public double Qlest { get; set; }
        public double Qlink { get; set; }
        public double Qo { get; set; }
        public double Qoest { get; set; }
        public double Qw { get; set; }
    }

    public class ConsolidatedBackAllocationHeader
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double ActualGOR { get; set; }
        public double ActualGasProduced { get; set; }
        public double GasAllocation { get; set; }
        public double GasDifference { get; set; }
        public double QgActual { get; set; }
        public double QgPotential { get; set; }
        public double ProdOil { get; set; }
        public double TotalQlink { get; set; }
        public double WellTestActual { get; set; }
        public double wellTestPotential { get; set; }
        public double Qo { get; set; }
        public double Qw { get; set; }
    }

    public class YearlyConsolidatedBackAllocation
    {
        public int IndicatorMonth { get; set; }
        public double BPLD { get; set; }
        public double ActualGOR { get; set; }
        public double AssumedGOR { get; set; }
        public double BOPD { get; set; }
        public double BSW { get; set; }
        public double Uptime { get; set; }
        public double GasAllocation { get; set; }
        public double QgActual { get; set; }
        public double QgPotential { get; set; }
        public double Qlest { get; set; }
        public double Qlink { get; set; }
        public double Qo { get; set; }
        public double Qoest { get; set; }
        public double Qw { get; set; }
    }

    public class transposeBackAllocation
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double CFB { get; set; }
        public double WFB { get; set; }
    }
}
