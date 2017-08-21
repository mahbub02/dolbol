<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediPanelEdit.aspx.cs" Inherits="BDDoctors.MediPanelEdit" %>

<%@ Register src="Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>FewDew|Medical Panel</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    a{ color:White}    
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
    <style type="text/css">
    span.bangla{ vertical-align:top; font-size:18px; width:50px; display:inline-block}
    input.bangla{ font-size:18px;}
    textarea.bangla{ font-size:18px; font-weight:normal}
    </style>
</head>
<body onload="MakeBanglaEditor();" onmousemove="MakeBanglaEditor();">
    <form id="form1" runat="server" >
     
    <uc1:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
    <div class="body" style=" color:black ">
        
        <div class="middle" style="width:600px">
                <asp:LinkButton runat="server" ID="lbtnEdit" Text="Edit" style="float:right" Visible=false></asp:LinkButton>
               <div runat="server" id="divCreateNewBlog" class="transparent">
                                                      
                                                       
                                                           
                                                          
                                                            
                                                                <ul runat="server" id="ul1">  
                                                                    <li>  <asp:Label runat="server" ID="lblValidationMessageForBlog"   ></asp:Label></li>                                               
                                                                    <li><asp:Label runat="server" ID="Label7" Text="Patient Name" CssClass="AttributeLabel" ></asp:Label><span  class="bangla">রোগীর নাম: </span><asp:TextBox runat="server" ID="txtName" CssClass="bangla"  Width="350"  ></asp:TextBox></li>
                                                                    <li><asp:Label runat="server" ID="Label5" Text="Age" CssClass="AttributeLabel" ></asp:Label><span  class="bangla">বয়স: </span><asp:TextBox runat="server" ID="txtAge" CssClass="bangla"  Width="350"  ></asp:TextBox></li>
                                                                    <li><asp:Label runat="server" ID="Label1" Text="Occupation" CssClass="AttributeLabel" ></asp:Label><span class="bangla">পেশা: </span><asp:TextBox runat="server" ID="txtOccupation" CssClass="bangla"  Width="350"  ></asp:TextBox></li>
                                                                    <li><asp:Label runat="server" ID="Label3" Text="Weight" CssClass="AttributeLabel" ></asp:Label><span  class="bangla">ওজন: </span><asp:TextBox runat="server" ID="txtWeight" CssClass="bangla" Width="350"  ></asp:TextBox></li>
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label6" Text="Description" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px" >  আপনার সমস্যার বর্ননা দিন:</span>
                                                                    </li>
                                                                      <li><asp:Label runat="server" ID="Label2" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:TextBox runat="server" CssClass="bangla" ID="txtDescription" TextMode="MultiLine" Width="350" Height="200"  ></asp:TextBox></li>
                                                                     
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label4" Text="How long you are suffering from" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px" > কত দিন ধরে ভুগছেন:</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label10" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:TextBox CssClass="bangla" runat="server" ID="txtHowLongSuffering" TextMode="MultiLine" Width="350" Height="75"  ></asp:TextBox></li>
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label9" Text="Are you already suffering from?" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px" > নিন্মুক্ত কোন রোগে ভুগছেন?</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label8" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span><asp:CheckBoxList runat="server" ID="chkAreYouAlreadySuffering" style=" width:400px; margin-left:200px"></asp:CheckBoxList>  </li>
                                                                    
                                                                    
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label11" Text="History of any operation" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px" > কখন ও অপারেশন করে থাকলে তা লিখুন:</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label12" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:TextBox CssClass="bangla" runat="server" ID="txtHistoryOfAnyOperation"  TextMode="MultiLine" Width="350" Height="75"  ></asp:TextBox></li>
                                                                    
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label17" Text="Have you taken any drug for this complaint" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px" > এই সমস্যার জন্য কোন ঔষুধ সেবন করে থাকলে তা লিখুন:</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label18" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:TextBox CssClass="bangla" runat="server" ID="txtHaveYouTakenAnyDrugForThisComplaint" TextMode="MultiLine"  Width="350" Height="75"   ></asp:TextBox></li>
                                                      
                                                                    
                                                                     <li>
                                                                        <asp:Label runat="server" ID="Label13" Text="Taking any medicine for long time(Name& Period)" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px" > অনেকদিন ধরে কোন ঔষধ সেবন করে থাকলে তা লিখুন:</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label14" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:TextBox CssClass="bangla" runat="server" ID="txtTakingAnyMedicineForLong" TextMode="MultiLine"  Width="350" Height="75"   ></asp:TextBox></li>
                                                      
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label15" Text="Have you already done any investigation" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px" > কোন পরীক্ষা করিয়ে থাকলে তা লিখুন:</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label16" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:TextBox CssClass="bangla" runat="server" ID="txtHaveYouAlreadyDoneAnyInves"  Width="350" Height="75" TextMode="MultiLine"  ></asp:TextBox></li>
                                                      
                                                                    <li>
                                                                        <asp:Label runat="server" ID="Label19" Text="Scaned or photo of report or complaint" CssClass="AttributeLabel" ></asp:Label>
                                                                        <span class="bangla" style="width:200px" > কোন রিপোর্ট অথবা সমস্যার ছবি থেকে থাকলে তা ব্রাওজ করে দিতে পারেন::</span>
                                                                    </li>
                                                                    <li><asp:Label runat="server" ID="Label20" Text="" CssClass="AttributeLabel" ></asp:Label> <span  class="bangla">&nbsp</span>  <asp:FileUpload ID="fileUploadPhoto" runat="server" /> </li>
                                                      
                                                                     <li><asp:Label runat="server" ID="lblPhotoInformation" Text="" CssClass="AttributeLabel2" ></asp:Label>
                                                                         <asp:Button runat="Server" ID="btnPost" Text="Post" onclick="btnPost_Click" 
                                                                                />
                                                                        </li> 
                                                                     
                                                                </ul> 
                                                            
                                                             
                                                       
                                                    </div>
                <input onClick="switched=!switched;" value="switch keyboard mode" type="button"> 
        </div>
        <div class="right">
        <div style="width:100%;  border-left:1px solid #e0f1f8; text-align:center">
        <span style="font-size:larger">Doctor's Panel</span>
            <ul>
                <li><a href=Profile.aspx?user=1> <img src="Images/Site/DrHabib.jpg" alt="Dr.Mohammad Habibur Rahman" /></a></li>
                <li><span style=" font-size:smaller">(For surgical problems)</span></li>
                <li><a href=Profile.aspx?user=1> Dr.Mohammad Habibur Rahman</a></li>
                
            </ul>
            
            <ul>
                <li><a href=Profile.aspx?user=6> <img src="Images/Site/DrPushpitaSharminPolin.jpg" alt="Dr.Pushpita Sharmin" /></a></li>
                <li><span style=" font-size:smaller">(For obs & Gynae problem)</span></li>
                <li><a href=Profile.aspx?user=6> Dr.Pushpita Sharmin</a></li>
                
            </ul>
            
            
         </div> 
        </div>
    </div>
    
    </form>
</body>
</html>
