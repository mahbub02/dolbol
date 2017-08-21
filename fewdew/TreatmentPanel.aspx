<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreatmentPanel.aspx.cs" Inherits="BDDoctors.TreatmentPanel" %>

<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SEARCH:PANEL</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        table#GridView1{ font-size:16px}
      a{ vertical-align:top; color:black}
      hr{ color:#9AD8E8}
      img{ vertical-align:top}
      img{ vertical-align:top; margin:2px; padding:3px; border:1px solid #9AD8E8; background-color:Transparent;}
      div.right ul { margin-top:40px; border-bottom:1px solid #CCC}
    span.action_date{font-size:10px; position:relative;top:-4px}
    </style>
        <script type="text/javascript" src="JS/phonetic_int.js"></script>
    <script type="text/javascript">
        _uacct = "UA-1154128-1";
        urchinTracker();
</script>
    <script type="text/javascript">
    function MakeBanglaEditor()
    {
   var Inputs= document.getElementsByTagName("input");
     
      for(var i=0;i<Inputs.length;i++)
     {
//     	if(Inputs[i].className=="bangla")
//	    {	
		makePhoneticEditor(Inputs[i]);
	
//		}
     }
  
    var textAreas= document.getElementsByTagName("textarea");
     
      for(var i=0;i<textAreas.length;i++)
     {
//     	if(textAreas[i].className=="bangla")
//	    {	
		makePhoneticEditor(textAreas[i]);
	
//		}
     }
    }
     
    </script>
</head>
<body onload="MakeBanglaEditor();" onmousemove="MakeBanglaEditor();" style="color:Black"  >
    <form id="form1" runat="server">
    <div class="body" >
     <uc1:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
        <div class="left">
         <p style="width:90%; height:130px; margin-top:10px; color:White; background-color:#ecf0f4; color:#CCC; text-align:center"> !</p>
         <p style="width:90%; height:130px; margin-top:10px; color:White; background-color:#ecf0f4; color:#CCC; text-align:center"> !</p>
         <p style="width:90%; height:130px; margin-top:10px; color:White; background-color:#ecf0f4; color:#CCC; text-align:center"> !</p>
         <p style="width:90%; height:130px; margin-top:10px; color:White; background-color:#ecf0f4; color:#CCC; text-align:center"> !</p>
         
         <p style="width:90%; height:130px; margin-top:10px; color:White; background-color:#ecf0f4; color:#CCC; text-align:center"> !</p>
         <p style="width:90%; height:130px; margin-top:10px; color:White; background-color:#ecf0f4; color:#CCC; text-align:center"> !</p>
         <p style="width:90%; height:130px; margin-top:10px; color:White; background-color:#ecf0f4; color:#CCC; text-align:center"> !</p>
         
         
         
         
         
         </div>

         <div class="middle">
         <a style="float:right; font-size:13px; font-weight:bold" href=MediPanel.aspx> Seek prescription </a>
         <ul style=" width:100%; float:left">
          <li><span  class="bangla">&nbsp</span> <input onClick="switched=!switched;" value="switch keyboard mode" type="button"></li>
     
         
             <li><span style="font-size:13px; color:#CCC">Enter your problem and search</span></li>
             <li><asp:TextBox runat="server" ID="txtSearch" Width="300" TextMode=MultiLine Font-Size=20 Height="30" style="background-color:white"></asp:TextBox>
                 <asp:Button runat="server" ID="btnSearch" Text="SEARCH" Height="33"    style="vertical-align:top"
                     onclick="btnSearch_Click" />
                     <br />
                     <asp:Button runat="server" ID="btnRecentPost" 
                     text="RECENT POST" Height="43" style="float:left; margin-left:400px; margin-top:20px;  vertical-align:top" 
                     onclick="btnRecentPost_Click" /></li>
         </ul>
                  <br />
             <asp:GridView ID="GridView1" runat="server" Width="500" AutoGenerateColumns=false style="float:left; "  >
             <Columns>
             <asp:TemplateField>
             <ItemStyle  />
                <ItemTemplate>
                <ul >
                <li><a   href=Profile.aspx?user_id=<%# DataBinder.Eval(Container.DataItem, "user_id")%>><img height="30px" src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "user_id")%>_mini.jpg" /><%#DataBinder.Eval(Container.DataItem, "user_name")%></a><span  class="action_date" >&nbsp at  &nbsp <%#DataBinder.Eval(Container.DataItem, "action_date")%></span>
                <a style="float:right; color:#9AD8E8" href=MediPanelDetails.aspx?Panel_id=<%# DataBinder.Eval(Container.DataItem, "Parent_Node_id")%>> Details</a></li>
                        
                 <li>    <%#((string)DataBinder.Eval(Container.DataItem, "node_value"))%></li>
                 
                </ul>  
                   
                   <hr />
                </ItemTemplate>
                
             </asp:TemplateField>
             </Columns>
             <EmptyDataTemplate>
             <h6>No item returns</h6>
             </EmptyDataTemplate>
             </asp:GridView>
            
         </div>
         <div class="right">
         
          <p style="float:left">The doctors here to prescribe you are... </p>
            <ul>
                <%--<li><a href=Profile.aspx?user=1> <img src="Images/Site/DrHabib.jpg" alt="Dr.Mohammad Habibur Rahman" /></a></li>--%>
                <li><span style=" font-size:smaller">(For surgical problems)</span></li>
                <li> Dr.Mohammad Habibur Rahman</li>
                
            </ul>
            
            <ul>
               <%-- <li><a href=Profile.aspx?user=6> <img src="Images/Site/DrPushpitaSharminPolin.jpg" alt="Dr.Pushpita Sharmin" /></a></li>--%>
                <li><span style=" font-size:smaller">(For obs & Gynae problem)</span></li>
                <li> Dr.Pushpita Sharmin</li>
                
            </ul>
             <ul>
                <%--<li><a href=Profile.aspx?user=1> <img src="Images/Site/DrHabib.jpg" alt="Dr.Mohammad Habibur Rahman" /></a></li>--%>
                <li><span style=" font-size:smaller">(For pediatric problems)</span></li>
                <li> Dr.Mohammad Ashraful islam</li>
                
            </ul>
            <ul>
                <%--<li><a href=Profile.aspx?user=1> <img src="Images/Site/DrHabib.jpg" alt="Dr.Mohammad Habibur Rahman" /></a></li>--%>
                <li><span style=" font-size:smaller">(For Medicine problems)</span></li>
                <li> Dr.Taslima akter</li>
                
            </ul>

         </div>
    </div>
   
    </form>
</body>
</html>
