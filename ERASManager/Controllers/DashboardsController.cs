using ERASManager.Models;
using ERASManager.Models.MasterData;
using ERASManager.Models.EBOKTranformedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;

namespace ERASManager.Controllers
{
    public class DashboardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Dashboards
        public ActionResult EBOKDailyReportDashboard()
        {
            return View();
        }

        public ActionResult EBOKDailyProductionReportDashboard(string myWell)
        {
            if (myWell == "")
            {
                myWell = "Ebok-23 WIJ";
            }

            var alldata = db.EKOBDailyProductionIndicator.Where(w => w.Well == myWell);

            //Prepare Chartist ct-animation-chart
            string[] reportlabel;
            double[] THP;
            double[] FLP;
            double[] BHT;
            double[] BSW;
            double[] NETAPI;
            double[] Uptime;
            double[] GOR;
            double[] PS;
            double[] PWF;
            double[] ChokeSize;
            double[] PI;
            double[] BLPD;
            double[] donutchart;
            string DPTrendData = string.Empty;
            string WaterBWPDData = string.Empty;
            string OILBOPDData = string.Empty;
            string BSWTrend = string.Empty;
            string GasMSCFDData = string.Empty;

            var ProdIndicator = alldata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year && x.Well == myWell)
               .GroupBy(x => x.IndicatorDate.Month)
               .Select(m => new {
                   THP = m.Sum(x => x.THP),
                   FLP = m.Sum(x => x.FLP),
                   BHT = m.Sum(x => x.BHT),
                   BSW = m.Sum(x => x.BSW),
                   NETAPI = m.Sum(x => x.NETAPI),
                   Uptime = m.Sum(x => x.Uptime),
                   GOR = m.Sum(x => x.GOR),
                   PS = m.Sum(x => x.PS),
                   PWF = m.Sum(x => x.PWF),
                   ChokeSize = m.Sum(x => x.ChokeSize),
                   PI = m.Sum(x => x.PI),
                   BLPD = m.Sum(x => x.BLPD),
                   OILBOPD = m.Sum(x => x.OilBOPD),
                   WaterBWPD = m.Sum(x => x.WaterBWPD),
                   GasMSCFD = m.Sum(x => x.GASMSCFD),
                   DP = m.Sum(x => x.DP),
                   ReportMonth = m.Key
               });
            List<double> myTHP = new List<double>();
            List<double> myFLP = new List<double>();
            List<double> myBHT = new List<double>();
            List<double> myBSW = new List<double>();
            List<double> myNETAPI = new List<double>();
            List<double> myUptime = new List<double>();
            List<string> myReportLabel = new List<string>();
            List<double> myGOR = new List<double>();
            List<double> myPS = new List<double>();
            List<double> myPWF = new List<double>();
            List<double> myPI = new List<double>();
            List<double> myChokeSize = new List<double>();
            List<double> myBlpd = new List<double>();
            List<double> myDonutChart = new List<double>();
            int datacount = ProdIndicator.Count();
            int loopcount = 0;
            foreach (var reportitem in ProdIndicator)
            {
                loopcount = loopcount + 1;
                myTHP.Add(reportitem.THP);
                myFLP.Add(reportitem.FLP);
                myBHT.Add(reportitem.BHT);
                myUptime.Add(reportitem.Uptime);
                myBSW.Add(reportitem.BSW);
                myNETAPI.Add(reportitem.NETAPI);
                myGOR.Add(reportitem.GOR);
                myPS.Add(reportitem.PS);
                myPWF.Add(reportitem.PWF);
                myChokeSize.Add(reportitem.ChokeSize);
                myBlpd.Add(reportitem.BLPD);
                myPI.Add(reportitem.PI);
                myReportLabel.Add(reportitem.ReportMonth.ToString());

                //Render Flot Data - BSWTrend
                BSWTrend = "[";
                if (loopcount < datacount)
                {
                    BSWTrend += "[";
                    BSWTrend += string.Format("{0},", reportitem.ReportMonth);
                    BSWTrend += string.Format("{0}", Math.Round(reportitem.BSW, 1));
                    BSWTrend += "],";
                }
                else if (loopcount == datacount)
                {
                    BSWTrend += "[";
                    BSWTrend += string.Format("{0},", reportitem.ReportMonth);
                    BSWTrend += string.Format("{0}", Math.Round(reportitem.BSW, 1));
                    BSWTrend += "]";
                }
                BSWTrend += "]";

                //Render Flot Data - productiontrendchart
                // Render OilBOPD Data
                OILBOPDData = "[";
                if (loopcount < datacount)
                {
                    OILBOPDData += "[";
                    OILBOPDData += string.Format("{0},", reportitem.ReportMonth);
                    OILBOPDData += string.Format("{0}", Math.Round(reportitem.OILBOPD, 1));
                    OILBOPDData += "],";
                }
                else if (loopcount == datacount)
                {
                    OILBOPDData += "[";
                    OILBOPDData += string.Format("{0},", reportitem.ReportMonth);
                    OILBOPDData += string.Format("{0}", Math.Round(reportitem.OILBOPD, 1));
                    OILBOPDData += "]";
                }
                OILBOPDData += "]";

                // Render WaterBWPD Data
                WaterBWPDData = "[";
                if (loopcount < datacount)
                {
                    WaterBWPDData += "[";
                    WaterBWPDData += string.Format("{0},", reportitem.ReportMonth);
                    WaterBWPDData += string.Format("{0}", Math.Round(reportitem.WaterBWPD, 1));
                    WaterBWPDData += "],";
                }
                else if (loopcount == datacount)
                {
                    WaterBWPDData += "[";
                    WaterBWPDData += string.Format("{0},", reportitem.ReportMonth);
                    WaterBWPDData += string.Format("{0}", Math.Round(reportitem.WaterBWPD, 1));
                    WaterBWPDData += "]";
                }
                WaterBWPDData += "]";

                // Render GasMSCFD Data
                GasMSCFDData = "[";
                if (loopcount < datacount)
                {
                    GasMSCFDData += "[";
                    GasMSCFDData += string.Format("{0},", reportitem.ReportMonth);
                    GasMSCFDData += string.Format("{0}", Math.Round(reportitem.GasMSCFD, 1));
                    GasMSCFDData += "],";
                }
                else if (loopcount == datacount)
                {
                    GasMSCFDData += "[";
                    GasMSCFDData += string.Format("{0},", reportitem.ReportMonth);
                    GasMSCFDData += string.Format("{0}", Math.Round(reportitem.GasMSCFD, 1));
                    GasMSCFDData += "]";
                }
                GasMSCFDData += "]";


                // Render DPTrend Data
                DPTrendData = "[";
                if (loopcount < datacount)
                {
                    DPTrendData += "[";
                    DPTrendData += string.Format("{0},", reportitem.ReportMonth);
                    DPTrendData += string.Format("{0}", Math.Round(reportitem.DP, 1));
                    DPTrendData += "],";
                }
                else if (loopcount == datacount)
                {
                    DPTrendData += "[";
                    DPTrendData += string.Format("{0},", reportitem.ReportMonth);
                    DPTrendData += string.Format("{0}", Math.Round(reportitem.DP, 1));
                    DPTrendData += "]";
                }
                DPTrendData += "]";


            }

            // Render Chartist Donut
            DateTime referencedate = DateTime.Today.AddDays(-20);
            var todaysdata = alldata.Where(x => x.IndicatorDate >= referencedate && x.Well == myWell).FirstOrDefault();
            var dChoke = Math.Round(todaysdata.ChokeSize, 1);
            var dUptime = Math.Round(todaysdata.Uptime, 1);
            var dPI = Math.Round(todaysdata.PI, 1);
            var dNetAPI = Math.Round(todaysdata.NETAPI, 1);
            var dBLPD = Math.Round(todaysdata.BLPD, 1);
            var fOILBOPD = Math.Round(todaysdata.OilBOPD, 1);
            var fWaterBWPD = Math.Round(todaysdata.WaterBWPD, 1);
            var fGasMSCFD = Math.Round(todaysdata.GASMSCFD, 1);
            myDonutChart.Add(dChoke);
            myDonutChart.Add(dUptime);
            myDonutChart.Add(dPI);
            myDonutChart.Add(dNetAPI);
            myDonutChart.Add(dBLPD);
            donutchart = myDonutChart.ToArray();
            string[] donutlabel = { "Choke Size", "Uptime", "PI", "NetAPI", "BLPD" };

            // Render Flot Donut - productionindicatorchart
            string productionindicatorchart = "[";
            productionindicatorchart += "{";
            productionindicatorchart += string.Format("label: '{0}',", "OILBOPD");
            productionindicatorchart += string.Format("data: {0},", fOILBOPD);
            productionindicatorchart += string.Format("color: '{0}'", "#4f5467");
            productionindicatorchart += "},";

