<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediPanelDetails.aspx.cs" Inherits="BDDoctors.MediPanelDetails" %>

<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<%@ Register src="Controls/Comment.ascx" tagname="Comment" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PANEL:DETAILS</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JS/phonetic_int.js"></script>
    <script type="text/javascript">
        _uacct = "UA-1154128-1";
        urchinTracker();
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
     function CheckBr(txtBox,lineLength)
        {
       
          var text=  txtBox.value;
            if(text.charAt(text.length-1)!='\n' && text.length>lineLength)
                {               
                    if( text.lastIndexOf('\n')<text.length-lineLength)
                    {
                        txtBox.value= text+'\n';
                    }
                }   
                
        }
     
     
     
     
     function ShowActualSize(imgCntrl)
      {
          if(imgCntrl.src.search("_thumb.jpg")>0)
          {
          imgCntrl.src=imgCntrl.src.replace("_thumb.jpg","_display.jpg");
          }
          else if(imgCntrl.src.search("_thumb.jpg")==-1)
          {
          imgCntrl.src=imgCntrl.src.replace("_display.jpg","_thumb.jpg");
           
          }
          
     }
     
    </script>
    <script type="text/javascript" src="JS/jquery-1.3.2.min.js"></script> 
    <script type="text/javascript" src="JS/Comment.js"></script> 
    <style type="text/css">
        
    span.bangla{ vertical-align:top; font-size:18px;  position:relative;top:-5px}
    input.bangla{ font-size:16px;}
    textarea.bangla{ font-size:16px;}
   a{ color:black}
    textarea{ font-size:16px}
   div.PanelComment span{font-size:16px; margin-top:30px; width:100%; border:1px solid white}
   body{ color:White}
   div#divCreateNewBlog li{width:100%; display:inline-block}
    img{ vertical-align:top; margin:2px; padding:3px; border:1px solid #CCC; background-color:Transparent;}
    </style>
    <% if (IsCommentVisble == false)  %>
    <%{ %>
       <style type="text/css">
           div.comment-box{ visibility:hidden}
       </style>  
    <%} %>
    
     <style runat="server" id="serverStyle" type="text/css">
    
         </style>
   
    
    
</head>
<body onload="MakeBanglaEditor();" onmousemove="MakeBanglaEditor();" style=" color:Black; "  >
    <form id="form1" runat="server" >
     <div class="dvMain" >
     <div class="body" id="dvBody" style="padding-bottom:100px"   runat="server" >
      
     <uc1:LoggedInUserMenu ID="LoggedInUserMenu2" runat="server" />
    
   
    <a runat=server id="anchorEdit" visible=false style="float:right; font-size:13px; font-weight:bold" > Edit </a>|<a style="float:right; font-size:13px; font-weight:bold" href=MediPanel.aspx> Seek prescription </a>
   
               <div runat="server" id="divCreateNewBlog" style="float:left"  >
                         
                                                                <ul runat="server" id="ulDetails">  
                                                                    <li  >
                                                                      <asp:HyperLink runat="server" ID="hlinkUserImage" ><img runat="server"  Width=40  ID="imgUser" /><asp:Label runat="server" ID="lblUserName" Text="User Name" style="vertical-align:top"></asp:Label>  </asp:HyperLink><asp:Label runat="server" ID="lblDateTime" style="vertical-align:top" ></asp:Label> 
                                                                    </li>                                               
                                                                    <li style="display:inline;margin:3px;"><asp:Label runat="server" ID="Label7" Text="Patient Name" CssClass="AttributeLabel" ></asp:Label><span  class="bangla;" style="color:#549CAF">রোগীর নাম:</span><asp:label runat="server" ID="lblName" CssClass="bangla"   ></asp:label></li>
                                                                    <li style="display:inline; margin:3px;"><asp:Label runat="server" ID="Label5" Text="Age" CssClass="AttributeLabel" ></asp:Label><span  class="bangla" style="color:#549CAF">বয়স:</span><asp:label runat="server" ID="lblAge" CssClass="bangla"   ></asp:label></li>
                                                                    <li  style="display:inline;margin:3px;"><asp:Label runat="server" ID="Label1" Text="Occupation" CssClass="AttributeLabel" ></asp:Label><span class="bangla" style="color:#549CAF">পেশা:</span><asp:label runat="server" ID="lblOccupation" CssClass="bangla"   ></asp:label></li>
                                                                    <li  style="display:inline;margin:3px;"><asp:Label runat="server" ID="Label3" Text="Weight" CssClass="AttributeLabel" ></asp:Label><span  class="bangla" style="color:#549CAF">ওজন:</span><asp:label runat="server" ID="lblWeight" CssClass="bangla"   ></asp:label></li>
                                                                    <li style="border-Top:1px solid #ccc" >
                                                                        <asp:Label runat="server" ID="Label6" Text="Description" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px;color:#549CAF" >  আপনার সমস্যার বর্ননা দিন:</span>
                                                                    </li>
                                                                      <li><asp:Label runat="server" ID="Label2" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:label runat="server" CssClass="bangla" ID="lblDescription"  Width="700" Text=" আপনার সমস্যার বর্ননা দিন আপনার সমস্যার বর্ননা দিন আপনার সমস্যার বর্ননা দিন আপনার সমস্যার বর্ননা দিন আপনার সমস্যার বর্ননা দিন আপনার সমস্যার বর্ননা দিন আপনার সমস্যার বর্ননা দিন আপনার সমস্যার বর্ননা দিন আপনার সমস্যার বর্ননা দিন"></asp:label></li>
                                                                     
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label4" Text="How long you are suffering from" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px;color:#549CAF" > কত দিন ধরে ভুগছেন:</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label10" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:label CssClass="bangla" runat="server" ID="lblHowLongSuffering" Width="700" text="কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:কত দিন ধরে ভুগছেন:" ></asp:label></li>
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label9" Text="Are you already suffering from?" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px;color:#549CAF" > নিন্মুক্ত কোন রোগে ভুগেছেন?</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label8" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span><asp:Label  ID="lblSufferingFrom" runat="server"></asp:Label>  </li>
                                                                    
                                                                    
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label11" Text="History of any operation" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px;color:#549CAF" > কখন ও অপারেশন করে থাকলে তা লিখুন:</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label12" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:label CssClass="bangla" runat="server" ID="lblHistoryOfAnyOperation"  Width="700"  ></asp:label></li>
                                                                    
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label17" Text="Have you taken any drug for this complaint" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px;color:#549CAF" > এই সমস্যার জন্য কোন ঔষুধ সেবন করে থাকলে তা লিখুন:</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label18" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:label CssClass="bangla" runat="server" ID="lblHaveYouTakenAnyDrugForThisComplaint"  Width="700"   ></asp:label></li>
                                                      
                                                                    
                                                                     <li>
                                                                        <asp:Label runat="server" ID="Label13" Text="Taking any medicine for long time(Name& Period)" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px;color:#549CAF" > অনেকদিন ধরে কোন ঔষধ সেবন করে থাকলে তা লিখুন:</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label14" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:label CssClass="bangla" runat="server" ID="lblTakingAnyMedicineForLong"  Width="700"    ></asp:label></li>
                                                      
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label15" Text="Have you already done any investigation" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px;color:#549CAF" > কোন পরীক্ষা করিয়ে থাকলে তা লিখুন:</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label16" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:label CssClass="bangla" runat="server" ID="lblHaveYouAlreadyDoneAnyInves"  Width="700"  ></asp:label></li>
                                                      
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label19" Text="Scaned or photo of report or complaint" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px;color:#549CAF" > কোন রিপোর্ট অথবা সমস্যার ছবি থেকে থাকলে তা ব্রাওজ করে দিতে পারেন::</span>
                                                                    </li>
                                                                    <li>
                                                                          <asp:DataList Width="350" RepeatDirection=Horizontal RepeatLayout=Flow ID="DlAlbums" style=" float:left; width:400px"    runat="server"     AutoGenerateColumns="false"   
                                                                                >
                                                                                
                                                                                    
                                                                                    <ItemTemplate>
                                                                                        <%--<a href=photoalbum.aspx?PhotoAlbum=<%# DataBinder.Eval(Container.DataItem, "Parent_Node_Id")%>>    --%>        
                                                                                            <img style="position:absolute;z-index:3" src="Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_thumb.jpg" onclick="ShowActualSize(this);" />
                                                                                       <%-- </a>--%>
                                                                                    </ItemTemplate>                                
                                                                                
                                                                            </asp:DataList>
                                                                    
                                                                    </li>
                                                      
                                                                     
                                                                     
                                                                </ul> 
                                                              
                          
                          
                          
                          <div style="display:block; margin-top:100px" >
                            <ul >
                                <li><asp:Label runat="server" ID="lblIsResolved"></asp:Label>
                                <asp:Button runat="server" ID="btnResoved" Text="Resolve"  Visible=false
                                        onclick="btnResoved_Click" /> 
                                        
                                        <span  class="bangla">&nbsp</span>
                                         <input onClick="switched=!switched;" value="switch keyboard mode" type="button">
                                </li>
                            </ul>
                             <div style="color:Black; float:left">
                                <uc2:Comment ID="Comment1" runat="server" />
                             </div>
                         </div> 
                </div>
                
                
   
    </div>
    
     
    </div>
    
     
    
    </form>
</body>
</html>
