<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testpage.aspx.cs" Inherits="BDDoctors.testpage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
  
  
    <link href="CSS/mytab.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript"  src="JS/mytab.js"></script>
  
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode=Release>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
      <div class="yahoo-tab">
      <ul class="ulitem" >
        <li><a href=#  id="status" class="yaselected"   onclick="changeTab(this);" >Status</a></li>
        <li><a href=#  id="video"  class="yadeselected" onclick="changeTab(this);" >Video</a></li>
        <li><a href=#  id="image"  class="yadeselected" onclick="changeTab(this);" >Image</a></li>
        <li><a href=#  id="link" class="yadeselected" onclick="changeTab(this);" >Link</a></li>
        <li><a href=#  id="blog"  class="yadeselected" onclick="changeTab(this);" >Blog</a></li>
      </ul>
          <div id="tab-panel">
                <div id="divstatus" class="yaselected">
                <asp:TextBox runat="server" ID="txtEnterStatus" style="margin:6px" Height=30 Width=350></asp:TextBox><br /><asp:Button runat="server" ID="btnStatusPost" style="height:30px;margin:6px " Text="POST" />
                </div>
                <div id="divvideo" class="yadeselected" style="height:100px" >
                <ul>
                    <li><span style="font-size:10px; width:100px; display:inline-block">Enter Video Title</span><asp:TextBox runat="server" ID="txtTabVideoTitle"></asp:TextBox> </li>
                    
                    <li><span style="font-size:10px; width:95px; display:inline-block"></span>  <asp:FileUpload runat="server" ID="FileUpload1" /> </li>
                    
                    <li><span style="font-size:10px;width:200px; margin-left:100px;  display:inline-block"> Select an video file on your computer</span> </li>
                    <li><span style="font-size:10px; width:95px; display:inline-block"></span><asp:Button runat="server" ID="Button3" style="height:30px;margin:6px " Text="POST" /></li>
                </ul>
                        
                    
           
                </div>
                <div id="divimage" class="yadeselected">
                    <span style="font-size:10px"> Select an image file on your computer</span> <br />
                    <asp:FileUpload runat="server" ID="fln" style="margin:5px" />  <br /><asp:Button runat="server" ID="Button1" style="height:30px;margin:6px " Text="POST" />
                </div>
                 <div id="divlink" class="yadeselected">
                     <asp:TextBox runat="server" ID="TextBox1" Text="http://" style="margin:6px" Height=30 Width=350></asp:TextBox><br /><asp:Button runat="server" ID="Button2" style="height:30px;margin:6px " Text="POST" />
                </div>
                <div id="divblog" class="yadeselected" >
                    <a href="BlogSection/CreateBlog.aspx" style="float:right; font-size:13px; color:Black; font-weight:bold">Create blog </a>
                </div>
               
          </div>
      </div>
 
    </ContentTemplate>
    </asp:UpdatePanel>
    <div>
    
    </div>
    </form>
</body>
</html>
