<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="item-Inventory-info.aspx.cs" Inherits="ERPSYS.ERP.t.item_Inventory_info" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <telerik:RadScriptBlock runat="server" ID="rdbScripts">
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    </telerik:RadScriptBlock>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <div>
            <telerik:RadGrid ID="rgInventoryItemList" runat="server"  AllowPaging="False" AutoGenerateColumns="False">
                <MasterTableView ShowHeadersWhenNoRecords="true">
                    <Columns>
                        <telerik:GridBoundColumn DataField="Name" HeaderText="Store Name" HeaderStyle-Width="100px" />
                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="100px" />
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </div>
    </form>
</body>
</html>
