<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="speech.aspx.cs" Inherits="BDDoctors.speech" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>Layout</title>
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
<script type="text/javascript" src="Js/jquery-1.3.2.min.js" ></script>
<script type="text/javascript" src="JS/JqueryTimer.js"></script>
<script type="text/javascript" src="JS/speech.js" ></script>
<link href="CSS/Layout.css" rel="stylesheet" type="text/css" />
 <link href="CSS/Speech.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="JS/phonetic_int.js"></script>
<script type="text/javascript">
_uacct = "UA-1154128-1";
urchinTracker();
</script>

<script type="text/javascript">
</script>


<style type="text/css">
div.avatarUser{ width:100px; height:100px; margin:10px; background-color:Blue;}
</style>

       

</head>

<body  style="height:2000px">
<form id="form1" runat="server">

     <div id="header-area">
            Header content will be placed here
     </div>
     <div id="content-area" style="height:600px; margin:0 0; ">
     <div class="avatarUser" id="Mahbub">
     Shakil 
    </div>
    <div class="avatarUser" id="Habib">
     Sadeq  
     </div>
     <div class="avatarUser" id="Khokan">
     Zaman  
     </div>
     <div class="avatarUser" id="Moni">
     Shovo
     </div>
     <div class="avatarUser" id="Roksana">
     Alif
     </div>
     <div class="avatarUser" id="7">
     Rafiq
     </div>
     <div class="avatarUser" id="8">
     Rafiqul
     </div>
     <div class="avatarUser" id="9">
     hasib
     </div>
     <div id="checker">
     </div>

     
     </div>
    <div id="footer">
        <div id="footer-inner">
        </div>
    </div>
    </form>
</body>
</html>
