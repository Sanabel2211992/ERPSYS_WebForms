<%@ Page Title="" Language="C#" MasterPageFile="~/ERP/Main.Master" AutoEventWireup="true" CodeBehind="not-authorize.aspx.cs" Inherits="ERPSYS.ERP.session.NotAuthorizePage" %>

<asp:Content ID="cHeader" ContentPlaceHolderID="cphHeader" runat="server">
</asp:Content>
<asp:Content ID="cMian" ContentPlaceHolderID="cphMain" runat="server">
   
    <div class="AccessDenied-page">
        <div>
            <img src="../resources/images/access-denied.png" width="30px" height="30px" />
              <p class="Access-p">Access Denied</p>
        </div>
        <div class="text-AccessDenied">
             <p>You are not authorized to view this page or do this action.<br>
                    Please contact your administrator For more Information. </p>
        </div>



    </div>
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
  <!--   <table class="AccessDenied-page">
        <tr>
            <td>
                <img src="../resources/images/access-denied.png" width="30px" height="30px" />
                <p class="Access-p">Access Denied</p>
             <!--   <font size="5" face="verdana" color="red"><strong>Access Denied</strong> </font>
            </td>
        </tr>
        <tr>
            <td style="width: 400px" colspan="2" align="center">
                <font size="2" face="verdana">You are not authorized to view this page or do this action.<br>
                    Please contact your administrator For more Information. </font>
            </td>
        </tr>
    </table>-->
</asp:Content>
