<%@ Page Title="PaintStore" Language="C#"  AutoEventWireup="true" CodeBehind="PaintStore.aspx.cs" Inherits="PaintWebSite.PaintStore" %>
<%@ Assembly name="System" %>
<%@ Assembly name="System.Data" %>
<%@ Assembly name="System.Web" %>
<%@ Assembly name="Npgsql" %>
 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>The Paint Store</title>
</head>
<body>
    <form runat="server">
    <div>
        <!-- ASP table with style options and column headings -->
        <asp:Table ID="PaintTable" runat="server" Width="30%" HorizontalAlign="Center" BorderStyle="Solid" GridLines="Both"> 
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center"><b>Paint Name</b></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><b>Quantity</b></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>