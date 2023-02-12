<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemImage.ascx.cs" Inherits="ERPSYS.Controls.Image.Item.ItemImage" %>
<table class="tbl-inner" style="width: 900px">
    <tr>
        <td>
            <asp:Image ID="imgItem" runat="server" Height="150px" Width="150px" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:FileUpload ID="ImgUpload" runat="server" Width="233px" />
            <br />
            <asp:CheckBox ID="cbClearImage" runat="server" Text="Clear item picture" />
        </td>
    </tr>
</table>
