<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IframeUploadWallPhoto.aspx.cs" Inherits="BDDoctors.IframeUploadWallPhoto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
//        window.onunload=function() {alert("");}
    function PublishThisPhotoIntoWall()
    {
       //alert(document.getElementById("txtTitle").value);
       parent.PublishThisPhotoIntoWall(document.getElementById("HiddenFileName").value,document.getElementById("txtTitle").value,document.getElementById("txtDescription").value);
    }
    
    </script>
    <style type="text/css">
        #txtTitle{ width:120px;height:20px; background-color:#DDE3B7; border:1px solid #92A138}
        #txtDescription{ width:180px;height:40px; background-color:#DDE3B7; border:1px solid #92A138}
        div#post-form { width:300px;display:inline-block; text-align:left }
        div#post-form div{ width:300px; display:inline-block}
        div#post-form span{ width:100px;text-align:right; vertical-align:top; display:inline-block; color:#859A16; font-size:11px; }

    </style>
</head>
<body style="width:300px; background-color:#DDE3B7; height:300px; margin:0 auto; text-align:center; " >
     <form id="form1" runat="server">
     <input type="hidden" id="HiddenFileName"  value=<%=FileName%> />
     <div style="margin:0 auto;">
     <% Random rnd = new Random();%>
        
        <div  style="display:inline-block;  width:200px; height:200px;  background-repeat:no-repeat; background-image:url(Images/Node/<%=FileName%>_profile.jpg?rnd=<%=rnd.Next(1,20000).ToString()%>)">
        </div>
        <div>
          
         <%if (FileName == "0"){ %>  
                 <p style="font-size:10px;">To upload any photo. You just need to upload new photo from your local source</p>
                <asp:Label runat="server" ID="lblPhotoInformation" ForeColor=Red></asp:Label>
                <br />
                <asp:FileUpload ID="FileWallPhotoUpload" runat="server" style="background-color:white; " />
                <asp:Button runat="server" ID="btnUploadPhoto" Text="Upload" style="background-color:#859A16; border:1px solid black; color:White; font-weight:bold; cursor:pointer; height: 24px;" onclick="btnUploadPhoto_Click" 
                    />
         <%} %>    
        
        <%else{ %> 
            <div id="post-form">
            
               <div>   <span >Title:</span>  <textarea type="text" id="txtTitle" ></textarea></div>
               <div> <span>Description:</span>  <textarea type="text" id="txtDescription"></textarea></div>
               <div><span>&nbsp </span> <input type="button" id="btnPublishToWall" value="Publish into wall" style="background-color:#859A16; border:1px solid black; color:White; font-weight:bold; cursor:pointer; height: 24px;" onclick="PublishThisPhotoIntoWall();" 
                /></div>
            </div>       
         
        <%} %>        
        </div>
    </div>
    
    </form>
</body>
</html>
