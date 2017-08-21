<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LayoutStyle.aspx.cs" Inherits="BDDoctors.LayoutStyle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
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
<link href="CSS/Layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">

     <div id="header-area">
            Header content will be placed here
     </div>

    <div id="content-area" style=""  >
        <div style="width:490px; height:500px; float:left; background-color:#E87E1C; height:100%">
            <p style="float:left"> Test Purpose. You can delete me</p>
         </div>
        <div style="width:490px;height:500px; float:left; background-color:#15B2A9; height:100%">Test Purpose. You can delete me</div>
    </div>


    <div id="footer">
        <div id="footer-inner">
            footer content will be placed here
        </div>
    </div>
</form>
</body>
</html>
