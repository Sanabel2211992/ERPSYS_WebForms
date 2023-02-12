<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowTextJQ.aspx.cs" Inherits="ERPSYS.ERP.t.ShowTextJQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script type="text/javascript">
        function ShowName() {
            var name = $('#<%= txtName.ClientID %>').val();
            var code = $('#<%= txtCode.ClientID%>').val();
            var messege = "";
            if (name === "") {
                messege = "Can not Blank Name";
            }
            if (messege.length === 0) {
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "ShowTextJQ.aspx/AddCategory",
                    data: "{'name':'" + name + "','code':'" + code + "'}",
                    success: function (record) {
                        $('#txtName').val();
                        alert(record.d);
                        if (record.d === true) {
                            $("#Result").text("Your Record insert");
                        }
                        else {
                            $("#Result").text("Your Record Not Insert");
                        }
                    },
                    Error: function (textMsg) {
                        $("#Result").text("Error: " + Error);
                    }
                });
            }
            else {
                $("#Result").html("");
                $("#Result").html(messege);
            }
            $("#Result").fadeIn();
        }
    </script>
    <form id="form1" runat="server">
        <h3 id="Result"></h3>
        <div>
            <table>
                <tr>
                    <td>Name: </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbNameShow" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Code : </td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnShow" runat="server" Text="Insert" OnClientClick="ShowName(); return false;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
