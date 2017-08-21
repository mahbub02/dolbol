<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Signup.ascx.cs" Inherits="BDDoctors.Controls.Signup" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<%@ Reference Control="~/Controls/ActivationEmailBody.ascx"%>
 <%@ Register src="ActivationEmailBody.ascx" tagname="ActivationEmailBody" tagprefix="uc1" %>
 <uc1:ActivationEmailBody ID="ActivationEmailBody1" runat="server" Visible=false />
 
 <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="always">
    <ContentTemplate>
    <div runat="server" id="dvSigupControlHolder">
        <ul style="width:500px">
        <li><h2 class=heading>Registration</h2></li>
        <li><asp:Label runat="server" ID="lblEmailAttribute" Text="Your Email:" CssClass="AttributeLabel" ></asp:Label><asp:TextBox runat="server" ID="txtEmail" CssClass="single-text" MaxLength="30" ></asp:TextBox><asp:Label runat="server" ID="lblEmailValidator" ForeColor="#C85A23"></asp:Label></li>
        <li><asp:Label runat="server" ID="Label1" Text="Password" CssClass="AttributeLabel" ></asp:Label><asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="single-text" MaxLength="30"></asp:TextBox><asp:Label runat="server" ID="lblPasswordValidator" ForeColor="#C85A23" ></asp:Label></li>
        <li><asp:Label runat="server" ID="Label3" Text="Re Enter password" CssClass="AttributeLabel" ></asp:Label><asp:TextBox runat="server" ID="txtRePassword" TextMode="Password" CssClass="single-text" MaxLength="30"></asp:TextBox><asp:Label runat="server" ID="lblRepasswordValidator" ForeColor="#C85A23" ></asp:Label></li>
        <li><span class="AttributeLabel">Display Name:<span style="color:#2F9A8F; font-size:10px;"><br /> You will be known with this name all over the site</span></span><asp:TextBox runat="server" ID="txtDisplayName" CssClass="single-text" MaxLength="20" ></asp:TextBox><asp:Label runat="server" ID="lblDisplayValidator" ForeColor="#C85A23" ></asp:Label></li>
        <li><span class="AttributeLabel">BMDC REG NO:<span style="color:#2F9A8F; font-size:10px;"><br />Applicable for the doctors only</span></span><asp:TextBox runat="server" ID="txtBMDCRegNo" CssClass="single-text" MaxLength="7"></asp:TextBox><asp:Label runat="server" ID="lblBMDCRegNoValidator" ForeColor="#C85A23" ></asp:Label></li>
        <li><span class="AttributeLabel"></span>
        <cc1:CaptchaControl ID="Captcha1" runat="server"

 CaptchaBackgroundNoise="Low" CaptchaLength="5"

 CaptchaHeight="60" CaptchaWidth="200"

 CaptchaLineNoise="None" CaptchaMinTimeout="5"

 CaptchaMaxTimeout="240" FontColor = "#529E00" />
   

        </li>
        
        <li> <asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox>
</li>
<li><asp:Label runat="server" ID="lblCaptchaValidator"></asp:Label></li>
        <li ><asp:Label runat="server" ID="Label2" Text="" CssClass="AttributeLabel" ></asp:Label><asp:Button runat="server" Text="Submit" 
                ID="btnSubmit" onclick="btnSubmit_Click" /></li>
         
        </ul>
      </div>
      <div runat="server" id="dvMessageBoard" visible="false">
      <asp:Label runat="server" ID="lblmessageBoard"></asp:Label>
      Click<asp:HyperLink NavigateUrl="~/Default.aspx" Text=" here" runat="server" ID="hlinkToSignInPage" ></asp:HyperLink> to try again
      </div>  
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdateProgress runat="server" ID="uProgressMenu"  AssociatedUpdatePanelID="UpdatePanel1">
             <ProgressTemplate>
             <img src= "../Images/Site/updateprogress2.gif" class="progress" alt="Wait" style="position:absolute;z-index:3; top:300px; left:400px"  />
             </ProgressTemplate> 
</asp:UpdateProgress> 

