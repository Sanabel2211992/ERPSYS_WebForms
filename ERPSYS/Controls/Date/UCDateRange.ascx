<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCDateRange.ascx.cs" Inherits="ERPSYS.Controls.Date.UCDateRange" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script type="text/javascript" src="../resources/js/calender.js"></script>
<script type="text/javascript">
    function ClearDate() {
        cleardate('<%=txtDateFrom.ClientID%>', '<%=txtDateTo.ClientID%>');
    }
</script>
<table style="width: 360px">
    <tr>
        <td style="width: 35px">From
        </td>
        <td style="width: 125px">
            <asp:TextBox ID="txtDateFrom" runat="server" Width="95" />
            <asp:ImageButton runat="Server" Width="16" Height="16" ID="imgCalenderFrom" ImageUrl="../resources/images/ico_calendar.png" AlternateText="Start Date" />
        </td>
        <td style="width: 25px">To
        </td>
        <td style="width: 125px">
            <asp:TextBox ID="txtDateTo" runat="server" Width="95" />
            <asp:ImageButton runat="Server" Width="16" Height="16" ID="imgCalenderTo" ImageUrl="../resources/images/ico_calendar.png" AlternateText="End Date" Enabled="true" />
        </td>
        <td style="width: 25px; text-align: left">
            <img src="../../Controls/resources/images/ico_clear_16_16.png" alt="clear" onclick="cleardate('<%=txtDateFrom.ClientID%>', '<%=txtDateTo.ClientID%>')" />
        </td>
    </tr>
</table>
<asp:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDateFrom" PopupButtonID="imgCalenderFrom"></asp:CalendarExtender>
<asp:CalendarExtender ID="calendarButtonExtender2" runat="server" TargetControlID="txtDateTo" PopupButtonID="imgCalenderTo"></asp:CalendarExtender>