            productionindicatorchart += "{";
            productionindicatorchart += string.Format("label: '{0}',", "WaterBWPD");
            productionindicatorchart += string.Format("data: {0},", fWaterBWPD);
            productionindicatorchart += string.Format("color: '{0}'", "#009efb");
            productionindicatorchart += "},";

            productionindicatorchart += "{";
            productionindicatorchart += string.Format("label: '{0}',", "GasMSCFD");
            productionindicatorchart += string.Format("data: {0},", fGasMSCFD);
            productionindicatorchart += string.Format("color: '{0}'", "#7460ee");
            productionindicatorchart += "}";

            productionindicatorchart += "]";

            reportlabel = myReportLabel.ToArray();
            THP = myTHP.ToArray();
            FLP = myFLP.ToArray();
            BHT = myBHT.ToArray();
            BSW = myBSW.ToArray();
            NETAPI = myNETAPI.ToArray();
            Uptime = myUptime.ToArray();
            GOR = myGOR.ToArray();
            PS = myPS.ToArray();
            PWF = myPWF.ToArray();
            PI = myPI.ToArray();
            BLPD = myBlpd.ToArray();
            ChokeSize = myChokeSize.ToArray();

            //Parse All JavaScript Values into ViewBags
            ViewBag.reportlabel = reportlabel;
            ViewBag.THP = THP;
            ViewBag.FLP = FLP;
            ViewBag.BHT = BHT;
            ViewBag.BSW = BSW;
            ViewBag.NETAPI = NETAPI;
            ViewBag.Uptime = Uptime;
            ViewBag.GOR = GOR;
            ViewBag.PS = PS;
            ViewBag.PWF = PWF;
            ViewBag.PI = PI;
            ViewBag.BLPD = BLPD;
            ViewBag.ChokeSize = ChokeSize;
            ViewBag.productionindicatorchart = productionindicatorchart;
            ViewBag.donutchart = donutchart;
            ViewBag.donutlabel = donutlabel;
            ViewBag.DPTrendData = DPTrendData;
            ViewBag.GasMSCFDData = GasMSCFDData;
            ViewBag.WaterBWPDData = WaterBWPDData;
            ViewBag.OILBOPDData = OILBOPDData;
            ViewBag.BSWTrend = BSWTrend;



