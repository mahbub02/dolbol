<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Finduser.aspx.cs" Inherits="BDDoctors.Finduser" %>
<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<%@ Register src="Controls/ClickedOnAddConnectionButton.ascx" tagname="ClickedOnAddConnectionButton" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>GET YOUR CONTACTS</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
     <link href="CSS/Finduser.css" rel="stylesheet" type="text/css" />
   
    <script type="text/javascript" src="JS/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="JS/jquery.colorbox-min.js" ></script>
<script type="text/javascript">
			$(document).ready(function(){
				//Examples of how to assign the ColorBox event to elements
				$("a[rel='example1']").colorbox();
				$("a[rel='example2']").colorbox({transition:"fade"});
				$("a[rel='example3']").colorbox({transition:"none", width:"75%", height:"75%"});
				$("a[rel='example4']").colorbox({slideshow:true});
				$(".single").colorbox({}, function(){
					alert('Howdy, this is an example callback.');
				});
				$(".colorbox").colorbox();
				$(".youtube").colorbox({iframe:true, width:650, height:550});
				$(".iframe").colorbox({width:"400px", height:"220px", iframe:true});
				$(".inline").colorbox({width:"50%", inline:true, href:"#inline_example1"});
				
				//Example of preserving a JavaScript event for inline calls.
				$("#click").click(function(){ 
					$('#click').css({"background-color":"#f00", "color":"#fff", "cursor":"inherit"}).text("Open this window again and this message will still be here.");
					return false;
				});
			});
</script>


  

    <link href="colorbox.css" rel="stylesheet" type="text/css" />
    
   
</head>
<body style="color:#4FA3B9">
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
                    <li><span>Full Name</span><asp:TextBox runat="server" ID="txtFullName"></asp:TextBox></li>
                    <li><span>Contact Email</span><asp:TextBox runat="server" ID="txtContactEmail"></asp:TextBox></li>
                    <li><span>Home town</span><asp:TextBox runat="server" ID="txtHomeTown"></asp:TextBox></li>
                    <li><span>Contact Number</span><asp:TextBox runat="server" ID="txtContactNumber"></asp:TextBox></li>
                    <li><span>Speciality</span><asp:TextBox runat="server" ID="txtSpeciality"></asp:TextBox></li>
                    <li><span>Education Institute Name</span><asp:TextBox runat="server" ID="txtInstitueName"></asp:TextBox></li>
                    <li><span>Passing year</span> <asp:DropDownList runat="server" ID="ddlYear" ></asp:DropDownList></li>
                    <li><span>&nbsp</span><asp:Button runat="server" ID="btnSearch" 
                            style="vertical-align:top" Text="Search" onclick="btnSearch_Click" /></li>
                </ul>
            </div>
        
        
           
        </div>
        </div>
        <div style="float:left; width:700px;">
        
                <div id="click-add" style="position:absolute;left:700px; top:30px; float:left; z-index:3">
                    <uc2:ClickedOnAddConnectionButton ID="ClickedOnAddConnectionButton1"  
                    runat="server" Visible=false />
                </div>
                <asp:GridView ID="GridAllFriend" runat="server" CssClass="YourGridView" 
                                                          AutoGenerateColumns="false"  DataKeyNames="Id"
                    Width="90%"  ShowHeader="false" AllowPaging=true 
                    PagerSettings-Mode="NumericFirstLast" PageSize=20      ShowFooter=false    PagerStyle-CssClass="PageStyle"  
                    PagerSettings-Position="TopAndBottom" PagerStyle-HorizontalAlign=Left    
                    PagerStyle-Font-Bold=true onrowediting="GridAllFriend_RowEditing" onrowdatabound="GridAllFriend_RowDataBound" 
                       >
                                                          
                                                        <Columns>
                                                        
                                                            <asp:TemplateField>
                                                            
                                                              <ItemStyle    />
                                                                <ItemTemplate>
                                                                         <div   class="friend">
                                                                             <div style="width:120px;  display:inline-block; float:left">
                                                                             <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "Id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "id")%>_thumb.jpg" /></a>
                                                                             <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "Id")%>>   <%# DataBinder.Eval(Container.DataItem, "DisplayName")%></a>                                                                             
                                                                             </div>   
                                                                             <div style="float:right;">
                                                                             <a class="iframe"  runat="server" id="anchorAddFriend" href="#" >Add as contact</a></p>
                                                                             </div>       
                                                                            <%-- <asp:LinkButton runat="server" ID="lbtnAddAsFriend" Text="Create Connection" Enabled=false CssClass="add-button" CommandArgument=<%# DataBinder.Eval(Container.DataItem, "id")%> CommandName="edit"  ></asp:LinkButton>--%>
                                                                           
                                                                           </div>
                                                                </ItemTemplate>
                                                              </asp:TemplateField>
                                                        </Columns>
            </asp:GridView>
        </div>
        <div class="right">
        </div>
     </div>
    </div>
    </form>
</body>
</html>
