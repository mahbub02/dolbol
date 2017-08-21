<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BDDoctors.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link rel="shortcut icon" href="Images/Site/fewdew.png" type="image/x-icon" />
<title>DolBol</title>
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
 <style type="text/css">
    #footer-inner {background-image:url(images/site/greentop.gif);}
 </style>       
<link href="CSS/Layout.css" rel="stylesheet" type="text/css" />
<link href="CSS/default2.css" rel="stylesheet" type="text/css" />
<link href="CSS/jqdialog.css" rel="stylesheet" type="text/css" />	

<script type="text/javascript" src="JS/jquery-1.3.2.min.js" ></script>
<script type="text/javascript" src="JS/Default2.js" ></script>
<script type="text/javascript" src="JS/jqdialog.min.js" ></script>

</head>
<body>
<form id="form1" runat="server">

     <div id="header-area" >
           
                <ul>
                  
                    <li id="menu-company" class="menu"><span >Company</span></li>
                    <li id="menu-contact-us" class="menu"><span>Contact us</span></li>
                </ul>
           
     </div>

    <div id="content-area" style=""  >
        <div id="left-block">
            <div id="logo-container">
          
            </div>
            <div style="display:inline">
            <span id="what-is-fewdew">What is DolBol?</span> 
            <div id="fewdew-description">
            
 DolBol is a virtual world and it runs directly in the web browser with nothing to install. DolBol is a milestone in the virtual 3d community for its faster loading capability. Newcomer can select avatar for free and ready to explore the worlds, meet other members, making friendship and chat with comfy features of thousand of emoticons, share his thought in wall, share photo and a lots.Members see the world and others avatar in an isometric perspective and click interface. DolBol goes far beyond other browser based worlds for its server based real time rendering that normally 3d world offer.
A beta version is now online. “The really interesting stuff is still in development”,. 

                
            </div>
            </div>
            
        </div>
        <div id="right-block">
               <div id="panda-image">
                
               </div> 
                <div id="LoginBoxContainer"  >
                    <div id="LoginBoxHeader">
                        Already a member?
                        
                    </div>
                    <div id="Loginbox"   >
                        <ul>
                            <li><span>Email</span><input type="text" id="txtEmail" class="text-box" /></li>
                            <li><span>Password</span><input type="password" id="txtPassword" class="password-box" /></li>
                            <li><span id="Message" >&nbsp</span><input type="button" class="small-button" id="btnLogin" value="Sign in" /></li>
                            
                        </ul>
                        <div>
                        <span id="sign-up">Sign up</span>
                            <span>It's free and anyone can join</span>
                        </div>
                        
                    </div>                     
            </div> 
            
        </div>
        <div id="company-details" class="menu-details">
             <span style="font-weight:bold">Company</span>   
             <p>  In October 2009, the founders of DolBol set out to create a virtual world where people could have fun and interact. </p> 
          <%--   <p>After months of consultation, research and testing, DolBol opened to the public in February 2010.</p> 
             <p>   Recently they, DolBol opened its first office in Dilkusha, Bangladesh, in order to provide localized player support and moderation.
We're passionate about community engagement and we work hard to foster a culture of giving, both in the virtual world of DolBol and within our company.</p> --%>
    

        </div>
        
        
        <div id="contact-us-details" class="menu-details" >
           <div id="business-inquiries" >
           <span > Business Inquiries</span>
           <%-- For corporate inquiries contact the DolBol Business Department.
            Please direct business inquiries to the Business Department. --%>
            
            
          <%--  Email:mahbub.rahman0204@gmail.com --%>

           </div>
           <div id="media-information" >
                <span>Media Information</span>
              <%--  Our media department maintains an archive of DolBol news releases and an up-to-date FAQ.--%>
               <%-- Email:mahbub.rahman0204@gmail.com --%>
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

