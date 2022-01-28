using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ERASManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ERASManager.Models.EBOKDailyReport.DailyProductionSummary> DailyProductionSummaries { get; set; }

        public DbSet<ERASManager.Models.EBOKDailyReport.DailySafetySummary> DailySafetySummaries { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.DownTimeLossReason> DownTimeLossReasons { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.OperationsSummary> OperationsSummaries { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CFBWellData> CFBWellData { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WFBWellData> WFBWellData { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WellTestResult> WellTestResults { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CFBGasCompression> CFBGasCompressions { get; set; }

        public DbSet<ERASManager.Models.ReserviorEngineering.PressurePlotFBHPHistoric> PressurePlotFBHPHistorics { get; set; }

        public DbSet<ERASManager.Models.EBOKDailyReport.CFBGasLiftData> CFBGasLiftDatas { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WFBGasLiftData> WFBGasLiftData { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CFBProcessData_GasProduced> CFBProcessData_GasProduced { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CFBProcessData_GasConsumed> CFBProcessData_GasConsumed { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WFBProcessData_GasProduced> WFBProcessData_GasProduced { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WFBProcessData_GasConsumed> WFBProcessData_GasConsumed { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CFBWaterInjectorMeter> CFBWaterInjectorMeters { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WFBWaterInjectorMeter> WFBWaterInjectorMeters { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CFBWaterInjector> CFBWaterInjectors { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WIJManifoldMeter> WIJManifoldMeters { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CFBCrudeExportMeter> CFBCrudeExportMeters { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.ProducedWaterData> ProducedWaterData { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.FSCargoWPData> FSCargoWPData { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.FSOOILQUALITY> FSOOILQUALITIES { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CFBMaintenanceData> CFBMaintenanceData { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WFBMaintenanceData> WFBMaintenanceData { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CONSUMABLESANALYSIS> CONSUMABLESANALYSIS { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.FSOSummary> FSOSummaries { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CFBSummary> CFBSummaries { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.PlantOperationsReport> PlantOperationsReports { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.PlannedMaintenance> PlannedMaintenance { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.UnPlannedMaintenance> UnPlannedMaintenance { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.ProjectActivity> ProjectActivities { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WFBGeneralReport> WFBGeneralReports { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.PendingProjectWorkReport> PendingProjectWorkReports { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.PendingMaintenanceReport> PendingMaintenanceReports { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.UnPlannedMaintenanceReport> UnPlannedMaintenanceReports { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.InstrumentElectrical> InstrumentElectricals { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.EHSSReport> EHSSReports { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.EHSSVEER> EHSSVEERS { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.EHSSVIRINI> EHSSVIRINIS { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.LastAvialableWellTest> LastAvialableWellTests { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WFBGasAllocation> WFBGasAllocations { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.E27GasLift> E27GasLifts { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WellTestEnrichmentData> WellTestEnrichmentData { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.WFBProcessData_Reading> WFBProcessData_Reading { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.CFBProcessData_Reading> CFBProcessData_Reading { get; set; }
        public DbSet<ERASManager.Models.EBOKDailyReport.ProductionPotential> ProductionPotential { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.EKOBDailyProductionIndicator> EKOBDailyProductionIndicator { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.BackAllocationAssumedGOR> BackAllocationAssumedGOR { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.GasInjectorDailyIndicators> GasInjectorDailyIndicators { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.WaterInjectorQuality> WaterInjectorQuality { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.WaterInjectorRateHeader> WaterInjectorRateHeader { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.WaterInjectorRateLineItem> WaterInjectorRateLineItem { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.EBOKGasProductionSummary> EBOKGasProductionSummary { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.BackAllocationBPLD> BackAllocationBPLD { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.EBOKFieldProductionSummary> EBOKFieldProductionSummary { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationActualGOR> BackAllocationActualGOR { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.PressurePlotTCM> PressurePlotTCM { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.GasTrend> GasTrend { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.EBOKProductionSurveillance> EBOKProductionSurveillance { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.EBOKInjectivityIndex> EBOKInjectivityIndex { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.EBOKHallPlotData> EBOKHallPlotData { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQwSummary> BackAllocationQwSummary { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQwHeader> BackAllocationQwHeader { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQw> BackAllocationQw { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQoSummary> BackAllocationQoSummary { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQoHeader> BackAllocationQoHeader { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQoestSummary> BackAllocationQoestSummary { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQoestHeader> BackAllocationQoestHeader { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQoest> BackAllocationQoest { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQo> BackAllocationQo { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQlinkSummary> BackAllocationQlinkSummary { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQlest> BackAllocationQlest { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQgPotentialSummary> BackAllocationQgPotentialSummary { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQgPotentialHeader> BackAllocationQgPotentialHeader { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQgPotential> BackAllocationQgPotential { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationGasAllocationSummary> BackAllocationGasAllocationSummary { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationGasAllocationHeader> BackAllocationGasAllocationHeader { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationGasAllocation> BackAllocationGasAllocation { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationFlowHRS> BackAllocationFlowHRS { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationBSW> BackAllocationBSW { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationBOPD> BackAllocationBOPD { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationActualGORSummary> BackAllocationActualGORSummary { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationActualGORHeader> BackAllocationActualGORHeader { get; set; }
        
            public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQlestHeader> BackAllocationQlestHeader { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQlinkHeader> BackAllocationQlinkHeader { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQlink> BackAllocationQlink { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQgActualSummary> BackAllocationQgActualSummary { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQgActualHeader> BackAllocationQgActualHeader { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQgActual> BackAllocationQgActual { get; set; }

        public DbSet<ERASManager.Models.EBOKTranformedData.BackAllocationAssumedGORStaging> BackAllocationAssumedGORStaging { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.EBOKFieldProductionSummaryStaging> EBOKFieldProductionSummaryStaging { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.BackAllocationBPLDStaging> BackAllocationBPLDStaging { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.EBOKGasProductionSummaryStaging> EBOKGasProductionSummaryStaging { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.EKOBDailyProductionIndicatorStaging> EKOBDailyProductionIndicatorStaging { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.GasInjectorDailyIndicatorsStaging> GasInjectorDailyIndicatorsStaging { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.WaterInjectorQualityStaging> WaterInjectorQualityStaging { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.WaterInjectorRateHeaderStaging> WaterInjectorRateHeaderStaging { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.WaterInjectorRateLineItemStaging> WaterInjectorRateLineItemStaging { get; set; }
        public DbSet<ERASManager.Models.EBOKOutputData.FlowParameter> FlowParameter { get; set; }
        public DbSet<ERASManager.Models.EBOKTranformedData.ManualEntry> ManualEntry { get; set; }

        public System.Data.Entity.DbSet<ERASManager.Models.ReportParameter> ReportParameter { get; set; }

        public DbSet<ERASManager.Models.ReserviorEngineering.PressurePlotFBHP> PressurePlotFBHP { get; set; }
        public DbSet<ERASManager.Models.ReserviorEngineering.FBHPDataHolderWFB> FBHPDataHolderWFB { get; set; }
        public DbSet<ERASManager.Models.ReserviorEngineering.FBHPDataHolderCFB> FBHPDataHolderCFB { get; set; }
        public DbSet<ERASManager.Models.ReserviorEngineering.FBHPDataHolderESP> FBHPDataHolderESP { get; set; }
        public DbSet<ERASManager.Models.ReserviorEngineering.ReserviorWellsDailyData> ReserviorWellsDailyData { get; set; }
        public DbSet<ERASManager.Models.ReserviorEngineering.ReserviorWellsData> ReserviorWellsData { get; set; }
        public DbSet<ERASManager.Models.ReserviorEngineering.ReserviorWellSeperatorData> ReserviorWellSeperatorData { get; set; }
        public DbSet<ERASManager.Models.ReserviorEngineering.ReserviorWellExportLineData> ReserviorWellExportLineData { get; set; }

        public DbSet<ERASManager.Models.Mapping.EBOKFieldProductionMapping> EBOKFieldProductionMapping { get; set; }

        public DbSet<ERASManager.Models.Mapping.EKOBDailyProductionMapping> EKOBDailyProductionMapping { get; set; }

        public DbSet<ERASManager.Models.Mapping.GasAccountingREVMapping> GasAccountingREVMapping { get; set; }

        public DbSet<ERASManager.Models.Mapping.WFBPressurePlotFBHPMapping> WFBPressurePlotFBHPMapping { get; set; }

        public DbSet<ERASManager.Models.Mapping.CFBPressurePlotFBHPMapping> CFBPressurePlotFBHPMapping { get; set; }

        public DbSet<ERASManager.Models.Mapping.ESPPressurePlotFBHPMapping> ESPPressurePlotFBHPMapping { get; set; }
        public DbSet<ERASManager.Models.RevisedBackAllocation.RBackAllocationMaster> RBackAllocationMasters { get; set; }

        public DbSet<ERASManager.Models.RevisedBackAllocation.RBK_TransactionalData> RBK_TransactionalData { get; set; }

        public DbSet<ERASManager.Models.EBOKOutputData.BackAllocationQlestSummary> BackAllocationQlestSummary { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }

       
    }
}
