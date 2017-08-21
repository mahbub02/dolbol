<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowBlog.aspx.cs" Inherits="BDDoctors.ShowBlog" %>

<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<%@ Register src="Controls/Comment.ascx" tagname="Comment" tagprefix="uc2" %>

<%@ Register src="Controls/BanglaHelpBox.ascx" tagname="BanglaHelpBox" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Show Blog</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        img{ vertical-align:top; margin:2px; padding:3px; border:1px solid #CCC; background-color:Transparent;}
        img:hover{  } /*background-color:#2F9A8F;*/
        img.icon:hover{ background-color:Transparent;}    
    </style>
    <script type="text/javascript" src="JS/jquery-1.3.2.min.js"></script> 
    <script type="text/javascript" src="JS/Comment.js"></script> 
    <script type="text/javascript" src="JS/phonetic_int.js"></script>
    <script type="text/javascript" src="JS/jqdialog.min.js" ></script>
<link href="CSS/jqdialog.css" rel="stylesheet" type="text/css" />    
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
   function ShowActualSize(imgCntrl)
      {
          if(imgCntrl.src.search("_mini.jpg")>0)
          {
          imgCntrl.src=imgCntrl.src.replace("_mini.jpg","")+"_display.jpg";
//          imgCntrl.style.position="absolute";
          
          }
          else if(imgCntrl.src.search("_display.jpg")>0)
          {
           imgCntrl.src=imgCntrl.src.replace("_display.jpg","")+"_mini.jpg";
//           imgCntrl.style.position="relative";
          }
     }

     function TextAreaChange()
        {
          var areas =document.getElementsByTagName("textarea");
          for(var i=0;i<areas.length;i++)
          {
             
           areas[i].onclick=resizeit;
           areas[i].onmouseout=resizeitToSmall;
          }
        }
        function resizeit(e)
        {
           this.style.height="60px";
        }
        function resizeitToSmall(e)
        {
            if(this.value=="")
            {
             this.style.height="20px";
            }
        }
    </script>
    
    <style type="text/css">
       div.Comment-section  span{font-size:16px}
        textarea{ font-size:18px}
       table.comment{ margin-left:0px; border-color:#A7DEEA;}
    </style>
     <style runat="server" id="serverStyle" type="text/css">
    
         </style>
</head>
<body onload="MakeBanglaEditor();" onmousemove="MakeBanglaEditor();TextAreaChange();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode=Release>
        </asp:ScriptManager>
            <div class="dvMain" >
                <uc1:LoggedInUserMenu ID="LoggedInUserMenu3" runat="server" />         
 
           
            <div class="body" id="dvBody" runat="server" >
           
                
                <div class="middle"  > 
                
              <p style="float:right"> <asp:LinkButton runat="server" ID="lbtnEdit" Visible=false 
                      onclick="lbtnEdit_Click">Edit</asp:LinkButton>||<asp:LinkButton 
                      runat="server" ID="lbtnDelete" Visible=false 
                      Text="Delete" onclick="lbtnDelete_Click" ></asp:LinkButton></p> 
                
                        <asp:DataList ID="GridHeader"  runat="server" 
         AutoGenerateColumns="false" RepeatLayout=Flow RepeatDirection=Horizontal   ShowHeader="false"
        >
            
            <ItemTemplate>
              <div style="float:left;  ">
                    
                <a target="_top" href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>            
                <img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_thumb.jpg" />
                </a>
              </div>
                <div style="width:400px; float:left;display:inline;">
                <ul>
                <li><a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>> 
                <%# DataBinder.Eval(Container.DataItem, "User_Name")%>
                </a>
                 has posted a blog
                 at  <%# DataBinder.Eval(Container.DataItem, "Action_Date")%>  
                 </li>
                <li style="border-top:1px solid #CCC">  <span style="  font-weight:bold; font-size:16px"><%# DataBinder.Eval(Container.DataItem, "Node_Value")%></span></li>
                </ul>  
                </div>
            </ItemTemplate>                                
        
    </asp:DataList>

                            <ul  style="margin-left:94px; margin-top:80px; width:400px;">
                               
                               
                                
                                <li  ><div runat="server" id="dvdescription" style="font-size:16px"></div>  </li>
                                 <li >Category:<asp:Label runat="server" ID="lblCategoryValue" ></asp:Label></li>
                                 <li  ><asp:DataList Width="350" RepeatDirection=Horizontal RepeatLayout=Flow ID="DlAlbums" style=" float:left; width:400px"    runat="server"   
                                     AutoGenerateColumns="false"   
                                    >
                                    
                                        
                                        <ItemTemplate>
                                            <%--<a href=photoalbum.aspx?PhotoAlbum=<%# DataBinder.Eval(Container.DataItem, "Parent_Node_Id")%>>    --%>        
                                                <img src="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_mini.jpg" onclick="ShowActualSize(this);" />
                                           <%-- </a>--%>
                                        </ItemTemplate>                                
                                    
                                </asp:DataList></li>
                                
</ul>

                    
                    <div class="Comment-section" style="float:left; margin-left:100px">
                      <uc2:Comment ID="Comment1"  runat="server" />
                        <uc3:BanglaHelpBox ID="BanglaHelpBox1" runat="server" />
                    </div>
                  
                    
                    
                    
                </div>
                
                
             </div> 
     </div> 
        
    </form>
</body>
</html>
