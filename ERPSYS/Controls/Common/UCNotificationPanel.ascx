<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNotificationPanel.ascx.cs" Inherits="ERPSYS.Controls.Common.UCNotificationPanel" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadNotification ID="rnMessage" runat="server" RenderMode="Lightweight" Skin="WebBlue"
    Overlay="false"
    VisibleOnPageLoad="False"
    Animation="Fade"
    EnableRoundedCorners="True"
    EnableShadow="True"
    AutoCloseDelay="700"
    Position="BottomRight"
    ShowCloseButton="True"
    OffsetX="-20" OffsetY="-27"
    Height="100px" Width="336px" />
