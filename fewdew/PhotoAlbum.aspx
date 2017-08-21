<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoAlbum.aspx.cs" Inherits="BDDoctors.PhotoAlbum" %>

<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<%@ Register src="Controls/Comment.ascx" tagname="Comment" tagprefix="uc2" %>

<%@ Register src="Controls/FeedRelated/Notif_UploadedImage.ascx" tagname="Notif_UploadedImage" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>FewDew|Photo Album</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    
        <script type="text/javascript" src="JS/phonetic_int.js"></script>
    <script type="text/javascript">
        _uacct = "UA-1154128-1";
        urchinTracker();
</script>
<script type="text/javascript">

  function ShowActualSize(imgControl)
     {
     var FullImage =document.getElementById("FullImage");
     FullImage.style.display="inline";
     
     var fullImageControl=document.getElementById("imgfullImage");
     fullImageControl.src=imgControl.src.replace("_thumb.jpg","")+"_display.jpg";
    
     document.getElementById("txtHidden").value=imgControl.src;
     
     
     }
 </script>
    <script type="text/javascript">
    
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
    <style type="text/css">
       div.Comment-section  span{font-size:16px}
       #Comment1_GridComment{ margin-left:0px}
        textarea{ font-size:18px}
        img#BlogImage:hover{ width:600px }
        img{ vertical-align:top; margin:2px; padding:3px; border:1px solid #CCC; background-color:Transparent;}
 /*background-color:#2F9A8F;*/
img.icon:hover{ background-color:Transparent;}

    </style>
</head>
<body onload="MakeBanglaEditor();" onmousemove="MakeBanglaEditor();TextAreaChange();">
    <form id="form1" runat="server">
       
            <div class="dvMain" >
                <uc1:LoggedInUserMenu ID="LoggedInUserMenu3" runat="server" />         
 
            <div class="top" >
          
           </div>
            <div class="body" >
                
                <div style="float:left; width:380px; "   > 
                
                    <asp:GridView ID="GridHeader"  runat="server" 
                                 AutoGenerateColumns="false"   ShowHeader="false"
                                >
                                <Columns>                            
                                <asp:TemplateField>
                                    
                                    <ItemTemplate>
                                      <div style="width:80px; float:left; ">
                                            
                                        <a target="_top" href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>            
                                        <img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_thumb.jpg" style="width:40px" />
                                        </a>
                                      </div>
                                        <div style="width:300px; float:left; ">  
                                        <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>> 
                                        <%# DataBinder.Eval(Container.DataItem, "User_Name")%>
                                        </a>
                                         Has created album
                                         <a href=photoalbum.aspx?PhotoAlbum=<%# DataBinder.Eval(Container.DataItem, "Id")%>><%# DataBinder.Eval(Container.DataItem, "Node_Value")%></a>
                                         at  <%# DataBinder.Eval(Container.DataItem, "Action_Date")%>  
                                        </div>
                                    </ItemTemplate>                                
                                </asp:TemplateField>
                                </Columns>
                               
                            </asp:GridView> 
                             <div runat="server" id="uploadBlock" style="margin-bottom:50px" visible=false>
                            <asp:Label runat="server" ID="lblUploadMessage"></asp:Label>
                            <asp:FileUpload ID="FileUploadImage" runat="server" />
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" onclick="btnUpload_Click" 
                                 />
                         </div>
                            <asp:DataList  RepeatDirection=Horizontal RepeatLayout=Flow ID="DlAlbums"  runat="server"  
                                 AutoGenerateColumns="false"   
                                >
                                
                                    
                                    <ItemTemplate>
                                       
                                            <img id="imgItem" src="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_thumb.jpg"  onclick="ShowActualSize(this);" />
                                       
                                    </ItemTemplate>                                
                                
                            </asp:DataList>
                    
                    
                    <div class="Comment-section">
                      <uc2:Comment ID="Comment1" runat="server" />
                    </div>
                  
                    
                    
                    
                </div>
                
                <div style="float:left;width:600px; display:none" id="FullImage" >
                 <img id="imgfullImage" onclick="RotateDisplay(this);" /> 
                 <asp:Button runat="server" ID="btnDelete" Visible=false  Text="DELETE THIS PICTURE" 
                        onclick="btnDelete_Click" />
                 <input runat="server" type=text id="txtHidden" style="display:none" />
                </div>
             </div> 
     </div> 
        
    </form>
</body>
</html>
