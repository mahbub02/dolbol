<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="BDDoctors.Registration" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="shortcut icon" href="Images/Site/fewdew.png" type="image/x-icon" />

<title>DolBol:Registration</title>
        <!--[if lte IE 6]>
        <style type="text/css">
        html, body{
        height:100%;
        overflow:hidden;
        }

        #outer {
        overflow:auto;
        height:99.9%;

        }

        #contain-all{
        position:absolute;
        overflow:auto;
        width:100%;
        height:100%;
        }

        /* add a margin to the footer to avoid obscuring the scroll-bar */
        #footer-inner {
        margin-right:17px;
        }

        </style>
        <![endif]-->
<link href="CSS/Layout.css" rel="stylesheet" type="text/css" />
<link href="CSS/registration.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="JS/jquery-1.3.2.min.js" ></script>
<script type="text/javascript" src="JS/jquery.pstrength-min.1.2.js" ></script>
<script type="text/javascript" src="Js/ui.core.js"></script>
<script type="text/javascript" src="Js/ui.datepicker.js"></script>
<link type="text/css" href="JS/themes/ui-lightness/ui.all.css" rel="stylesheet" />
  
<script type="text/javascript" src="JS/Registration.js" ></script>
</head>
<body>
<form id="form1" runat="server">

     <div id="header-area" >
           
                <ul>
                  
                    <li id="menu-company" class="menu"><span >Company</span></li>
                    <li id="menu-contact-us" class="menu"><span>Contact us</span></li>
                     <li id="menu-signin" class="menu"><span>Sign in</span></li>
                </ul>
           
     </div>

    <div id="content-area" style=""  >
    <input type=hidden runat="server" id="invitedBy" />
        <div id="left-block">
            <div id="logo-container">
          
            </div>
            <div style="display:inline">
            <span id="what-is-fewdew">What is DolBol?</span> 
            <div id="fewdew-description">
            
 DolBol is a virtual world and it runs directly in the web browser with nothing to install. DolBol is a milestone in the virtual 3d community for its faster loading capability. Newcomer can select avatar for free and ready to explore the worlds, meet other members, making friendship and chat with comfy features of thousand of emoticons, share his thought in wall, share photo and a lots.Members see the world and others avatar in an isometric perspective and click interface. DolBol goes far beyond other browser based worlds for its server based real time rendering that normally 3d world offer.
A beta version is now online. “The really interesting stuff is still in development”, 

                
            </div>
            </div>
            
        </div>
        <div id="right-block">
               <div id="panda-image">
                
               </div> 
                <div id="SignupBoxContainer"  >
                    <div id="SignupBoxHeader">
                        Sign up
                        
                    </div>
                    <div id="Signupbox"   >
                        <ul>
                            <li><span>Display Name</span><input type="text" id="txtDisplayName" runat="server"  class="text-box required" /><span id="check-availability">Check availability</span><span id="availability-message">&nbsp</span></li>
                            <li></li>
                            <li><span>Email</span><input type="text" id="txtEmail" class="text-box required" runat="server"  /><span id="email-message"></span></li>
                            <li><span>New Password</span><input type="password" id="txtPassword" class="password-box required" runat="server" /></li>
                            <li><span>I am</span>
                                <select id="sex" runat="server">
                                    <option value="Male" selected=selected>Male</option>
                                    <option value="Female">Female</option>
                                </select>
                            </li>
                            <li><span>Birthday</span><input type="text" id="txtBirthday" runat="server" class="text-box required"  /></li>
                            
                            <li>
                                <div>
                                    <div id="maleAvatar" class="avatar-collection">
                                        
                                        
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a5.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a6.png" class="avatar" />
                                        <%-- <img src="Images/AvatarChat/Avatar/sample/Male/a11.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a13.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a14.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a17.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a19.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a20.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a21.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a22.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a23.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a24.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a27.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a28.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a29.png" class="avatar" />--%>
                                       
                                        
                                    </div>
                                    <div id="femaleAvatar" class="avatar-collection" style="display:none">
                                        <img src="Images/AvatarChat/Avatar/sample/female/a4.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/female/a7.png" class="avatar" />
                                        <%--<img src="Images/AvatarChat/Avatar/sample/female/a8.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/Male/a12.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/female/a9.png" class="avatar" />
                                        <%--<img src="Images/AvatarChat/Avatar/sample/female/a10.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/female/a15.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/female/a16.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/female/a18.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/female/a25.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/female/a26.png" class="avatar" />
                                        <img src="Images/AvatarChat/Avatar/sample/female/a30.png" class="avatar" />--%>
                                        
                                    
                                    </div>
                                    <span id="avatar-selection-message">Select an avatar from the list</span>
                                </div>
                            </li>
                            <li ><span>&nbsp</span></li>
                             <%--<li><span>&nbsp</span>
                             <cc1:CaptchaControl ID="Captcha1" runat="server"
                             CaptchaBackgroundNoise="Low" CaptchaLength="3"
                             CaptchaHeight="31" CaptchaWidth="100" BackColor="#B0C62A"
                             CaptchaLineNoise="None" CaptchaMinTimeout="5"
                             CaptchaMaxTimeout="240" FontColor = "#223F00" />
                             </li>--%>
                       <%-- <li><span>&nbsp</span><input type="text" id="txtCaptchaText" maxlength="6" class="text-box required" runat="server" /></li>
                        <li><span>&nbsp</span><span style="width:200px; font-size:9px; text-align:left ">Letters are not case-sensitive </span></li>
                        --%>    
                            <li><span id="Message" >&nbsp</span><input type="button" class="small-button" id="btnLogin" value="Sign up" /></li>
                            
                        </ul>
                        <div>
                        
                        </div>
                        
                    </div>
                    <div id="SignupMessagebox" style=" width:100%; height:100px; line-height:100%; display:none;">
                     <span id="SignupSeccessMessage" style="display:none;"> 
                        An email has been sent to your email address.Please check your mail to activate account.
                     </span>
                     <span id="SignupFailedMessage" style="display:none;">
                       An error occured during the sign up process. Please try again with different email address.
                       <span id="TryAgain" style="font-weight:bold; cursor:pointer ">Try Again</span>
                       
                     </span>
                     
                        
                         
                    </div>                     
               </div> 
            
        </div>
        <div id="company-details" class="menu-details">
             <span style="font-weight:bold">Company</span>   
             <p>  In October 2009, the founders of DolBol set out to create a virtual world where people could have fun and interact. </p> 
            <%-- <p>After months of consultation, research and testing, DolBol opened to the public in February 2010.</p> 
             <p>   Recently they, DolBol opened its first office in Dilkusha, Bangladesh, in order to provide localized player support and moderation.
We're passionate about community engagement and we work hard to foster a culture of giving, both in the virtual world of DolBol and within our company.</p> 
    --%>

        </div>
        
        
        <div id="contact-us-details" class="menu-details" >
           <div id="business-inquiries" >
           <span > Business Inquiries</span>
            For corporate inquiries contact the DolBol Business Department.
            Please direct business inquiries to the Business Department. 
            
          
           <%-- Email:mahbub.rahman@dolbol.com --%>

           </div>
           <div id="media-information" >
                <span>Media Information</span>
             <%--   Our media department maintains an archive of DolBol news releases and an up-to-date FAQ.--%>
              <%--  Contact Number: +8801730088109
                Email:media@dolbol.com --%>
           </div>
        </div>
             
        
        
            
    </div>


    <div id="footer">
        <div id="footer-inner">
             <span id="copy-right">DolBol Inc. © 2010. All rights reserved.</span>
        </div>
    </div>
</form>
</body>
</html>


