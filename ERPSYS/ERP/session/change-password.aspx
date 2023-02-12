<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="change-password.aspx.cs" Inherits="ERPSYS.ERP.session.change_password" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
    <style type="text/css">
        .Base {
            display: inline-block;
            font: 12px/18px "segoe ui",arial,sans-serif;
            height: 16px;
            overflow: hidden;
            text-align: center;
            vertical-align: middle;
            width: 100px;
            color: #fff;
            border: 0px solid #333;
        }

        .L0 {
            background-image: url(../resources/images/star_zero.png);
            background-repeat: no-repeat;
            background-size: 80px;
        }

        .L1 {
            background-image: url(../resources/images/star_one.png);
            background-repeat: no-repeat;
            background-size: 80px;
        }

        .L2 {
            background-image: url(../resources/images/star_tow.png);
            background-repeat: no-repeat;
            background-size: 80px;
        }

        .L3 {
            background-image: url(../resources/images/star_three.png);
            background-repeat: no-repeat;
            background-size: 80px;
        }

        .L4 {
            background-image: url(../resources/images/star_four.png);
            background-repeat: no-repeat;
            background-size: 80px;
        }

        .L5 {
            background-image: url(../resources/images/star_five.png);
            background-repeat: no-repeat;
            background-size: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <fieldset class="fs-edit">
                    <legend class="fs-edit-legend">Password Information</legend>
                    <table class="tbl-edit" style="width: 1050px">
                        <tr>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 225px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 225px"></th>
                            <th class="ft-edit" style="width: 125px"></th>
                            <th class="fv-edit" style="width: 225px"></th>
                        </tr>
                        <tr>
                            <td class="ft-edit">Password :</td>
                            <td class="fv-edit" colspan="2">
                                <telerik:RadTextBox ID="rtxtPassword" RenderMode="Lightweight" runat="server" TextMode="Password" Width="210" LabelWidth="120px" Resize="None" type="password">
                                    <PasswordStrengthSettings IndicatorElementBaseStyle="Base" ShowIndicator="true"
                                        TextStrengthDescriptions=""
                                        TextStrengthDescriptionStyles="L0;L1;L2;L3;L4;L5"
                                        IndicatorElementID="CustomIndicator"></PasswordStrengthSettings>
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RFVPassword" runat="server" ControlToValidate="rtxtPassword" CssClass="val-error" ErrorMessage="*"></asp:RequiredFieldValidator>
                                <span id="CustomIndicator">&nbsp;</span>
                            </td>
                            <td class="fv-edit" colspan="3">
                                <asp:RegularExpressionValidator ID="revPassword" ControlToValidate="rtxtPassword" runat="server" CssClass="val-error" Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="ft-edit">Confirm Password :</td>
                            <td class="fv-edit" colspan="2">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Width="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvfConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" CssClass="val-error" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td class="fv-edit" colspan="3">
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="rtxtPassword" ControlToValidate="txtConfirmPassword" CssClass="val-error" ErrorMessage="The password you entered does not match"></asp:CompareValidator>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td class="center-btn">
                <table class="tbl-op-center" style="width: 150px">
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" CssClass="btn-save" runat="server" Text="Save" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
