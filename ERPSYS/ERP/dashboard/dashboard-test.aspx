<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Dashboard.Master" AutoEventWireup="true" CodeBehind="dashboard-test.aspx.cs" Inherits="ERPSYS.ERP.dashboard.dashboard_test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHeader" runat="server">
    <style>
        .panel-titlex {
           vertical-align: middle !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <%--    <!---start section Features--->
    <section class="Features text-center">
        <div class="container-fluid">
            <h1>Muneer</h1>
            <div class="row">
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="fet">
                        <span class="glyphicon glyphicon-plane" aria-hidden="true"></span>
                        <h4>our design </h4>
                        <p>Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus 					PageMaker including versions of Lorem Ipsum. </p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 ">
                    <div class="fet">
                        <span class="glyphicon glyphicon-sunglasses" aria-hidden="true"></span>
                        <h4>our design </h4>
                        <p>Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus 					PageMaker including versions of Lorem Ipsum. </p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="fet">
                        <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                        <h4>our design </h4>
                        <p>Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus 					PageMaker including versions of Lorem Ipsum. </p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="fet">
                        <span class="glyphicon glyphicon-picture" aria-hidden="true"></span>
                        <h4>our design </h4>
                        <p>Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus 					PageMaker including versions of Lorem Ipsum. </p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="fet">
                        <span class="glyphicon glyphicon-picture" aria-hidden="true"></span>
                        <h4>our design </h4>
                        <p>Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus 					PageMaker including versions of Lorem Ipsum. </p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="fet">
                        <span class="glyphicon glyphicon-picture" aria-hidden="true"></span>
                        <h4>our design </h4>
                        <p>Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus 					PageMaker including versions of Lorem Ipsum. </p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="fet">
                        <span class="glyphicon glyphicon-picture" aria-hidden="true"></span>
                        <h4>our design </h4>
                        <p>Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus 					PageMaker including versions of Lorem Ipsum. </p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="fet">
                        <span class="glyphicon glyphicon-picture" aria-hidden="true"></span>
                        <h4>our design </h4>
                        <p>Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus 					PageMaker including versions of Lorem Ipsum. </p>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="fet">
                        <span class="glyphicon glyphicon-picture" aria-hidden="true"></span>
                        <h4>our design </h4>
                        <p>Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus 					PageMaker including versions of Lorem Ipsum. </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--- End section Features --->--%>
    <div>
        <asp:Button ID="Button2" runat="server" Text="Add" CssClass="btn btn-success" />
        <asp:Button ID="Button3" runat="server" Text="edit" CssClass="btn btn-primary" />
        <asp:Button ID="Button5" runat="server" Text="delete" CssClass="btn btn-danger" />
    </div>
    <div>
        <button type="button" class="btn btn-primary">Primary</button>
        <button type="button" class="btn btn-secondary">Secondary</button>
        <button type="button" class="btn btn-success">Success</button>
        <button type="button" class="btn btn-danger">Danger</button>
        <button type="button" class="btn btn-warning">Warning</button>
        <button type="button" class="btn btn-info">Info</button>
        <button type="button" class="btn btn-light">Light</button>
        <button type="button" class="btn btn-dark">Dark</button>

        <button type="button" class="btn btn-link">Link</button>
    </div>

    <br />
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title align-middle pull-left">Main </div>
                <div class="pull-right">
                    <asp:Button ID="btnAdd" runat="server" Text="Add User" CssClass="btn btn-success" />
                    <asp:Button ID="Button1" runat="server" Text="edit User Details" CssClass="btn btn-primary" />
                    <asp:Button ID="Button4" runat="server" Text="delete User" CssClass="btn btn-danger" />
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="panel-body">
                Hi all 
                <br />
                Hiiiiii
            </div>
        </div>
    </div>
    <br />
    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title align-middle pull-left">Main </div>
                <div class="pull-right">
                    <asp:Button ID="Button6" runat="server" Text="Add User" CssClass="btn btn-success " />
                    <asp:Button ID="Button7" runat="server" Text="edit User Details" CssClass="btn btn-primary " />
                    <asp:Button ID="Button8" runat="server" Text="delete User" CssClass="btn btn-danger " />
                    <button type="button" class="btn btn-secondary">Secondary</button>
                    <button type="button" class="btn btn-success">Success</button>
                    <button type="button" class="btn btn-danger">Danger</button>
                    <button type="button" class="btn btn-warning">Warning</button>
                    <button type="button" class="btn btn-info">Info</button>
                    <button type="button" class="btn btn-light">Light</button>
                    <button type="button" class="btn btn-dark">Dark</button>
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="panel-body">
                Hi all 
                <br />
                Hiiiiii
            </div>
        </div>
    </div>

    <div class="col-md-12">
        <div class="panel panel-default">
            <div class="panel-heading">
                <div class="panel-title">Main </div>
                <div class="clearfix"></div>
            </div>
            <div class="panel-body">
                Hi all 
                <br />
                Hiiiiii
            </div>
        </div>
    </div>
</asp:Content>
