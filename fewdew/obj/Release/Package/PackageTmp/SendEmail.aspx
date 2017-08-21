<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="BDDoctors.SendEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Send Email</title>
    <style type="text/css">
     ul{ list-style:none}
     #lblValidationMessage{font-weight:normal; color:red; font-size:12px; margin-left:120px; }
    ul li span.AttributeLabel2{	vertical-align:top;	width:80px;	text-align:left;	float:left;	display:inline-block;font-weight:normal; color:#4FA3B9; font-size:12px; }
    .button{border:1px solid #CCC;background-color:#9AD8E8;}
    .button:hover{ border-color:#007996;}
   ul li{ margin-bottom:10px;}
    .sendemail{ width:70%; height:50%;margin:13%; display:inline-block; }
   
    </style>
</head>
<body>
    <form id="form1" runat="server">
   
   
                                    <div class="sendemail">
                                        <asp:Label runat="server" ID="lblValidationMessage"   ></asp:Label>
                                            <ul runat="server" id="ulControl">
                                                 <li><asp:Label runat="server" ID="lblEmailAttribute" Text="To" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtTo" Enabled=false></asp:TextBox></li>
                                                 <li><asp:Label runat="server" ID="Label4" Text="Subject" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtSubject" MaxLength="200" Width="300px"  ></asp:TextBox></li>
                                                 <li><asp:Label runat="server" ID="Label1" Text="Message" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine" Width="300px" ></asp:TextBox></li>
                                                 <li><asp:Label runat="server" ID="Label3" Text="" CssClass="AttributeLabel2" ></asp:Label>
                                                 <asp:Button runat="Server" ID="btnSend" CssClass="button" Text="Send" onclick="btnSend_Click"  />
                                                 <asp:Button runat="server" ID="btnCancel" Text="Clear" CssClass="button" onclick="btnCancel_Click" />
                                                     
                                                 </li>   
                     
                                            </ul> 
                                   </div>
                               
                                
   
    </form>
</body>
</html>
