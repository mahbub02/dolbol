<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="youtube.aspx.cs" Inherits="BDDoctors.youtube" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="JS/jquery-1.3.2.min.js"></script>
   
    <script type="text/javascript" >
        $(document).ready(function(){
           alert( $("#outer").height());
        });
    </script>
   
    
</head>
<body>
    <form id="form1" runat="server">
    <div id="outer">
        <div id="textContainer" style="width:20px; position:absolute; display:inline-block">
            amar o poran o jaha chay . tumi tai go tumi tai.
        </div>
    </div>    
    </form>
</body>
</html>