            return View();
        }

        public ActionResult WaterInjectorRateDashboard(string myWell)
        {
            if (myWell == "")
            {
                myWell = "Ebok-23 WIJ";
            }
            ViewBag.WIJWells = db.WaterInjectorRateLineItem.Distinct().Select(i => new SelectListItem() { Text = i.Well, Value = i.Well.ToString() }).ToList();

            var alllinedata = db.WaterInjectorRateLineItem.Where(w => w.Well == myWell);
            var allHeaderdata = db.WaterInjectorRateHeader;
            var allqualitydata = db.WaterInjectorQuality;

            //Prepare Morris Chart 
            //Prepare Morris Chart Data for THIP/FLP/INJRate
            string WaterInjectorRate = "[";
            var monthlyreport = alllinedata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    THIP = m.Sum(x => x.THIP),
                    FLP = m.Sum(x => x.FLP),
                    INJRate = m.Sum(x => x.INJRate),
                    ReportMonth = m.Key
                });
            int datacount = monthlyreport.Count();
            int loopcount = 0;
            foreach (var reportitem in monthlyreport)
            {
                loopcount = loopcount + 1;
                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (loopcount < datacount)
                {
                    WaterInjectorRate += "{";
                    WaterInjectorRate += string.Format("period: '{0}',", chartMonth);
                    WaterInjectorRate += string.Format("THIP: {0},", Math.Round(reportitem.THIP, 1));
                    WaterInjectorRate += string.Format("FLP: {0},", Math.Round(reportitem.FLP, 1));
                    WaterInjectorRate += string.Format("INJRate: {0}", Math.Round(reportitem.INJRate, 1));
                    WaterInjectorRate += "},";
                }
                else if (loopcount == datacount)
                {
                    WaterInjectorRate += "{";
                    WaterInjectorRate += string.Format("period: '{0}',", chartMonth);
                    WaterInjectorRate += string.Format("THIP: {0},", Math.Round(reportitem.THIP, 1));
                    WaterInjectorRate += string.Format("FLP: {0},", Math.Round(reportitem.FLP, 1));
                    WaterInjectorRate += string.Format("INJRate: {0}", Math.Round(reportitem.INJRate, 1));
                    WaterInjectorRate += "}";
                }
            }
            WaterInjectorRate += "]";

            //Prepare Morris Chart Data for uptime/THIP
            string uWaterInjectorRate = "[";
            var uWaterInjectorRatereport = alllinedata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    UpTime = m.Sum(x => x.UpTime),
                    THIP = m.Sum(x => x.THIP),
                    ReportMonth = m.Key
                });
            int Gasdatacount = uWaterInjectorRatereport.Count();
            int Gasloopcount = 0;
            foreach (var reportitem in uWaterInjectorRatereport)
            {
                Gasloopcount = Gasloopcount + 1;
                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (Gasloopcount < Gasdatacount)
                {
                    uWaterInjectorRate += "{";
                    uWaterInjectorRate += string.Format("period: '{0}',", chartMonth);
                    uWaterInjectorRate += string.Format("UpTime: {0},", Math.Round(reportitem.UpTime, 1));
                    uWaterInjectorRate += string.Format("THIP: {0}", Math.Round(reportitem.THIP, 1));
                    uWaterInjectorRate += "},";
                }
                else if (Gasloopcount == Gasdatacount)
                {
                    uWaterInjectorRate += "{";
                    uWaterInjectorRate += string.Format("period: '{0}',", chartMonth);
                    uWaterInjectorRate += string.Format("UpTime: {0},", Math.Round(reportitem.UpTime, 1));
                    uWaterInjectorRate += string.Format("THIP: {0}", Math.Round(reportitem.THIP, 1));
                    uWaterInjectorRate += "}";
                }
            }
            uWaterInjectorRate += "]";

            //Prepare Morris Chart Data Total Water Injected - Line Chart
            string TotalWaterInjected = "[";
            var TotalWaterInjectedData = allHeaderdata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    TotalWaterInj = m.Sum(x => x.TotalWaterInj),
                    ReportMonth = m.Key
                });
            int koddatacount = TotalWaterInjectedData.Count();
            int kodloopcount = 0;
            foreach (var reportitem in TotalWaterInjectedData)
            {
                kodloopcount = kodloopcount + 1;
                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (kodloopcount < koddatacount)
                {
                    TotalWaterInjected += "{";
                    TotalWaterInjected += string.Format("period: '{0}',", chartMonth);
                    TotalWaterInjected += string.Format("TotalWaterInj: {0}", Math.Round(reportitem.TotalWaterInj, 1));
                    TotalWaterInjected += "},";
                }
                else if (kodloopcount == koddatacount)
                {
                    TotalWaterInjected += "{";
                    TotalWaterInjected += string.Format("period: '{0}',", chartMonth);
                    TotalWaterInjected += string.Format("TotalWaterInj: {0}", Math.Round(reportitem.TotalWaterInj, 1));
                    TotalWaterInjected += "}";
                }
            }
            TotalWaterInjected += "]";

            // Get Data for Donut
            DateTime Indicatorcompare = DateTime.Today.AddDays(-20);
            var todaysdata = allqualitydata.Where(x => x.IndicatorDate == Indicatorcompare).FirstOrDefault();
            var PH = Math.Round(todaysdata.PH, 1);
            var ParticlesUpstream = Math.Round(todaysdata.ParticlesUpstream, 1);
            var ParticlesDownStream = Math.Round(todaysdata.ParticlesDownStream, 1);

            //Prepare Morris Chart Data Bar Chart - Gas Flared

            string HeaderQuality = "[";

            var HeaderQualityreport = allHeaderdata.Join(allqualitydata, h => h.IndicatorDate, q => q.IndicatorDate, (h, q) => new { h.TotalWaterInj, q.ParticlesDownStream, q.ParticlesUpstream, h.IndicatorDate }).Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    TotalWaterInj = m.Sum(x => x.TotalWaterInj),
                    ParticlesUpstream = m.Sum(x => x.ParticlesUpstream),
                    ParticlesDownStream = m.Sum(x => x.ParticlesDownStream),
                    ReportMonth = m.Key
                });
            int GasFlareddatacount = HeaderQualityreport.Count();
            int GasFlaredloopcount = 0;
            foreach (var reportitem in HeaderQualityreport)
            {
                GasFlaredloopcount = GasFlaredloopcount + 1;
                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (GasFlaredloopcount < GasFlareddatacount)
                {
                    HeaderQuality += "{";
                    HeaderQuality += string.Format("period: '{0}',", chartMonth);
                    HeaderQuality += string.Format("TotalWaterInj: {0},", Math.Round(reportitem.TotalWaterInj, 1));
                    HeaderQuality += string.Format("ParticlesUpstream: {0},", Math.Round(reportitem.ParticlesUpstream, 1));
                    HeaderQuality += string.Format("ParticlesDownStream: {0}", Math.Round(reportitem.ParticlesDownStream, 1));
                    HeaderQuality += "},";
                }
                else if (GasFlaredloopcount == GasFlareddatacount)
                {
                    HeaderQuality += "{";
                    HeaderQuality += string.Format("period: '{0}',", chartMonth);
                    HeaderQuality += string.Format("TotalWaterInj: {0},", Math.Round(reportitem.TotalWaterInj, 1));
                    HeaderQuality += string.Format("ParticlesUpstream: {0},", Math.Round(reportitem.ParticlesUpstream, 1));
                    HeaderQuality += string.Format("ParticlesDownStream: {0}", Math.Round(reportitem.ParticlesDownStream, 1));
                    HeaderQuality += "}";
                }
            }
            HeaderQuality += "]";

            //Prepare Morris Chart Data for PH/ParticleUpstream/Particle Downstream
            string WaterInjectorQuality = "[";
            var WaterInjectorQualityreport = allqualitydata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    PH = m.Sum(x => x.PH),
                    ParticlesDownStream = m.Sum(x => x.ParticlesDownStream),
                    ParticlesUpstream = m.Sum(x => x.ParticlesUpstream),
                    ReportMonth = m.Key
                });
            int qdatacount = WaterInjectorQualityreport.Count();
            int qloopcount = 0;
            foreach (var reportitem in WaterInjectorQualityreport)
            {
                qloopcount = qloopcount + 1;
                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (qloopcount < qdatacount)
                {
                    WaterInjectorQuality += "{";
                    WaterInjectorQuality += string.Format("period: '{0}',", chartMonth);
                    WaterInjectorQuality += string.Format("PH: {0},", Math.Round(reportitem.PH, 1));
                    WaterInjectorQuality += string.Format("ParticlesDownStream: {0},", Math.Round(reportitem.ParticlesDownStream, 1));
                    WaterInjectorQuality += string.Format("ParticlesUpstream: {0}", Math.Round(reportitem.ParticlesUpstream, 1));
                    WaterInjectorQuality += "},";
                }
                else if (qloopcount == qdatacount)
                {
                    WaterInjectorQuality += "{";
                    WaterInjectorQuality += string.Format("period: '{0}',", chartMonth);
                    WaterInjectorQuality += string.Format("PH: {0},", Math.Round(reportitem.PH, 1));
                    WaterInjectorQuality += string.Format("ParticlesDownStream: {0},", Math.Round(reportitem.ParticlesDownStream, 1));
                    WaterInjectorQuality += string.Format("ParticlesUpstream: {0}", Math.Round(reportitem.ParticlesUpstream, 1));
                    WaterInjectorQuality += "}";
                }
            }
            WaterInjectorQuality += "]";

            //Import all Data Element to a viewbag
            ViewBag.WaterInjectorQuality = WaterInjectorQuality;
            ViewBag.HeaderQuality = HeaderQuality;
            ViewBag.PH = PH;
            ViewBag.ParticlesUpstream = ParticlesUpstream;
            ViewBag.ParticlesDownStream = ParticlesDownStream;
            ViewBag.TotalWaterInjected = TotalWaterInjected;
            ViewBag.uWaterInjectorRate = uWaterInjectorRate;
            ViewBag.WaterInjectorRate = WaterInjectorRate;
            return View();
        }

        public ActionResult GasInjectorDailyIndicatorDashboard()
        {
            //Run Data For Data Grid
            var alldata = db.GasInjectorDailyIndicators;
            DateTime Weekcompare = DateTime.Today.AddDays(-20);
            var weekdata = alldata.Where(x => x.IndicatorDate >= Weekcompare);

            // Prepare Data For First Report Campaign
            double[] IFLP;
            double[] ITHP;
            double[] weekUptime;
            double[] weekGasInject;
            double[] weekIBHP;
            double[] IBHT;
            double[] IBHP;
            string[] ReportIndicator;


            var GasArray = alldata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
               .GroupBy(x => x.IndicatorDate.Month)
               .Select(m => new {
                   IFLP = m.Sum(x => x.IFLP),
                   ITHP = m.Sum(x => x.ITHP),
                   Uptime = m.Sum(x => x.Uptime),
                   GasInject = m.Sum(x => x.GasInject),
                   IBHP = m.Sum(x => x.IBHP),
                   IBHT = m.Sum(x => x.IBHT),
                   ReportMonth = m.Key
               });
            List<double> myIFLP = new List<double>();
            List<double> myITHP = new List<double>();
            List<double> myweekUptime = new List<double>();
            List<double> myweekGasInject = new List<double>();
            List<double> myweekIBHP = new List<double>();
            List<double> myIBHP = new List<double>();
            List<double> myIBHT = new List<double>();
            List<string> myReportIndicator = new List<string>();

            int datacount = GasArray.Count();
            int loopcount = 0;
            string GasInjectTrend = "[";
            foreach (var reportitem in GasArray)
            {
                loopcount = loopcount + 1;
                myIFLP.Add(reportitem.IFLP);
                myITHP.Add(reportitem.ITHP);
                myweekUptime.Add(reportitem.Uptime);
                myweekGasInject.Add(reportitem.GasInject);
                myweekIBHP.Add(reportitem.IBHP);
                myIBHP.Add(reportitem.IBHP);
                myIBHT.Add(reportitem.IBHT);
                myReportIndicator.Add(reportitem.ReportMonth.ToString());

                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (loopcount < datacount)
                {
                    GasInjectTrend += "{";
                    GasInjectTrend += string.Format("period: '{0}',", chartMonth);
                    GasInjectTrend += string.Format("Uptime: {0},", Math.Round(reportitem.Uptime, 1));
                    GasInjectTrend += string.Format("GasInject: {0}", Math.Round(reportitem.GasInject, 1));
                    GasInjectTrend += "},";
                }
                else if (loopcount == datacount)
                {
                    GasInjectTrend += "{";
                    GasInjectTrend += string.Format("period: '{0}',", chartMonth);
                    GasInjectTrend += string.Format("Uptime: {0},", Math.Round(reportitem.Uptime, 1));
                    GasInjectTrend += string.Format("GasInject: {0}", Math.Round(reportitem.GasInject, 1));
                    GasInjectTrend += "}";
                }
            }
            GasInjectTrend += "]";
            IFLP = myIFLP.ToArray();
            ITHP = myITHP.ToArray();
            weekUptime = myweekUptime.ToArray();
            weekGasInject = myweekGasInject.ToArray();
            weekIBHP = myweekIBHP.ToArray();
            IBHT = myIBHP.ToArray();
            IBHP = myIBHT.ToArray();
            ReportIndicator = myReportIndicator.ToArray();

            //Get Daily Indicator Data

            DateTime dayCompare = DateTime.Today.AddDays(-20);
            var todaysdata = alldata.Where(x => x.IndicatorDate >= dayCompare).FirstOrDefault();
            var dUptime = todaysdata.Uptime;
            var dGasInject = todaysdata.GasInject;
            var dIBHP = todaysdata.IBHP;
            var dIFLP = todaysdata.IFLP;
            var dIBHT = todaysdata.IBHT;
            var dITHP = todaysdata.ITHP;
            var ChokeSize = todaysdata.ChokeSize;
            var IndicatorDate = todaysdata.IndicatorDate;
            var CompDischPress = todaysdata.CompDischPress;

            //Parse Data to ViewBag
            ViewBag.dUptime = dUptime;
            ViewBag.dGasInject = dGasInject;
            ViewBag.dIBHP = dIBHP;
            ViewBag.dIFLP = dIFLP;
            ViewBag.dIBHT = dIBHT;
            ViewBag.ChokeSize = ChokeSize;
            ViewBag.IndicatorDate = IndicatorDate;
            ViewBag.CompDischPress = CompDischPress;
            ViewBag.GasInjectTrend = GasInjectTrend;
            ViewBag.IFLP = IFLP;
            ViewBag.ITHP = ITHP;
            ViewBag.weekUptime = weekUptime;
            ViewBag.weekGasInject = weekGasInject;
            ViewBag.weekIBHP = weekIBHP;
            ViewBag.IBHT = IBHT;
            ViewBag.IBHP = IBHP;
            ViewBag.dITHP = dITHP;
            ViewBag.ReportIndicator = ReportIndicator;


            return View(weekdata);
        }

        public ActionResult EBOKGasProductionSummaryDashboard()
        {
            // Get Sparkline Dash Charts
            double[] weekTwoPhaseSeperator;
            double[] weekTestSeperator;
            double[] weekProdSeperator;
            double[] weekWFBGasFlare;
            double[] weekWFBAllocatedGas;
            double[] weekTotalGasLift;
            double[] weekMeteredInjGas;

            var alldata = db.EBOKGasProductionSummary;
            DateTime Weekcompare = DateTime.Today.AddDays(-20);
            var weekdata = alldata.Where(x => x.IndicatorDate >= Weekcompare);
            weekTwoPhaseSeperator = weekdata.Select(x => x.TwoPhaseSeperator).ToArray();
            weekTestSeperator = weekdata.Select(x => x.TestSeperator).ToArray();
            weekProdSeperator = weekdata.Select(x => x.ProductionSeperator).ToArray();
            weekWFBGasFlare = weekdata.Select(x => x.WFBGasFlared).ToArray();
            weekWFBAllocatedGas = weekdata.Select(x => x.WFBAllocatedgas).ToArray();
            weekTotalGasLift = weekdata.Select(x => x.TOTALGasLift).ToArray();
            weekMeteredInjGas = weekdata.Select(x => x.MeteredGasInjected).ToArray();

            // Get Sparkline Indicators
            DateTime Indicatorcompare = DateTime.Today.AddDays(-20);
            var todaysdata = alldata.Where(x => x.IndicatorDate == Indicatorcompare).FirstOrDefault();
            var TwoPhaseSeperator = Math.Round(todaysdata.TwoPhaseSeperator, 1);
            var TestSeperator = Math.Round(todaysdata.TestSeperator, 1);
            var ProdSeperator = Math.Round(todaysdata.ProductionSeperator, 1);
            var WFBAllocatedGas = Math.Round(todaysdata.WFBAllocatedgas, 1);
            var TotalGasLift = Math.Round(todaysdata.TOTALGasLift, 1);
            var WFBGasLift = Math.Round(todaysdata.WFBGasLift, 1);
            var CFBGasLift = Math.Round(todaysdata.CFBGasLift, 1);
            var FuelGasKOD = Math.Round(todaysdata.FuelGasKOD, 1);
            var HPFlare = Math.Round(todaysdata.HPFLARE, 1);
            var LPFlare = Math.Round(todaysdata.LPFLARE, 1);
            var WFBGasFlare = Math.Round(todaysdata.WFBGasFlared, 1);
            var GTCompressor = Math.Round(todaysdata.GTCompressorconsumption, 1);
            var CalInjGas = Math.Round(todaysdata.CalcuatedInjectedGas, 1);
            var MeteredInjGas = Math.Round(todaysdata.MeteredGasInjected, 1);

            //Get Totals for Donut Chart
            var WFBProcessTotal = Math.Round(todaysdata.WFBPROCESSTOTAL, 1);
            var TOTALGasLift = Math.Round(todaysdata.TOTALGasLift, 1);
            var GASUtilizationTotal = Math.Round(todaysdata.GASUtilizationTotal, 1);
            var TotalMeteredGasFlared = Math.Round(todaysdata.TotalMeteredGasFlared, 1);
            var GASFLAREDTOTAL = Math.Round(todaysdata.GASFLAREDTOTAL, 1);

            //Prepare Morris Chart 
            //Prepare Morris Chart Data Gas Lift Compare
            string GasLiftCompare = "[";
            var monthlyreport = alldata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    CFBGasLift = m.Sum(x => x.CFBGasLift),
                    WFBGasLift = m.Sum(x => x.WFBGasLift),
                    UtilizationTotal = m.Sum(x => x.GASUtilizationTotal),
                    ReportMonth = m.Key
                });
            int datacount = monthlyreport.Count();
            int loopcount = 0;
            foreach (var reportitem in monthlyreport)
            {
                loopcount = loopcount + 1;
                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (loopcount < datacount)
                {
                    GasLiftCompare += "{";
                    GasLiftCompare += string.Format("period: '{0}',", chartMonth);
                    GasLiftCompare += string.Format("CFBGasLift: {0},", Math.Round(reportitem.CFBGasLift, 1));
                    GasLiftCompare += string.Format("WFBGasLift: {0},", Math.Round(reportitem.WFBGasLift, 1));
                    GasLiftCompare += string.Format("UtilizationTotal: {0}", Math.Round(reportitem.UtilizationTotal, 1));
                    GasLiftCompare += "},";
                }
                else if (loopcount == datacount)
                {
                    GasLiftCompare += "{";
                    GasLiftCompare += string.Format("period: '{0}',", chartMonth);
                    GasLiftCompare += string.Format("CFBGasLift: {0},", Math.Round(reportitem.CFBGasLift, 1));
                    GasLiftCompare += string.Format("WFBGasLift: {0},", Math.Round(reportitem.WFBGasLift, 1));
                    GasLiftCompare += string.Format("UtilizationTotal: {0}", Math.Round(reportitem.UtilizationTotal, 1));
                    GasLiftCompare += "}";
                }
            }
            GasLiftCompare += "]";

            //Prepare Morris Chart Data Gas Injected Compare
            string GasInjectionCompare = "[";
            var GasInjreport = alldata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    CalculatedInjGas = m.Sum(x => x.CalcuatedInjectedGas),
                    MeteredInjGas = m.Sum(x => x.MeteredGasInjected),
                    ReportMonth = m.Key
                });
            int Gasdatacount = GasInjreport.Count();
            int Gasloopcount = 0;
            foreach (var reportitem in GasInjreport)
            {
                Gasloopcount = Gasloopcount + 1;
                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (Gasloopcount < Gasdatacount)
                {
                    GasInjectionCompare += "{";
                    GasInjectionCompare += string.Format("period: '{0}',", chartMonth);
                    GasInjectionCompare += string.Format("CalculatedInjGas: {0},", Math.Round(reportitem.CalculatedInjGas, 1));
                    GasInjectionCompare += string.Format("MeteredInjGas: {0}", Math.Round(reportitem.CalculatedInjGas, 1));
                    GasInjectionCompare += "},";
                }
                else if (Gasloopcount == Gasdatacount)
                {
                    GasInjectionCompare += "{";
                    GasInjectionCompare += string.Format("period: '{0}',", chartMonth);
                    GasInjectionCompare += string.Format("CalculatedInjGas: {0},", Math.Round(reportitem.CalculatedInjGas, 1));
                    GasInjectionCompare += string.Format("MeteredInjGas: {0}", Math.Round(reportitem.MeteredInjGas, 1));
                    GasInjectionCompare += "}";
                }
            }
            GasInjectionCompare += "]";

            //Prepare Morris Chart Data Fuel Gas KOD - Line Chart
            string FuelGasKODRep = "[";
            var FuelGasKOData = alldata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    FuelGasKOD = m.Sum(x => x.CalcuatedInjectedGas),
                    ReportMonth = m.Key
                });
            int koddatacount = FuelGasKOData.Count();
            int kodloopcount = 0;
            foreach (var reportitem in FuelGasKOData)
            {
                kodloopcount = kodloopcount + 1;
                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (kodloopcount < koddatacount)
                {
                    FuelGasKODRep += "{";
                    FuelGasKODRep += string.Format("period: '{0}',", chartMonth);
                    FuelGasKODRep += string.Format("FuelGasKOD: {0}", Math.Round(reportitem.FuelGasKOD, 1));
                    FuelGasKODRep += "},";
                }
                else if (kodloopcount == koddatacount)
                {
                    FuelGasKODRep += "{";
                    FuelGasKODRep += string.Format("period: '{0}',", chartMonth);
                    FuelGasKODRep += string.Format("FuelGasKOD: {0}", Math.Round(reportitem.FuelGasKOD, 1));
                    FuelGasKODRep += "}";
                }
            }
            FuelGasKODRep += "]";
            //Prepare Morris Chart Data Bar Chart - Gas Flared

            string GasFlaredCompare = "[";
            var GasFlaredreport = alldata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    HPFLARE = m.Sum(x => x.HPFLARE),
                    LPFLARE = m.Sum(x => x.LPFLARE),
                    WFBGasFlared = m.Sum(x => x.WFBGasFlared),
                    ReportMonth = m.Key
                });
            int GasFlareddatacount = GasFlaredreport.Count();
            int GasFlaredloopcount = 0;
            foreach (var reportitem in GasFlaredreport)
            {
                GasFlaredloopcount = GasFlaredloopcount + 1;
                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (GasFlaredloopcount < GasFlareddatacount)
                {
                    GasFlaredCompare += "{";
                    GasFlaredCompare += string.Format("period: '{0}',", chartMonth);
                    GasFlaredCompare += string.Format("HPFLARE: {0},", Math.Round(reportitem.HPFLARE, 1));
                    GasFlaredCompare += string.Format("LPFLARE: {0},", Math.Round(reportitem.LPFLARE, 1));
                    GasFlaredCompare += string.Format("WFBGasFlared: {0}", Math.Round(reportitem.WFBGasFlared, 1));
                    GasFlaredCompare += "},";
                }
                else if (GasFlaredloopcount == GasFlareddatacount)
                {
                    GasFlaredCompare += "{";
                    GasFlaredCompare += string.Format("period: '{0}',", chartMonth);
                    GasFlaredCompare += string.Format("HPFLARE: {0},", Math.Round(reportitem.HPFLARE, 1));
                    GasFlaredCompare += string.Format("LPFLARE: {0},", Math.Round(reportitem.LPFLARE, 1));
                    GasFlaredCompare += string.Format("WFBGasFlared: {0}", Math.Round(reportitem.WFBGasFlared, 1));
                    GasFlaredCompare += "}";
                }
            }
            GasFlaredCompare += "]";

            //JavaScript Fullback
            ViewBag.weekTwoPhaseSeperator = weekTwoPhaseSeperator;
            ViewBag.weekTestSeperator = weekTestSeperator;
            ViewBag.weekProdSeperator = weekProdSeperator;
            ViewBag.weekWFBGasFlare = weekWFBGasFlare;
            ViewBag.weekWFBAllocatedGas = weekWFBAllocatedGas;
            ViewBag.weekTotalGasLift = weekTotalGasLift;
            ViewBag.weekMeteredInjGas = weekMeteredInjGas;

            ViewBag.TwoPhaseSeperator = TwoPhaseSeperator;
            ViewBag.TestSeperator = TestSeperator;
            ViewBag.ProdSeperator = ProdSeperator;
            ViewBag.WFBAllocatedGas = WFBAllocatedGas;
            ViewBag.TotalGasLift = TotalGasLift;
            ViewBag.WFBGasLift = WFBGasLift;
            ViewBag.CFBGasLift = CFBGasLift;
            ViewBag.FuelGasKOD = FuelGasKOD;
            ViewBag.HPFlare = HPFlare;
            ViewBag.LPFlare = LPFlare;
            ViewBag.WFBGasFlare = WFBGasFlare;
            ViewBag.GTCompressor = GTCompressor;
            ViewBag.CalInjGas = CalInjGas;
            ViewBag.MeteredInjGas = MeteredInjGas;

            ViewBag.WFBProcessTotal = WFBProcessTotal;
            ViewBag.TOTALGasLift = TOTALGasLift;
            ViewBag.GASUtilizationTotal = GASUtilizationTotal;
            ViewBag.TotalMeteredGasFlared = TotalMeteredGasFlared;
            ViewBag.GASFLAREDTOTAL = GASFLAREDTOTAL;

            ViewBag.GasLiftCompare = GasLiftCompare;
            ViewBag.GasInjectionCompare = GasInjectionCompare;
            ViewBag.FuelGasKODRep = FuelGasKODRep;
            ViewBag.GasFlaredCompare = GasFlaredCompare;


            return View();
        }

        public ActionResult EBOKFieldProductionSummaryDashboard()
        {
            // Get ProdOil Sparkline Dash
            double[] weekprodoil;
            double[] weekcumoil;
            double[] weekprodgas;
            double[] weekUllage;
            double[] weekTotalProdGas;
            double[] weekprodwater;
            double[] weekpumpablecargo;
            double[] weekbsw;
            double[] weekfieldgor;
            double[] weekapi;
            double[] weekvirinpremstock;
            double[] weekwateroverboard;
            double[] weekfreewaterreceived;
            double[] weekpie;
            var alldata = db.EBOKFieldProductionSummary;
            DateTime Weekcompare = DateTime.Today.AddDays(-20);
            var weekdata = alldata.Where(x => x.IndicatorDate >= Weekcompare);
            weekprodoil = weekdata.Select(x => x.ProdOil).ToArray();
            weekcumoil = weekdata.Select(x => x.CumProd).ToArray();
            weekprodgas = weekdata.Select(x => x.ProdGas).ToArray();
            weekUllage = weekdata.Select(x => x.UllageMeasurement).ToArray();
            weekTotalProdGas = weekdata.Select(x => x.TotalProducedGas).ToArray();
            weekprodwater = weekdata.Select(x => x.ProdWater).ToArray();
            weekpumpablecargo = weekdata.Select(x => x.PumpablecargoonBoard).ToArray();
            weekbsw = weekdata.Select(x => x.BSW).ToArray();
            weekfieldgor = weekdata.Select(x => x.FieldGOR).ToArray();
            weekapi = weekdata.Select(x => x.API).ToArray();
            weekvirinpremstock = weekdata.Select(x => x.ViriniPremStockBalance).ToArray();
            weekwateroverboard = weekdata.Select(x => x.WaterOverboard).ToArray();
            weekfreewaterreceived = weekdata.Select(x => x.FreeWaterReceived).ToArray();

            List<double> pielist = new List<double>();

            // Get Indicators - change to minus 1 later
            DateTime Indicatorcompare = DateTime.Today.AddDays(-20);
            var todaysdata = alldata.Where(x => x.IndicatorDate == Indicatorcompare).FirstOrDefault();
            var Prodoil = Math.Round(todaysdata.ProdOil, 1);
            var CumOil = Math.Round(todaysdata.CumProd, 1);
            var ProdGas = Math.Round(todaysdata.ProdGas, 1);
            var FieldGOR = Math.Round(todaysdata.FieldGOR, 1);
            var CumGas = Math.Round(todaysdata.CumGas, 1);
            var WFBAllocatedGas = Math.Round(todaysdata.WFBAllocatedGas, 1);
            var TotalProducedGas = Math.Round(todaysdata.TotalProducedGas, 1);
            var GasLift = Math.Round(todaysdata.Gaslift, 1);
            var ProdWater = Math.Round(todaysdata.ProdWater, 1);
            var OilinWater = Math.Round(todaysdata.EffluentOilInWater, 1);
            var GCrude = Math.Round(todaysdata.ExportMetersReadingGross, 1);
            var NCrude = Math.Round(todaysdata.ExportMetersReadingNet, 1);
            var BSW = Math.Round(todaysdata.BSW, 1);
            var CumWater = Math.Round(todaysdata.CumWater, 1);
            var Fieldwatercut = Math.Round(todaysdata.FieldWaterCut, 1);
            var wateroverboard = Math.Round(todaysdata.WaterOverboard, 1);
            var ullage = Math.Round(todaysdata.UllageMeasurement, 1);
            var cumwater = Math.Round(todaysdata.CumWater, 1);
            var pumpablecargo = Math.Round(todaysdata.PumpablecargoonBoard, 1);
            pielist.Add(Prodoil);
            pielist.Add(Fieldwatercut);
            pielist.Add(wateroverboard);
            weekpie = pielist.ToArray();

            //Prepare Morris Chart Data ProdOil Vs ProdWater
            string ProdCompare = "[";
            var monthlyreport = alldata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    ProdOil = m.Sum(x => x.ProdOil),
                    ProdWater = m.Sum(x => x.ProdWater),
                    ReportMonth = m.Key
                });
            int datacount = monthlyreport.Count();
            int loopcount = 0;
            foreach (var reportitem in monthlyreport)
            {
                loopcount = loopcount + 1;
                int MonthNumber = reportitem.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }

                if (loopcount < datacount)
                {
                    ProdCompare += "{";
                    ProdCompare += string.Format("period: '{0}',", chartMonth);
                    ProdCompare += string.Format("ProdOil: {0},", Math.Round(reportitem.ProdOil, 1));
                    ProdCompare += string.Format("ProdWater: {0}", Math.Round(reportitem.ProdWater, 1));
                    ProdCompare += "},";
                }
                else if (loopcount == datacount)
                {
                    ProdCompare += "{";
                    ProdCompare += string.Format("period: '{0}',", chartMonth);
                    ProdCompare += string.Format("ProdOil: {0},", Math.Round(reportitem.ProdOil, 1));
                    ProdCompare += string.Format("ProdWater: {0}", Math.Round(reportitem.ProdWater, 1));
                    ProdCompare += "}";
                }
            }

            ProdCompare += "]";

            //Prepare Morris Chart Data Export Reading Analysis
            string ExportReading = "[";
            var ExportReadingReport = alldata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    GrossCrude = m.Sum(x => x.ExportMetersReadingGross),
                    NetCrude = m.Sum(x => x.ExportMetersReadingNet),
                    UllageMeasurement = m.Sum(x => x.UllageMeasurement),
                    ReportMonth = m.Key
                });
            int exportcount = ExportReadingReport.Count();
            int exportloopcount = 0;
            foreach (var exportreading in ExportReadingReport)
            {
                exportloopcount = exportloopcount + 1;
                int MonthNumber = exportreading.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }
                if (exportloopcount < exportcount)
                {
                    ExportReading += "{";
                    ExportReading += string.Format("period: '{0}',", chartMonth);
                    ExportReading += string.Format("GrossCrude: {0},", Math.Round(exportreading.GrossCrude, 1));
                    ExportReading += string.Format("NetCrude: {0},", Math.Round(exportreading.NetCrude, 1));
                    ExportReading += string.Format("UllageMeasurement: {0}", Math.Round(exportreading.UllageMeasurement, 1));
                    ExportReading += "},";
                }
                else if (exportloopcount == exportcount)
                {
                    ExportReading += "{";
                    ExportReading += string.Format("period: '{0}',", chartMonth);
                    ExportReading += string.Format("GrossCrude: {0},", Math.Round(exportreading.GrossCrude, 1));
                    ExportReading += string.Format("NetCrude: {0},", Math.Round(exportreading.NetCrude, 1));
                    ExportReading += string.Format("UllageMeasurement: {0}", Math.Round(exportreading.UllageMeasurement, 1));
                    ExportReading += "}";
                }
            }

            ExportReading += "]";

            //Prepare Morris Chart Cummulative Water/Oil/Gas
            string CumReading = "[";
            var CumReadingReport = alldata.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year)
                .GroupBy(x => x.IndicatorDate.Month)
                .Select(m => new {
                    CumOil = m.Sum(x => x.CumProd),
                    CumWater = m.Sum(x => x.CumWater),
                    CumGas = m.Sum(x => x.CumGas),
                    ReportMonth = m.Key
                });
            int Cumcount = CumReadingReport.Count();
            int Cumloopcount = 0;
            foreach (var cumreading in CumReadingReport)
            {
                Cumloopcount = Cumloopcount + 1;
                int MonthNumber = cumreading.ReportMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }
                if (Cumloopcount < Cumcount)
                {
                    CumReading += "{";
                    CumReading += string.Format("period: '{0}',", chartMonth);
                    CumReading += string.Format("CumOil: {0},", Math.Round(cumreading.CumOil, 1));
                    CumReading += string.Format("CumWater: {0},", Math.Round(cumreading.CumWater, 1));
                    CumReading += string.Format("CumGas: {0}", Math.Round(cumreading.CumGas * 1000, 1));
                    CumReading += "},";
                }
                else if (Cumloopcount == Cumcount)
                {
                    CumReading += "{";
                    CumReading += string.Format("period: '{0}',", chartMonth);
                    CumReading += string.Format("CumOil: {0},", Math.Round(cumreading.CumOil, 1));
                    CumReading += string.Format("CumWater: {0},", Math.Round(cumreading.CumWater, 1));
                    CumReading += string.Format("CumGas: {0}", Math.Round(cumreading.CumGas, 1));
                    CumReading += "}";
                }
            }

            CumReading += "]";

            //Javascript ViewBags
            ViewBag.weekprodoil = weekprodoil;
            ViewBag.Prodoil = Prodoil;
            ViewBag.CumOil = CumOil;
            ViewBag.ProdGas = ProdGas;
            ViewBag.FieldGOR = FieldGOR;
            ViewBag.pumpablecargo = pumpablecargo;
            ViewBag.ullage = ullage;
            ViewBag.cumwater = cumwater;
            ViewBag.CumGas = CumGas;
            ViewBag.WFBAllocatedGas = WFBAllocatedGas;
            ViewBag.TotalProducedGas = TotalProducedGas;
            ViewBag.GasLift = GasLift;
            ViewBag.ProdWater = ProdWater;
            ViewBag.OilinWater = OilinWater;
            ViewBag.GCrude = GCrude;
            ViewBag.NCrude = NCrude;
            ViewBag.weekcumoil = weekcumoil;
            ViewBag.weekprodgas = weekprodgas;
            ViewBag.weekUllage = weekUllage;
            ViewBag.weekTotalProdGas = weekTotalProdGas;
            ViewBag.weekprodwater = weekprodwater;
            ViewBag.weekpumpablecargo = weekpumpablecargo;
            ViewBag.weekbsw = weekbsw;
            ViewBag.weekapi = weekapi;
            ViewBag.weekvirinpremstock = weekvirinpremstock;
            ViewBag.weekwateroverboard = weekwateroverboard;
            ViewBag.weekfreewaterreceived = weekfreewaterreceived;
            ViewBag.weekpie = weekpie;
            ViewBag.weekfieldgor = weekfieldgor;
            ViewBag.ProdCompare = ProdCompare;
            ViewBag.ExportReading = ExportReading;
            ViewBag.CumReading = CumReading;


            return View();
        }

        public ActionResult BackAllocationDashboard(string myWell)
        {

            if (myWell == "")
            {
                myWell = "Ebok-30";
            }
            //Get Qo Data For Model View
            DateTime Weekcompare = DateTime.Today.AddDays(-20);
            var Qomodel = db.BackAllocationQo.Where(w => w.Well == myWell && w.IndicatorDate >= Weekcompare);

            //Get all Label Indicator Data
            // Get Sparkline Indicators
            DateTime Indicatorcompare = DateTime.Today.AddDays(-20);

            List<ConsolidatedBackAllocation> consolidatedBackAllocation = new List<ConsolidatedBackAllocation>();


            consolidatedBackAllocation = db.Database.SqlQuery<ConsolidatedBackAllocation>(
        "exec dbo.[GetConsolidatedBackAllocation] @IndicatorDate,@Well",
       new SqlParameter("@IndicatorDate", Indicatorcompare),
       new SqlParameter("@Well", myWell)
        ).ToList();

            var todaysData = consolidatedBackAllocation.FirstOrDefault();

            var ActualGOR = Math.Round(todaysData.ActualGOR, 1);
            var BOPD = Math.Round(todaysData.BOPD, 1);
            var BLPD = Math.Round(todaysData.BPLD, 1);
            var BSW = Math.Round(todaysData.BSW, 1);
            var FLOWHRS = Math.Round(todaysData.Uptime, 1);
            var GasAllocation = Math.Round(todaysData.GasAllocation, 1);
            var QgActual = Math.Round(todaysData.QgActual, 1);
            var QgPotential = Math.Round(todaysData.QgPotential, 1);
            var Qlest = Math.Round(todaysData.Qlest, 1);
            var Qlink = Math.Round(todaysData.Qlink, 1);
            var Qo = Math.Round(todaysData.Qo, 1);
            var Qw = Math.Round(todaysData.Qw, 1);
            var Qoest = Math.Round(todaysData.Qoest, 1);
            var IndicatorDate = todaysData.IndicatorDate;

            // Render Flot Donut - Prod Oil vs BOPD vs BPLD vs Assumed GOR vs Actual GOR
            string donutIndicatorChart = "[";
            donutIndicatorChart += "{";
            donutIndicatorChart += string.Format("label: '{0}',", "BOPD");
            donutIndicatorChart += string.Format("data: {0},", BOPD);
            donutIndicatorChart += string.Format("color: '{0}'", "#4f5467");
            donutIndicatorChart += "},";

            donutIndicatorChart += "{";
            donutIndicatorChart += string.Format("label: '{0}',", "BPLD");
            donutIndicatorChart += string.Format("data: {0},", BLPD);
            donutIndicatorChart += string.Format("color: '{0}'", "#009efb");
            donutIndicatorChart += "},";

            donutIndicatorChart += "{";
            donutIndicatorChart += string.Format("label: '{0}',", "FLOWHRS");
            donutIndicatorChart += string.Format("data: {0},", FLOWHRS);
            donutIndicatorChart += string.Format("color: '{0}'", "#009efb");
            donutIndicatorChart += "},";

            donutIndicatorChart += "{";
            donutIndicatorChart += string.Format("label: '{0}',", "Qlest");
            donutIndicatorChart += string.Format("data: {0},", Qlest);
            donutIndicatorChart += string.Format("color: '{0}'", "#009efb");
            donutIndicatorChart += "},";

            donutIndicatorChart += "{";
            donutIndicatorChart += string.Format("label: '{0}',", "Qlink");
            donutIndicatorChart += string.Format("data: {0},", Qlink);
            donutIndicatorChart += string.Format("color: '{0}'", "#009efb");
            donutIndicatorChart += "},";


            donutIndicatorChart += "{";
            donutIndicatorChart += string.Format("label: '{0}',", "BSW");
            donutIndicatorChart += string.Format("data: {0},", BSW);
            donutIndicatorChart += string.Format("color: '{0}'", "#7460ee");
            donutIndicatorChart += "}";

            donutIndicatorChart += "]";

            // Get all Summary Data from Stored Procedure
            // Get QlestSummaryData

            List<transposeBackAllocation> qlestSummaryData = new List<transposeBackAllocation>();
            qlestSummaryData = db.Database.SqlQuery<transposeBackAllocation>(
        "exec dbo.[GetQlestSummaryByIndicatorDate] @IndicatorDate",
       new SqlParameter("@IndicatorDate", IndicatorDate)
        ).ToList();

            var myqlestSummaryData = qlestSummaryData.FirstOrDefault();
            double CFBQlest = Math.Round(myqlestSummaryData.CFB, 1);
            double WFBQlest = Math.Round(myqlestSummaryData.WFB, 1);
            double TotalQlest = CFBQlest + WFBQlest;


            // Get all Summary Data from Stored Procedure
            // Get QoSummaryData

            List<transposeBackAllocation> qoSummaryData = new List<transposeBackAllocation>();
            qoSummaryData = db.Database.SqlQuery<transposeBackAllocation>(
        "exec dbo.[GetQoSummaryByIndicatorDate] @IndicatorDate",
       new SqlParameter("@IndicatorDate", IndicatorDate)
        ).ToList();

            var myqoSummaryData = qoSummaryData.FirstOrDefault();
            double CFBQo = Math.Round(myqlestSummaryData.CFB, 1);
            double WFBQo = Math.Round(myqlestSummaryData.WFB, 1);
            double TotalQo = CFBQo + WFBQo;

            // Get all Summary Data from Stored Procedure
            // Get QlinkSummaryData

            List<transposeBackAllocation> qlinkSummaryData = new List<transposeBackAllocation>();
            qlinkSummaryData = db.Database.SqlQuery<transposeBackAllocation>(
        "exec dbo.[GetQlinkSummaryByIndicatorDate] @IndicatorDate",
       new SqlParameter("@IndicatorDate", IndicatorDate)
        ).ToList();

            var myqlinkSummaryData = qlinkSummaryData.FirstOrDefault();
            double CFBQlink = Math.Round(myqlinkSummaryData.CFB, 1);
            double WFBQlink = Math.Round(myqlinkSummaryData.WFB, 1);
            double TotalQlink = CFBQlink + WFBQlink;

            // Get all Summary Data from Stored Procedure
            // Get QgActualSummaryData

            List<transposeBackAllocation> qgactualSummaryData = new List<transposeBackAllocation>();
            qgactualSummaryData = db.Database.SqlQuery<transposeBackAllocation>(
        "exec dbo.[GetQgActualSummaryByIndicatorDate] @IndicatorDate",
       new SqlParameter("@IndicatorDate", IndicatorDate)
        ).ToList();

            var myqgactualSummaryData = qgactualSummaryData.FirstOrDefault();
            double CFBQgActual = Math.Round(myqlinkSummaryData.CFB, 1);
            double WFBQgActual = Math.Round(myqlinkSummaryData.WFB, 1);
            double TotalQgActual = CFBQgActual + WFBQgActual;


            // Get all Summary Data from Stored Procedure
            // Get QgPotentialSummaryData

            List<transposeBackAllocation> qgpotentialSummaryData = new List<transposeBackAllocation>();
            qgpotentialSummaryData = db.Database.SqlQuery<transposeBackAllocation>(
        "exec dbo.[GetQgPotentialSummaryByIndicatorDate] @IndicatorDate",
       new SqlParameter("@IndicatorDate", IndicatorDate)
        ).ToList();

            var myqgpotentialSummaryData = qgpotentialSummaryData.FirstOrDefault();
            double CFBQgPotential = Math.Round(myqgpotentialSummaryData.CFB, 1);
            double WFBQgPotential = Math.Round(myqgpotentialSummaryData.WFB, 1);
            double TotalQgPotential = CFBQgPotential + WFBQgPotential;


            // Get all Summary Data from Stored Procedure
            // Get QgGasAllocationSummaryData

            List<transposeBackAllocation> gasAllocationSummaryData = new List<transposeBackAllocation>();
            gasAllocationSummaryData = db.Database.SqlQuery<transposeBackAllocation>(
        "exec dbo.[GetGasAllocationSummaryByIndicatorDate] @IndicatorDate",
       new SqlParameter("@IndicatorDate", IndicatorDate)
        ).ToList();

            var mygasAllocationSummaryData = gasAllocationSummaryData.FirstOrDefault();
            double CFBGasAllocation = Math.Round(mygasAllocationSummaryData.CFB, 1);
            double WFBGasAllocation = Math.Round(mygasAllocationSummaryData.WFB, 1);
            double TotalGasAllocation = CFBGasAllocation + WFBGasAllocation;


            // Get Weekly Data from Sparkline Graphs

            DateTime weekdate = DateTime.Today.AddDays(-20);

            List<ConsolidatedBackAllocation> weekconsolidatedBackAllocation = new List<ConsolidatedBackAllocation>();


            weekconsolidatedBackAllocation = db.Database.SqlQuery<ConsolidatedBackAllocation>(
        "exec dbo.[GetWeeklyConsolidatedBackAllocation] @IndicatorDate,@Well",
       new SqlParameter("@IndicatorDate", IndicatorDate),
       new SqlParameter("@Well", myWell)
        ).ToList();

            //Prepare Weekly Array
            double[] weekFLOWHRS;
            double[] weekGasAllocation;
            double[] weekQgActual;
            double[] weekQgPotential;
            double[] weekQlest;
            double[] weekQlink;
            double[] weekQo;


            weekFLOWHRS = weekconsolidatedBackAllocation.Select(x => x.Uptime).ToArray();
            weekGasAllocation = weekconsolidatedBackAllocation.Select(x => x.GasAllocation).ToArray();
            weekQgActual = weekconsolidatedBackAllocation.Select(x => x.QgActual).ToArray();
            weekQgPotential = weekconsolidatedBackAllocation.Select(x => x.QgPotential).ToArray();
            weekQlest = weekconsolidatedBackAllocation.Select(x => x.Qlest).ToArray();
            weekQlink = weekconsolidatedBackAllocation.Select(x => x.Qlink).ToArray();
            weekQo = weekconsolidatedBackAllocation.Select(x => x.Qo).ToArray();

            //Prepare Yearly Summary Data Distributed By Month
            List<YearlyConsolidatedBackAllocation> yearlyconsolidatedBackAllocation = new List<YearlyConsolidatedBackAllocation>();

            yearlyconsolidatedBackAllocation = db.Database.SqlQuery<YearlyConsolidatedBackAllocation>(
       "exec dbo.[GetYearlyConsolidatedBackAllocation] @Well",
      new SqlParameter("@Well", myWell)
       ).ToList();

            //Get data for BackAllocation Qw flot-line chart moving

            double[] BackAllocationQw;
            double[] BackAllocationQo;
            double[] yearlyAssumedGOR;
            double[] yearlyActualGOR;
            double[] yearlyBOPD;
            double[] yearlyQlink;
            double[] yearlyQlest;


            List<double> myBackAllocationQw = new List<double>();
            List<double> myBackAllocationQo = new List<double>();
            List<double> myyearlyAssumedGOR = new List<double>();
            List<double> myyearlyActualGOR = new List<double>();
            List<double> myyearlyBOPD = new List<double>();
            List<double> myyearlyQlink = new List<double>();
            List<double> myyearlyQlest = new List<double>();
            int datacount = yearlyconsolidatedBackAllocation.Count();
            int loopcount = 0;
            var morrisdatacompare = "[";
            var flotBackAllocationFlowHrs = "[";
            foreach (var reportitem in yearlyconsolidatedBackAllocation)
            {
                loopcount = loopcount + 1;
                myBackAllocationQw.Add(reportitem.Qw);
                myBackAllocationQo.Add(reportitem.Qo);
                myyearlyAssumedGOR.Add(reportitem.AssumedGOR);
                myyearlyActualGOR.Add(reportitem.ActualGOR);
                myyearlyBOPD.Add(reportitem.BOPD);
                myyearlyQlink.Add(reportitem.Qlink);
                myyearlyQlest.Add(reportitem.Qlest);
                int MonthNumber = reportitem.IndicatorMonth;
                string chartMonth = String.Empty;
                if (MonthNumber <= 9)
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-0" + MonthNumber.ToString();
                }
                else
                {
                    chartMonth = DateTime.Today.Year.ToString() + "-" + MonthNumber.ToString();
                }
                if (loopcount < datacount)
                {
                    morrisdatacompare += "{";
                    morrisdatacompare += string.Format("period: '{0}',", chartMonth);
                    morrisdatacompare += string.Format("BPLD: {0},", Math.Round(reportitem.BPLD, 1));
                    morrisdatacompare += string.Format("BOPD: {0},", Math.Round(reportitem.BOPD, 1));
                    morrisdatacompare += string.Format("BSW: {0}", Math.Round(reportitem.BSW, 1));
                    morrisdatacompare += "},";

                    flotBackAllocationFlowHrs += "[";
                    flotBackAllocationFlowHrs += string.Format("{0},", reportitem.IndicatorMonth);
                    flotBackAllocationFlowHrs += string.Format("{0}", Math.Round(reportitem.Uptime, 1));
                    flotBackAllocationFlowHrs += "],";
                }
                else if (loopcount == datacount)
                {
                    morrisdatacompare += "{";
                    morrisdatacompare += string.Format("period: '{0}',", chartMonth);
                    morrisdatacompare += string.Format("BPLD: {0},", Math.Round(reportitem.BPLD, 1));
                    morrisdatacompare += string.Format("BOPD: {0},", Math.Round(reportitem.BOPD, 1));
                    morrisdatacompare += string.Format("BSW: {0}", Math.Round(reportitem.BSW, 1));
                    morrisdatacompare += "}";

                    flotBackAllocationFlowHrs += "[";
                    flotBackAllocationFlowHrs += string.Format("{0},", reportitem.IndicatorMonth);
                    flotBackAllocationFlowHrs += string.Format("{0}", Math.Round(reportitem.Uptime, 1));
                    flotBackAllocationFlowHrs += "]";
                }




            }

            BackAllocationQw = myBackAllocationQw.ToArray();
            BackAllocationQo = myBackAllocationQo.ToArray();
            yearlyAssumedGOR = myyearlyAssumedGOR.ToArray();
            yearlyActualGOR = myyearlyActualGOR.ToArray();

            yearlyQlink = myyearlyQlink.ToArray();
            yearlyQlest = myyearlyQlest.ToArray();

            yearlyBOPD = myyearlyBOPD.ToArray();
            morrisdatacompare += "]";
            flotBackAllocationFlowHrs += "]";

            // Get Consolidated Header Data
            List<ConsolidatedBackAllocationHeader> consolidatedBackAllocationHeader = new List<ConsolidatedBackAllocationHeader>();


            consolidatedBackAllocationHeader = db.Database.SqlQuery<ConsolidatedBackAllocationHeader>(
        "exec dbo.[GetConsolidatedBackAllocationHeaders] @IndicatorDate",
       new SqlParameter("@IndicatorDate", IndicatorDate)
        ).ToList();
            var myconsolidatedBackAllocationHeader = consolidatedBackAllocationHeader.FirstOrDefault();

            var headerActualGOR = Math.Round(myconsolidatedBackAllocationHeader.ActualGOR, 1);
            var headerActualGasProduced = Math.Round(myconsolidatedBackAllocationHeader.ActualGasProduced, 1);
            var headerGasAllocation = Math.Round(myconsolidatedBackAllocationHeader.GasAllocation, 1);
            var headerGasDifference = Math.Round(myconsolidatedBackAllocationHeader.GasDifference, 1);
            var headerQgActual = Math.Round(myconsolidatedBackAllocationHeader.ActualGOR, 1);
            var headerQgPotential = Math.Round(myconsolidatedBackAllocationHeader.QgPotential, 1);
            var headerProdOil = Math.Round(myconsolidatedBackAllocationHeader.ProdOil, 1);
            var headerTotalQlink = Math.Round(myconsolidatedBackAllocationHeader.TotalQlink, 1);
            var headerWellTestActual = Math.Round(myconsolidatedBackAllocationHeader.WellTestActual, 1);
            var headerwellTestPotential = Math.Round(myconsolidatedBackAllocationHeader.wellTestPotential, 1);
            var headerQo = Math.Round(myconsolidatedBackAllocationHeader.Qo, 1);
            var headerQw = Math.Round(myconsolidatedBackAllocationHeader.Qw, 1);


            //Parse All JavaScript Values into ViewBags
            ViewBag.ActualGOR = ActualGOR;
            ViewBag.BOPD = BOPD;
            ViewBag.BLPD = BLPD;
            ViewBag.BSW = BSW;
            ViewBag.FLOWHRS = FLOWHRS;
            ViewBag.GasAllocation = GasAllocation;
            ViewBag.QgActual = QgActual;
            ViewBag.QgPotential = QgPotential;
            ViewBag.Qlest = Qlest;
            ViewBag.Qlink = Qlink;
            ViewBag.IndicatorDate = IndicatorDate;
            ViewBag.donutIndicatorChart = donutIndicatorChart;
            ViewBag.CFBQlest = CFBQlest;
            ViewBag.WFBQlest = WFBQlest;
            ViewBag.TotalQlest = TotalQlest;
            ViewBag.CFBQo = CFBQo;
            ViewBag.WFBQo = WFBQo;
            ViewBag.TotalQo = TotalQo;
            ViewBag.CFBQlink = CFBQlink;
            ViewBag.WFBQlink = WFBQlink;
            ViewBag.TotalQlink = TotalQlink;
            ViewBag.CFBQgActual = CFBQgActual;
            ViewBag.WFBQgActual = WFBQgActual;
            ViewBag.TotalQgActual = TotalQgActual;
            ViewBag.CFBQgPotential = CFBQgPotential;
            ViewBag.WFBQgPotential = WFBQgPotential;
            ViewBag.TotalQgPotential = TotalQgPotential;
            ViewBag.CFBGasAllocation = CFBGasAllocation;
            ViewBag.WFBGasAllocation = WFBGasAllocation;
            ViewBag.TotalGasAllocation = TotalGasAllocation;
            ViewBag.weekFLOWHRS = weekFLOWHRS;
            ViewBag.weekGasAllocation = weekGasAllocation;
            ViewBag.weekQgActual = weekQgActual;
            ViewBag.weekQgPotential = weekQgPotential;
            ViewBag.weekQlest = weekQlest;
            ViewBag.weekQlink = weekQlink;
            ViewBag.weekQo = weekQo;
            ViewBag.BackAllocationQw = BackAllocationQw;
            ViewBag.BackAllocationQo = BackAllocationQo;
            ViewBag.morrisdatacompare = morrisdatacompare;
            ViewBag.flotBackAllocationFlowHrs = flotBackAllocationFlowHrs;
            ViewBag.Qo = Qo;
            ViewBag.Qoest = Qoest;
            ViewBag.Qw = Qw;
            ViewBag.headerActualGOR = headerActualGOR;
            ViewBag.headerActualGasProduced = headerActualGasProduced;
            ViewBag.headerGasAllocation = headerGasAllocation;
            ViewBag.headerGasDifference = headerGasDifference;
            ViewBag.headerQgActual = headerQgActual;
            ViewBag.headerQgPotential = headerQgPotential;
            ViewBag.headerProdOil = headerProdOil;
            ViewBag.headerTotalQlink = headerTotalQlink;
            ViewBag.headerWellTestActual = headerWellTestActual;
            ViewBag.headerwellTestPotential = headerwellTestPotential;
            ViewBag.headerQo = headerQo;
            ViewBag.headerQw = headerQw;
            ViewBag.yearlyAssumedGOR = yearlyAssumedGOR;
            ViewBag.yearlyActualGOR = yearlyActualGOR;
            ViewBag.yearlyBOPD = yearlyBOPD;
            ViewBag.donutIndicatorChart = donutIndicatorChart;

            return View(Qomodel);
        }

        public ActionResult EBOKHallPlotDataDashboard()
        {
            return View();
        }

        public ActionResult EBOKInjectivityIndexDashboard()
        {
            return View();
        }

        public ActionResult FlowParameter(string myWell)
        {
            //if (myWell == "")
            //{
            //    myWell = "Ebok-30";
            //}

            //var monthlyreport = db.FlowParameter.Where(x => x.IndicatorDate.Year >= DateTime.Today.Year && y=> y.Well = myWell)
            //   .GroupBy(x => x.IndicatorDate.Month)
            //   .Select(m => new {
            //       CFBGasLift = m.Sum(x => x.CFBGasLift),
            //       WFBGasLift = m.Sum(x => x.WFBGasLift),
            //       UtilizationTotal = m.Sum(x => x.GASUtilizationTotal),
            //       ReportMonth = m.Key
            //   });

            return View();
        }

        public ActionResult GasTrend()
        {
            return View();
        }

        public ActionResult PressurePlotTCM()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}