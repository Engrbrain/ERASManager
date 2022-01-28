using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERASManager.Models.EBOKTranformedData
{
    public class EBOKFieldProductionSummary
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public double Uptime { get; set; }
        public double ProdOil { get; set; }
        public double CumProd { get; set; }
        public double ProdGas { get; set; }
        public double WFBAllocatedGas { get; set; }
        public double WFBFlaringUptime { get; set; }
        public double WFBProcessUptime { get; set; }
        public double Gaslift { get; set; }
        public double TotalProducedGas { get; set; }
        public double CumGas { get; set; }
        public double ProdWater { get; set; }
        public double CumWater { get; set; }
        public double EffluentOilInWater { get; set; }
        public double API { get; set; }
        public double ExportAPI { get; set; }
        public double ExportTemp { get; set; }
        public double ExportMetersReadingGross { get; set; }
        public double ExportMetersReadingNet { get; set; }
        public double FieldWaterCut { get; set; }
        public double ExportWaterCut { get; set; }
        public double PumpablecargoonBoard { get; set; }
        public double Adjustment { get; set; }
        public double TotalMeteredGasFlared { get; set; }
        public double ViriniPremStockBalance { get; set; }
        public double BSW { get; set; }
        public double FieldGOR { get; set; }
        public double AdjustedFieldGOR { get; set; }
        public double WaterOverboard { get; set; }
        public double FreeWaterReceived { get; set; }
        public double WaterOverboardMOPU { get; set; }
        public double UllageMeasurement { get; set; }
        public double MOPUcorrectedmeterVariance { get; set; }
        public double BSWManual { get; set; }
        public double BSWAutosampler { get; set; }
        public double OffloadVolume { get; set; }
        public double OffloadBSW { get; set; }
        public double OffloadAPI { get; set; }
        public double Forecast { get; set; }
        public double IdealDayRate { get; set; }
        public double MarketExpectation { get; set; }
        public double Budget { get; set; }
        public double Deferment { get; set; }
        public double EstmatedProdGas { get; set; }
        public double TargetLC { get; set; }
        public double TargetHC { get; set; }
        public double TechnicalAllowable { get; set; }
        public double CommercialAllowable { get; set; }
        public double ActualProdGas { get; set; }
        public double WeeklyAverage { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
    }

    public class EBOKFieldProductionSummaryStaging
    {
        public int Id { get; set; }
        public DateTime IndicatorDate { get; set; }
        public string Uptime { get; set; }
        public string ProdOil { get; set; }
        public string CumProd { get; set; }
        public string ProdGas { get; set; }
        public string WFBAllocatedGas { get; set; }
        public string WFBFlaringUptime { get; set; }
        public double WFBProcessUptime { get; set; }
        public string Gaslift { get; set; }
        public string TotalProducedGas { get; set; }
        public string CumGas { get; set; }
        public string ProdWater { get; set; }
        public string CumWater { get; set; }
        public string EffluentOilInWater { get; set; }
        public string API { get; set; }
        public string ExportAPI { get; set; }
        public string ExportTemp { get; set; }
        public string ExportMetersReadingGross { get; set; }
        public string ExportMetersReadingNet { get; set; }
        public string FieldWaterCut { get; set; }
        public string ExportWaterCut { get; set; }
        public string PumpablecargoonBoard { get; set; }
        public string Adjustment { get; set; }
        public string TotalMeteredGasFlared { get; set; }
        public string ViriniPremStockBalance { get; set; }
        public string BSW { get; set; }
        public string FieldGOR { get; set; }
        public string AdjustedFieldGOR { get; set; }
        public string WaterOverboard { get; set; }
        public string FreeWaterReceived { get; set; }
        public string WaterOverboardMOPU { get; set; }
        public string UllageMeasurement { get; set; }
        public string MOPUcorrectedmeterVariance { get; set; }
        public string BSWManual { get; set; }
        public string BSWAutosampler { get; set; }
        public string OffloadVolume { get; set; }
        public string OffloadBSW { get; set; }
        public string OffloadAPI { get; set; }
        public string Forecast { get; set; }
        public string IdealDayRate { get; set; }
        public string MarketExpectation { get; set; }
        public string Budget { get; set; }
        public string Deferment { get; set; }
        public string EstmatedProdGas { get; set; }
        public string TargetLC { get; set; }
        public string TargetHC { get; set; }
        public string TechnicalAllowable { get; set; }
        public string CommercialAllowable { get; set; }
        public string ActualProdGas { get; set; }
        public string WeeklyAverage { get; set; }
        public DateTime ReportDate { get; set; }
        public String UploadTime { get; set; }
        public DateTime TimeStamp { get; set; }
        public string DayOftheWeek { get; set; }
    }

}