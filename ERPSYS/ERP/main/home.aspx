<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="ERPSYS.ERP.main.Home" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
    <div class="top-tbl-main">
        <div>
            <h1>
                <asp:Label ID="lblwelcome" runat="server" Text=""> </asp:Label>
            </h1>
            <input type="search" name="s">
        </div>
        <telerik:RadTileList ID="rtlMain" runat="server" Height="200px" TileRows="1" RenderMode="Lightweight" Skin="WebBlue" ScrollingMode="None" Width="1050px">
            <Groups>
                <telerik:TileGroup>
                    <telerik:RadIconTile ID="ritProducts" runat="server" Name="Products" NavigateUrl="../item/item-list.aspx"
                        Shape="Square" ImageUrl="../resources/images/tiles/icon_quote.png" BackColor="#077f73">
                        <Title Text="Products"></Title>
                        <PeekTemplate>
                            <div style="background-color: #077f73" class="squareContent font17">
                                Create, Modify and Delete Products.
                            </div>
                        </PeekTemplate>
                        <PeekTemplateSettings CloseDelay="6000" ShowInterval="3000" Animation="Fade" HidePeekTemplateOnMouseOut="true" ShowPeekTemplateOnMouseOver="true" />
                    </telerik:RadIconTile>
                    <telerik:RadIconTile ID="ritPriceList" runat="server" Name="PriceList" NavigateUrl="../item/item-price-list.aspx"
                        Shape="Square" ImageUrl="../resources/images/tiles/icon_quote.png" BackColor="#077f73" Visible="false">
                        <Title Text="Price List"></Title>
                        <PeekTemplate>
                            <div style="background-color: #077f73" class="squareContent font17">
                               View Products Price List.
                            </div>
                        </PeekTemplate>
                        <PeekTemplateSettings CloseDelay="6000" ShowInterval="3000" Animation="Fade" HidePeekTemplateOnMouseOut="true" ShowPeekTemplateOnMouseOver="true" />
                    </telerik:RadIconTile>
                    <telerik:RadIconTile ID="ritQuote" runat="server" Name="Quote" NavigateUrl="../est/quote-list.aspx"
                        Shape="Square" ImageUrl="../resources/images/tiles/icon_quote.png" BackColor="#007ac0">
                        <Title Text="Sales Quotations"></Title>
                        <PeekTemplate>
                            <div style="background-color: #007ac0" class="squareContent font17">
                                Create, Modify, Revise and Send Sales Quotations.
                            </div>
                        </PeekTemplate>
                        <PeekTemplateSettings CloseDelay="6000" ShowInterval="3000" Animation="Fade" HidePeekTemplateOnMouseOut="true" ShowPeekTemplateOnMouseOver="true" />
                    </telerik:RadIconTile>
                    <telerik:RadIconTile ID="ritSalesOrder" runat="server" Name="SalesOrder" NavigateUrl="../sm/sales-order-list.aspx"
                        Shape="Square" ImageUrl="../resources/images/tiles/icon_quote.png" BackColor="#ffcc00">
                        <Title Text="Sales Order"></Title>
                        <PeekTemplate>
                            <div style="background-color: #ffcc00" class="squareContent font17">
                                Create, Modify and Send Sales Order.
                            </div>
                        </PeekTemplate>
                        <PeekTemplateSettings CloseDelay="6000" ShowInterval="3000" Animation="Fade" HidePeekTemplateOnMouseOut="true" ShowPeekTemplateOnMouseOver="true" />
                    </telerik:RadIconTile>
                    <telerik:RadIconTile ID="ritSalesInvoice" runat="server" Name="SalesInvoice" NavigateUrl="../sm/sales-invoice-list.aspx"
                        Shape="Square" ImageUrl="../resources/images/tiles/icon_quote.png" BackColor="#ff471a">
                        <Title Text="Sales Invoice"></Title>
                        <PeekTemplate>
                            <div style="background-color: #ff471a" class="squareContent font17">
                                Create, Refund Sales Invoice.
                            </div>
                        </PeekTemplate>
                        <PeekTemplateSettings CloseDelay="6000" ShowInterval="3000" Animation="Fade" HidePeekTemplateOnMouseOut="true" ShowPeekTemplateOnMouseOver="true" />
                    </telerik:RadIconTile>
                    <telerik:RadIconTile ID="ritJobOrder" runat="server" Name="JobOrder" NavigateUrl="../sm/job-order-list.aspx"
                        Shape="Square" ImageUrl="../resources/images/tiles/icon_joborder.png" BackColor="#e68a00">
                        <Title Text="Job Orders"></Title>
                        <PeekTemplate>
                            <div style="background-color: #e68a00" class="squareContent font17">
                                View and Control of Job Order Operations.
                            </div>
                        </PeekTemplate>
                        <PeekTemplateSettings Animation="Fade" ShowInterval="4000" ShowPeekTemplateOnMouseOver="true"
                            HidePeekTemplateOnMouseOut="true" />
                    </telerik:RadIconTile>
                </telerik:TileGroup>
            </Groups>
        </telerik:RadTileList>
    </div>
    <div class="home-logo-s">
        <img src="../resources/images/home-logo-s.png" alt="FTMC" width="78" height="100" />
    </div>
</asp:Content>

