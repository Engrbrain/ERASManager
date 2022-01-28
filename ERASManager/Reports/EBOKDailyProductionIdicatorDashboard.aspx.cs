using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERASManager.Reports
{
    public partial class EBOKDailyProductionIdicatorDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    String reportFolder = System.Configuration.ConfigurationManager.AppSettings["SSRSReportsFolder"].ToString();

                    eBOKDailyProductionIdicatorDashboardViewer.Height = Unit.Pixel(Convert.ToInt32(Request["Height"]) - 58);
                    eBOKDailyProductionIdicatorDashboardViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;

                    eBOKDailyProductionIdicatorDashboardViewer.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer"); // Add the Reporting Server URL  
                    eBOKDailyProductionIdicatorDashboardViewer.ServerReport.ReportPath = String.Format("/{0}/{1}", reportFolder, Request["ReportName"].ToString());

                    eBOKDailyProductionIdicatorDashboardViewer.ServerReport.Refresh();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}