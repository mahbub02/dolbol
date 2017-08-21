<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blogs.aspx.cs" Inherits="BDDoctors.Blogs" %>

<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Blogs.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="dvMain" >
    <div class="top">   
        <uc1:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
    </div>
     <div class="body">
        <div style="float:left; width:400px;" >
        <div>
            <div class="search-criteria">
                <ul>
                    <li><span>Contact Email</span><asp:TextBox runat="server" ID="txtContactEmail"></asp:TextBox></li>
                    <li><span>Full Name</span><asp:TextBox runat="server" ID="txtFullName"></asp:TextBox></li>
                    <li><span>Home town</span><asp:TextBox runat="server" ID="txtHomeTown"></asp:TextBox></li>
                    <li><span>Contact Number</span><asp:TextBox runat="server" ID="txtContactNumber"></asp:TextBox></li>
                    <li><span>Speciality</span><asp:TextBox runat="server" ID="txtSpeciality"></asp:TextBox></li>
                    <li><span>Education Institute Name</span><asp:TextBox runat="server" ID="txtInstitueName"></asp:TextBox></li>
                    <li><span>Passing year</span> <asp:DropDownList runat="server" ID="ddlYear" ></asp:DropDownList></li>
                    <li><span>&nbsp</span><asp:Button runat="server" ID="btnSearch" 
                            style="vertical-align:top" Text="Search"  /></li>
                </ul>
            </div>
        
        
           
        </div>
        </div>
        <div style="float:left; width:700px;">
        
                <div id="click-add" style="position:absolute;left:700px; top:30px; float:left; z-index:3">
                   
                   
                </div>
               
        </div>
        <div class="right">
        </div>
     </div>
    </div>
    </form>
</body>
</html>
