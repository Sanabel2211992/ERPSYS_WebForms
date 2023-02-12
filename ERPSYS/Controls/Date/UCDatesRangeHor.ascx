<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCDatesRangeHor.ascx.cs" Inherits="ERPSYS.Controls.UCDatesRangeHor" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script type="text/javascript" src="resources/js/calender.js"></script>
<table width="365">
    <tr>
        <td width="125" runat="server" id="Td1" valign="middle">
            <asp:TextBox ID="txtDateFrom" runat="server" Width="95" ReadOnly="true" />
            <asp:ImageButton runat="Server" Width="16" Height="16" ID="imgCalenderFrom" ImageUrl="resources/images/ico_calendar.png"
                AlternateText="Start Date" />
        </td>
        <td width="35">
            <b>and</b>
        </td>
        <td width="125" runat="server" id="Td2" valign="middle">
            <asp:TextBox ID="txtDateTo" runat="server" Width="95" ReadOnly="true" />
            <asp:ImageButton runat="Server" Width="16" Height="16" ID="imgCalenderTo" ImageUrl="resources/images/ico_calendar.png"
                AlternateText="End Date" Enabled="true" />
        </td>
    </tr>
</table>
<asp:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDateFrom"
    PopupButtonID="imgCalenderFrom"></asp:CalendarExtender>
<asp:CalendarExtender ID="calendarButtonExtender2" runat="server" TargetControlID="txtDateTo"
    PopupButtonID="imgCalenderTo"></asp:CalendarExtender>
