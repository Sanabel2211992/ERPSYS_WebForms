<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="pro-invoice-report.aspx.cs" Inherits="ERPSYS.ERP.sm.ProformaInvoiceReport" %>


<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=16.2.22.914, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <div style="width: 850px; display: block; margin-left: auto; margin-right: auto;">
        <telerik:ReportViewer ID="reportViewer" runat="server" Width="100%" Height="1100px" ZoomMode="FullPage" ParametersAreaVisible="False" ShowDocumentMapButton="False" ShowHistoryButtons="False" ShowParametersButton="False" Skin="WebBlue"></telerik:ReportViewer>
    </div>
</asp:Content>
