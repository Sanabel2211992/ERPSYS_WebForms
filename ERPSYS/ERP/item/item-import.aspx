<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="item-import.aspx.cs" Inherits="ERPSYS.ERP.item.ItemImport" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <div style="background: grey">
        <div>
            Select a Excel file to import. 
        </div>
        <div>
            <asp:FileUpload ID="fileuploader" runat="server" Width="450px" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Load File" />
        </div>
    </div>
    <div>
        <telerik:RadGrid ID="RadGrid1" runat="server"></telerik:RadGrid>
    </div>
</asp:Content>
