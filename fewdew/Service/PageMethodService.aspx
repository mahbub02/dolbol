<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageMethodService.aspx.cs" EnableEventValidation="false" Inherits="BDDoctors.Service.PageMethodService" %>

<%@ Register src="../Controls/Comment.ascx" tagname="Comment" tagprefix="uc1" %>
<%@ Reference Control="~/Controls/Comment.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../CSS/Global.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/Home.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" 
            runat="server" EnablePageMethods="true">
            <Scripts>
                <asp:ScriptReference Path="~/Service/PageMethod.js"/>
            </Scripts>
        </asp:ScriptManager>
        <div id="testDiv"></div>
        
                    
                        <%--<input type="button" 
                        onclick="GetMyName('SessionValue')" 
                        value="Read" />--%>
                        
                        <span style="background-color:Aqua" id="ResultId"></span>
    <div>
    
    </div>
        <uc1:Comment ID="Comment1" runat="server" />
    </form>
</body>
</html>
