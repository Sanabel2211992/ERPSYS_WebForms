<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCDatePickerX.ascx.cs" Inherits="ERPSYS.Controls.UCDatePickerX" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<table width="150px">
    <tr>
        <td nowrap="nowrap">
            <asp:TextBox ID="txtDate" runat="server" Width="125px" contentEditable="false" />
            <asp:ImageButton runat="Server" Width="16" Height="16" ID="imgCalender" ImageUrl="resources/images/ico_calendar.png"
                AlternateText="Calendar" CausesValidation="False" />
            <asp:RequiredFieldValidator runat="server" ID="rfvDate" ControlToValidate="txtDate" SetFocusOnError="True"
                Display="Dynamic" ErrorMessage="*" InitialValue="" CssClass="val-error" />
        </td>
    </tr>
</table>
<asp:CalendarExtender ID="cbeDate" runat="server" TargetControlID="txtDate"
    PopupButtonID="imgCalender"></asp:CalendarExtender>
<script type="text/javascript">
    function ClearDate() {
        document.getElementById('<%= txtDate.ClientID %>').value = "";
    }
</script>