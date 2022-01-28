using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERASManager.Reports
{
    public partial class EBOKHallPlot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    String reportFolder = System.Configuration.ConfigurationManager.AppSettings["SSRSReportsFolder"].ToString();

                    eBOKHallPlotViewer.Height = Unit.Pixel(Convert.ToInt32(Request["Height"]) - 58);
                    eBOKHallPlotViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;

                    eBOKHallPlotViewer.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer"); // Add the Reporting Server URL  
                    eBOKHallPlotViewer.ServerReport.ReportPath = String.Format("/{0}/{1}", reportFolder, Request["ReportName"].ToString());

                    eBOKHallPlotViewer.ServerReport.Refresh();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}