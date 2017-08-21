﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="BDDoctors.Signup" %>


<%@ Register src="Controls/Signup.ascx" tagname="Signup" tagprefix="uc1" %>


<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>FewDew</title>    
    
<style type="text/css">
 *{ margin:0px; padding:0px; font-family:Tahoma }
img{border:none; background-color:Transparent}
img:hover{ border-color:Black; cursor:pointer  }
a{ color:#393D3D;  font-weight:bold; text-decoration:none; text-align:right }
a:hover{color:black  }

ul{	text-align:left;list-style:none;}
ul li{	padding-top:4px;}
table,
table tr,
table tr td,
table tr,td{ border:none; border-color:White;}


input.single-text{border:1px solid #007996; width:150px; height:20px;background-color:white; }
input{		
height:20px;
background-color:white; 
border: 1px solid #CCC; 
font-weight:bold;
color:black;
text-align:left;
font-family:Verdana;
vertical-align:top;


/*color:#808080; background-image:url(../images/site/GreenButtonBack.gif);*/
font-size:10px; 
}
input:hover{ border-color:#007996; 	}
body
{
	font-family:Tahoma;
	font-size:11px;
	color:#0f3555;
	width:1000px;
    width:100%;
	
	

	
}
div{ word-wrap:break-word;overflow:visible}

/*.dvMain{ width:1250px;  float:left } */


div.horizon-menu{	background-color:#000;height:30px; float:left; width:100%} /* width:1250px; }*/
div.horizon-menu ul { padding-top:5px;}
div.horizon-menu ul li { display:inline;  margin-left:30px;}
div.horizon-menu ul li { display:inline;}
div.horizon-menu ul li a { color:White; font-weight:bold}
div.horizon-menu ul li a:hover { color:#CCC; }

div.top{	width:1000px;  float:left;}
div.body{ width:100%; height:99%;  float:left }
div.left{width:220px;  float:left;height:900px; }/*height:900px;*/
div.middle{	width:530px;	 float:left }
div.right{ width:220px;  float:right;}
.dvMain{width:100%; float:left } /*width:1200px; */
.heading{margin-bottom:20px;padding:0px;color:#2F9A8F; background-color:White; border-bottom:1px solid #CCC;	font-size:13px;}




ul li span.AttributeLabel
{
	vertical-align:top;
	width:130px;/*width:130px;*/
	text-align:right;
	display:inline-block;
	font-weight:bold;
	margin-right:10px;
	
}

div.hidden{ display:none}



/*---------For All Comment Grid*/
table.comment{ margin-left:100px; border-color:#A7DEEA;}
table.comment tr{ background-color:#A7DEEA; border-bottom-color:#A7DEEA;  }
table.comment tr td{ border-bottom:2px solid white; }
table.comment tr td textarea{ height:20px;width:200px;  vertical-align:top;float:left }
.comment-delete{ color:#D4EAE8;}
.comment-delete{visibility:hidden; }
.comment-delete_visible{visibility:visible; color:black}

/*.comment-delete{ color:#D4EAE8;}*/
/*---------For All Comment grid*/

   
a{ font-weight:bold;color:#CCC }
a:hover{ font-weight:bold; color:Black  }
div.signin-footer a:hover{ color:#CCC;}
</style>
  
</head>
<body  >
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode=Release>
    </asp:ScriptManager>
    
     
    <div class="dvMain" >
<img src="Images/Site/BlackDrop.jpg" style=" z-index:2;top:100px;position:absolute;" alt="Logo" style="float:left" />
<span style="z-index:2;top:250px;position:absolute;left:230px;font-size:30px; font-weight:bold; color:#007996; ">Fewdew</span>
<span style="z-index:2;top:310px;position:absolute;left:150px;font-size:13px; font-weight:bold; color:black; ">Today's bindings , future society</span>


           <div style="margin-left:50%;margin-right:10%;margin-top:10%;" >
            <uc1:Signup ID="Signup1" runat="server" />
           </div>           
           
          
            <div class="signin-footer" style="width:100%; height:50px; position:absolute;bottom:0px;background-color:black; float:left;" >&nbsp<a href="Blog.aspx" >Blogs</a> || <a href=TreatmentPanel.aspx >Prescription point</a>||<a href=default.aspx >Signin</a></div>
           
          
           
    </div>
           
                 <%--<div class="signing-signup">
                            <uc1:Signup ID="Signup1" runat="server" />
                         </div>   --%>
               
    </form>
</body>
</html>

