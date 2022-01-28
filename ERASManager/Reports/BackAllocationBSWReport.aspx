﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BackAllocationBSWReport.aspx.cs" Inherits="ERASManager.Reports.BackAllocationBSWReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
              
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="backAllocationBSWReportViewer" runat="server" ShowPrintButton="true"  Width="99.9%" Height="100%" AsyncRendering="true" ZoomMode="Percent" KeepSessionAlive="true" SizeToReportContent="true" ></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
