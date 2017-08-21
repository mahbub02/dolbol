<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateBlog.aspx.cs" EnableViewState="true" ValidateRequest="false" Inherits="BDDoctors.BlogSection.CreateBlog" %>

<%@ Register src="../Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>


<%@ Register src="../Controls/BanglaHelpBox.ascx" tagname="BanglaHelpBox" tagprefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="fr-ch" lang="fr-ch">
<head>
<title>Create Blog</title>
<link type="text/css" rel="stylesheet" href="rte.css" />
<style type="text/css">
body, textarea {
    font-family:sans-serif;
    font-size:12px;
        }
    
   ul#ulBlog li span { font-size:11px;vertical-align:top;width:150px; margin-right:5px; display:inline-block;text-align:right }
    ul#ulBlog  li input{ width:240px}
 

</style>
        <link href="../CSS/Global.css" rel="stylesheet" type="text/css" />
        
        <script type="text/javascript" src="../JS/phonetic_int.js"></script>  
      
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
  
    var textArea= document.getElementById('id_description');
   	
		makePhoneticEditor(textArea);
		
     
    }
     
    </script>
    <script type="text/javascript">
    function validate()
    {
        if(document.getElementById("txtBlogTitle").value.length==0)
        {
        document.getElementById("txtBlogTitle").focus();
            alert("Please enter blog title");
           return false;
        }
        alert(document.getElementsByTagName("Body")[1].innerHTML);
        if(document.getElementById("id_description").value.length<3)
        {
        document.getElementById("id_description").focus();
        alert("Please enter blog description");
        return false;   
        }
        return true;
    }
    </script>
    <script type="text/javascript" >
function validate()
    {
        if( $("#txtBlogTitle").val().length<20)
        {
            alert("Title length must be of more than 20 character");
            return false;
        }
         if( $("#ddlCategory").val()=="-1")
        {
            alert("Select blog category");
            return false;
        }
    
      if($("#id_description").val()=="")
      {
        
          if($("#id_description").contents().find("body").html().length<20)
            {
              alert("Description length must be of more than 20 character");
              return false;
            }
      }
      else
      {
            if($("#id_description").val()<20)
            {
                 alert("Description length must be of more than 20 character");
                 return false;
            }      
      }
      

        

      
        
     
    }
</script>
</head>
<body onload="MakeBanglaEditor();switched=false;" onmousemove="MakeBanglaEditor();">

<form  runat="server" id="form1">

 <uc1:LoggedInUserMenu ID="LoggedInUserMenu1" runat="server" />
    <div class="body" >
        <div id="main" >
            <div style="float:left; width:500px" >
                 
                 
                 <ul id="ulBlog">
                        <li><asp:Label runat="server" ID="lblValidateMessage" ForeColor=Red></asp:Label></li>
                        <li><span style="" ></span> <a target=_blank href="../BanglaHelp/index.html">help to write bangla</a></li>
                        <li><span style="" >Enter blog Title</span><asp:TextBox style="font-size:16px; height:40px" runat="server" ID="txtBlogTitle" MaxLength="200" ></asp:TextBox></li>
                        <li ><span style="" >Enter blog Description</span></li>
                        <li style="margin-left:150px">
                            
                            <textarea name="description"  rows="20" cols="20"  id="id_description" style="font-size:20px"  runat="server" class="rte-zone"></textarea>
                        </li>
                       
                        <li><span style="" >Enter Category</span><asp:DropDownList runat="server" ID="ddlCategory">
                        <asp:ListItem Text="Fun" ></asp:ListItem>
                        <asp:ListItem Text="Serious"> </asp:ListItem>
                        </asp:DropDownList> 
                        </li>
                     
                        
                        
                         <li>   <span > Image</span><asp:FileUpload runat="server" ID="FileUpload2"  /><asp:Label runat="server" ForeColor=Red ID="lblfileupload2"></asp:Label>  </li>   
                         <li>   <span > Image</span><asp:FileUpload runat="server" ID="FileUpload3"  /><asp:Label runat="server" ForeColor=Red ID="lblfileupload3"></asp:Label>  </li>   
                         <li>   <span > Image</span><asp:FileUpload runat="server" ID="FileUpload4"  /> <asp:Label runat="server" ForeColor=Red ID="lblfileupload4"></asp:Label> </li>   
                         <li>   <span > Image</span><asp:FileUpload runat="server" ID="FileUpload5"  /><asp:Label runat="server" ForeColor=Red ID="lblfileupload5"></asp:Label>  </li>   
                         <li> <span > </span><asp:Button runat="server" ID="btnCreateBlog" OnClientClick="return validate();"  Height=30 
                                 Width=90 Text="Create blog" onclick="btnCreateBlog_Click" /></li>

                             
                    </ul>
                   
            </div>
            <div style="float:left">
                    <uc2:BanglaHelpBox 
                                ID="BanglaHelpBox1" runat="server" />
            </div>
        </div>   
    </div>





<script type="text/javascript" src="jquery.js"></script>
<script type="text/javascript" src="jquery.rte.js"></script>
<script type="text/javascript">
$('.rte-zone').rte('rte.css', '');
</script>
</form>
</body>
</html>
