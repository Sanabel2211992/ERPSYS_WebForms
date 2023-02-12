<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCDatesRangeAdv.ascx.cs" Inherits="ERPSYS.Controls.UCDatesRangeAdv" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js" type="text/javascript"></script>
<script src="resources/js/jquery-1.8.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function pageLoad(sender, args) {
        if (args.get_isPartialLoad()) {
            var rangeType = $('#<%= DateRangeList.ClientID%>').val();
            if (rangeType === 6) {
                $('#DatePeriodRow').removeAttr("style");
            }
            else {
                $('#DatePeriodRow').attr("style", "display: none;");
            }
        }
    }
    $(document).ready(function () {
        $('#<%= DateRangeList.ClientID %>').live("change", function () {
            var rangeType = $('#<%= DateRangeList.ClientID %>').val();
            if (rangeType === 6) {
                $('#DatePeriodRow').removeAttr("style");
            }
            else {
                $('#DatePeriodRow').attr("style", "display: none;");
            }
        });
        $('#<%= DateRangeList.ClientID %>').live("click", function (event) {

            $('#<%= DateRangeList.ClientID %>').change();
        });
        $('#<%= DateRangeList.ClientID %>').live("blur", function () {
            $('#<%= DateRangeList.ClientID %>').change();
        });
    });
</script>
<table id="DateRangePickerTable">
    <tr>
        <td id="Td1" runat="server">
            <asp:Label ID="PeriodLabel" runat="server" Text="Period"></asp:Label>
        </td>
        <td id="Td2" colspan="7" class="TdStyle" runat="server">
            <asp:DropDownList ID="DateRangeList" runat="server" SkinIDWidth="100px">
                <asp:ListItem Text="Today" Value="0" />
                <asp:ListItem Text="Yesterday" Value="1" />
                <asp:ListItem Text="Last 7 Days" Value="2" />
                <asp:ListItem Text="Last 14 Days" Value="3" />
                <asp:ListItem Text="Last 30 Days" Value="4" />
                <asp:ListItem Text="Last 60 Days" Value="5" />
                <asp:ListItem Text="Period" Value="6" />
            </asp:DropDownList>
        </td>
    </tr>
    <tr id="DatePeriodRow" style="display: none;">
        <td>
            <asp:Label ID="FromLabel" runat="server" Text="From Date"></asp:Label>
        </td>
        <td width="108">
            <asp:TextBox ID="FromDateTextBox" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td style="height: 20px; padding-top: 5px; width: 50px;">
            <asp:ImageButton ID="FromDateImageButton" runat="server" ImageUrl="resources/images/ico_calendar.png" CausesValidation="False" ImageAlign="Baseline" />
        </td>
        <td>
            <asp:Label ID="ToLabel" runat="server" Text="To Date"></asp:Label>
        </td>
        <td width="108">
            <asp:TextBox ID="ToDateTextBox" runat="server" Width="100px"></asp:TextBox>
        </td>
        <td style="height: 20px; padding-top: 5px; width: 50px;">
            <asp:ImageButton ID="ToDateImageButton" runat="server" ImageUrl="resources/images/ico_calendar.png" CausesValidation="False" ImageAlign="Baseline" />
        </td>
    </tr>
</table>
<ajaxToolkit:CalendarExtender ID="FromDateCalendarExtender" runat="server" Enabled="True" PopupButtonID="FromDateImageButton" TargetControlID="FromDateTextBox"></ajaxToolkit:CalendarExtender>
<ajaxToolkit:MaskedEditExtender ID="FromDateMaskedEditExtender" runat="server" CultureName="ar-EG"
    Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="FromDateTextBox"></ajaxToolkit:MaskedEditExtender>
<ajaxToolkit:MaskedEditValidator ID="FromDateMaskedEditValidator" runat="server"
    Display="Dynamic" ControlExtender="FromDateMaskedEditExtender" ControlToValidate="FromDateTextBox"
    EmptyValueMessage="Required" ErrorMessage="FromDateMaskedEditValidator" InvalidValueMessage="Invalid Date"
    SetFocusOnError="True" IsValidEmpty="False"></ajaxToolkit:MaskedEditValidator>
<ajaxToolkit:CalendarExtender ID="ToDateCalendarExtender" runat="server" Enabled="True"
    PopupButtonID="ToDateImageButton" TargetControlID="ToDateTextBox"></ajaxToolkit:CalendarExtender>
<ajaxToolkit:MaskedEditExtender ID="ToDateMaskedEditExtender" runat="server" CultureName="ar-EG"
    Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="ToDateTextBox"></ajaxToolkit:MaskedEditExtender>
<ajaxToolkit:MaskedEditValidator ID="ToDateMaskedEditValidator" runat="server" Display="Dynamic"
    ControlExtender="ToDateMaskedEditExtender" ControlToValidate="ToDateTextBox"
    EmptyValueMessage="Required" ErrorMessage="ToDateMaskedEditValidator" InvalidValueMessage="Invalid Date"
    SetFocusOnError="True" IsValidEmpty="False"></ajaxToolkit:MaskedEditValidator>