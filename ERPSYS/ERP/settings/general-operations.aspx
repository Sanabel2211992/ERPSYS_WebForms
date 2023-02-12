<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="general-operations.aspx.cs" Inherits="ERPSYS.ERP.settings.GeneralOperations" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <table class="tbl-main">
        <tr>
            <td>
                <telerik:RadTabStrip ID="rtsSettings" runat="server" CssClass="Xts-view" MultiPageID="RadMultiPage1" Width="1180px" AutoPostBack="True" SelectedIndex="0"
                    ScrollChildren="true" ScrollButtonsPosition="Middle" Skin="Silk">
                    <Tabs>
                        <telerik:RadTab PageViewID="rpvUsersImages" Text="Users Profile Pictures" Width="200px" Selected="True" />
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" CssClass="Xmp-view" RenderSelectedPageOnly="True">
                    <telerik:RadPageView ID="rpvUsersImages" runat="server" Selected="true">
                        <table class="tbl-view" style="width: 500px">
                            <tr>
                                <th class="fv-view" style="width: 350px"></th>
                                <th class="ft-view" style="width: 150px"></th>
                            </tr>
                            <tr>
                                <td class="ft-view">Update Users Profile Pictures Cache : </td>
                                <td class="fv-view">
                                    <asp:Button ID="btnUpdateProfilePicturesCache" runat="server" Text="Update" CssClass="btn-save" OnClick="btnUpdateProfilePicturesCache_Click" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</asp:Content>
