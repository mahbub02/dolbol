<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tester.aspx.cs" Inherits="BDDoctors.Tester" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    <div style="width:800px; ">
        <asp:TextBox ID="txtScaler" runat="server"></asp:TextBox>
        <asp:Button ID="btnScaler" runat="server" Text="Execute Scaler" 
            onclick="btnScaler_Click" />
        <asp:Label runat="server" ID="lblscaler"></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="txtReader" runat="server"></asp:TextBox>
        <asp:Button ID="btnReader" runat="server" Text="Reader" 
            onclick="btnReader_Click" />
        <asp:DataGrid AutoGenerateColumns=true ID="DataList1" runat="server"   >
        </asp:DataGrid>
        
    </div>
    </div>
    </form>
</body>
</html>
