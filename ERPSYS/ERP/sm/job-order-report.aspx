<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="job-order-report.aspx.cs" Inherits="ERPSYS.ERP.sm.JobOrderReport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=16.2.22.914, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <div style="width: 850px; display: block; margin-left: auto; margin-right: auto;">
        <fieldset>
            <table style="width: 100%">
                <tr>
                    <td class="field-title" style="width: 100px">Report View :</td>
                    <td class="field-val">
                        <asp:RadioButtonList ID="rblReportView" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblReportView_SelectedIndexChanged" RepeatDirection="Horizontal" Width="225px">
                            <asp:ListItem Selected="True" Value="Combined">Combined View</asp:ListItem>
                            <asp:ListItem Value="Group">Group View</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div style="width: 850px; display: block; margin-left: auto; margin-right: auto;">
        <telerik:ReportViewer ID="reportViewer" runat="server" Width="100%" Height="1100px" ZoomMode="FullPage" ParametersAreaVisible="False" ShowDocumentMapButton="False" ShowHistoryButtons="False" ShowParametersButton="False" Skin="WebBlue"></telerik:ReportViewer>
    </div>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="raManager" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rblReportView">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="reportViewer" UpdatePanelCssClass="" LoadingPanelID="lpLoading" />
                    <telerik:AjaxUpdatedControl ControlID="rblReportView" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
</asp:Content>
