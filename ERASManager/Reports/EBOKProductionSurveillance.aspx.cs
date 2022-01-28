using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERASManager.Reports
{
    public partial class EBOKProductionSurveillance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    String reportFolder = System.Configuration.ConfigurationManager.AppSettings["SSRSReportsFolder"].ToString();

                    eBOKProductionSurveillanceViewer.Height = Unit.Pixel(Convert.ToInt32(Request["Height"]) - 58);
                    eBOKProductionSurveillanceViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;

                    eBOKProductionSurveillanceViewer.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer"); // Add the Reporting Server URL  
                    eBOKProductionSurveillanceViewer.ServerReport.ReportPath = String.Format("/{0}/{1}", reportFolder, Request["ReportName"].ToString());

                    eBOKProductionSurveillanceViewer.ServerReport.Refresh();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}