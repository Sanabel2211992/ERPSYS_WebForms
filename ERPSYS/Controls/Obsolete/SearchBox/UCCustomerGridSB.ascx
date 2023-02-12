<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCustomerGridSB.ascx.cs" Inherits="ERPSYS.Controls.SearchBox.UCCustomerGridSB" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            var timer = null;

            function KeyUp() {
                if (timer != null) {
                    clearTimeout(timer);
                }
                timer = setTimeout(LoadTable, 500);
                alert('issa');
            }

            function LoadTable() {
                $find("<%= raManager.ClientID %>").ajaxRequest("FilterGrid");
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="raManager" runat="server" OnAjaxRequest="raManager_AjaxRequest">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="raManager">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="lpLoading" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="lpLoading" runat="server" Height="75px"
        Width="75px" Transparency="25">
        <%-- <img alt="Loading..." src='<%= RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Ajax.loading.gif") %>'
            style="border: 0px;" />--%>
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadTextBox ID="RadTextBox1" runat="server" EmptyMessage="Search Customer Name" LabelWidth="64px" Resize="None" Width="450px">
    </telerik:RadTextBox>
    <br />


    <asp:TextBox ID="TextBox1" onkeyup="KeyUp();" runat="server"></asp:TextBox>
    <telerik:RadGrid ID="RadGrid1" AllowPaging="true" PageSize="5"
        runat="server" OnNeedDataSource="RadGrid1_NeedDataSource" Width="100%">
        <PagerStyle Mode="NextPrevAndNumeric" />
    </telerik:RadGrid>
</div>
