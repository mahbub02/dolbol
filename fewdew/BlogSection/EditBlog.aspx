<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeBehind="EditBlog.aspx.cs" Inherits="BDDoctors.BlogSection.EditBlog" %>
<%@ Register src="../Controls/LoggedInUserMenu.ascx" tagname="LoggedInUserMenu" tagprefix="uc1" %>


<%@ Register src="../Controls/BanglaHelpBox.ascx" tagname="BanglaHelpBox" tagprefix="uc2" %>


<%@ Register src="../Controls/Comment.ascx" tagname="Comment" tagprefix="uc3" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="fr-ch" lang="fr-ch">
<head>
<title>Edit Blog</title>
<link type="text/css" rel="stylesheet" href="rte.css" />
<style type="text/css">
body, textarea {
    font-family:sans-serif;
    font-size:12px;
        }
    
ul#ulBlog li span { font-size:11px;vertical-align:top;width:150px; margin-right:5px; display:inline-block;text-align:right }
ul#ulBlog  li input{ width:240px}
a.comment-delete{ visibility:visible}

</style>
        <link href="../CSS/Global.css" rel="stylesheet" type="text/css" />
          <script type="text/javascript" src="../JS/jquery-1.3.2.min.js"></script> 
          
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
  
    var textAreas= document.getElementsByTagName("textarea");
     
      for(var i=0;i<textAreas.length;i++)
     {
//     	if(textAreas[i].className=="bangla")
//	    {	
		makePhoneticEditor(textAreas[i]);
	
//		}
     }
    }
   function ShowActualSize(imgCntrl)
      {
          if(imgCntrl.src.search("_mini.jpg")>0)
          {
          imgCntrl.src=imgCntrl.src.replace("_mini.jpg","")+"_display.jpg";
//          imgCntrl.style.position="absolute";
          
          }
          else if(imgCntrl.src.search("_display.jpg")>0)
          {
           imgCntrl.src=imgCntrl.src.replace("_display.jpg","")+"_mini.jpg";
//           imgCntrl.style.position="relative";
          }
     }

     function TextAreaChange()
        {
          var areas =document.getElementsByTagName("textarea");
          for(var i=0;i<areas.length;i++)
          {
             
           areas[i].onclick=resizeit;
           areas[i].onmouseout=resizeitToSmall;
          }
        }
        function resizeit(e)
        {
           this.style.height="60px";
        }
        function resizeitToSmall(e)
        {
            if(this.value=="")
            {
             this.style.height="20px";
            }
        }
    </script>
 <script type="text/javascript" src= "../JS/jqdialog.min.js" ></script>
<link href="../CSS/jqdialog.css" rel="stylesheet" type="text/css" />  
<script type="text/javascript">
$(document).ready(function(){
    Onready();
});
function Onready(){

    CommentSectionAnimation();
    BindPostCommentEvents();
    BindDeleteCommentEvents();
    
}
function BindPostCommentEvents (){
  $(".btnPostMessage").bind("click",function(){
      var comment=$(this).prevAll(".txtEnterMessage").val();
      var container=$(this).parents(".CommentContainer")[0];
      var parentid=$(this).parents(".CommentContainer").children(".parent-id-container").val();
      ServerPostCommentAndBind(comment,parentid,container);
  });
}
function BindDeleteCommentEvents(){
    $(".delete-comment").bind("click",function(){
            var CommentId;
            var container;
            CommentId=$(this).attr("id");
            container=$(this).parents(".CommentContainer")[0];
            
                jqDialog.confirm("Do you really want to delete the comment?",
			        function() { ServerDeleteCommentAndBind(CommentId,container); },		// callback function for 'YES' button
			        function() {  }		// callback function for 'NO' button
		        );
    });
}
function CommentSectionAnimation (){
  $(".seeComment").bind("click",function(){

  $(this).fadeOut("slow");
      $(this).nextAll(".dvCommentTable").fadeIn("slow");
    });
}
function ServerPostCommentAndBind(comment,parentid,container)
    {
        $.ajax({
        
          type: "POST",
          url: "../home2.aspx/PostComment",
          data:"{'comment':'" + comment + "','parentid':'" + parentid + "'}",
            //My Comment joto gula params add korte chao toto gula 'no':'" + vua + "'  add koro "{ r }", er vetore
            //data: "{no:" + "13" + ","+"height:"+"100" +"}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
          container.innerHTML=msg.d;
          Onready();
          },
          error: AjaxFailed
        });
    }
    
    function ServerPostStatusMessage(txtStatus){
         var comment=$(txtStatus).prevAll("#textUserStatus").val();
         $(txtStatus).prevAll("#textUserStatus").val("");
         $.ajax({
          type: "POST",
          url: "../home2.aspx/PostStatusMessage",
          data:"{'comment':'" + comment + "'}",
          contentType: "application/json; charset=utf-8",
          dataType: "json",
          success: function(msg) {
         
           $("#AllFeed").html(msg.d+ $("#AllFeed").html());
          
          Onready();
          
          },
          error: AjaxFailed
        });
    }
    
     function ServerDeleteCommentAndBind(commentid,container)
        {
            $.ajax({
              type: "POST",
              url: "../home2.aspx/DeleteComment",
              data:"{'commentid':'" + commentid + "'}",

                //My Comment joto gula params add korte chao toto gula 'no':'" + vua + "'  add koro "{ r }", er vetore
        // data: "{no:" + "13" + ","+"height:"+"100" +"}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function(msg) {
                // Replace the div's content with the page method's return.
              container.innerHTML=msg.d;
              Onready();
              //// animation working
              
              
              
              },
              error: AjaxFailed
            });
            
        }
        
        
function AjaxFailed(result) {
    alert(result.status + ' ' + result.statusText);
 } 
 
 $(document).ready(function () {
    $('span.menu_class').click(function () { 
	$('ul.the_menu').slideToggle('medium');
	
    });
});
</script>
<style runat="server" id="serverStyle" type="text/css">
    
</style>
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
        alert("Html mood");
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
        <div id="main" style="width:1004px" >
            
                 <asp:LinkButton runat="server" ID="lbtndelete" Text="Delete" style="float:right"></asp:LinkButton>
                 
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
                        <li>
                           <span > </span><span style="font-weight:bold">You can upload more photo</span>
                        </li>
                         <li>   <span > Image</span><asp:FileUpload runat="server" ID="FileUpload2"  /><asp:Label runat="server" ForeColor=Red ID="lblfileupload2"></asp:Label>  </li>   
                         <li>   <span > Image</span><asp:FileUpload runat="server" ID="FileUpload3"  /><asp:Label runat="server" ForeColor=Red ID="lblfileupload3"></asp:Label>  </li>   
                         <li>   <span > Image</span><asp:FileUpload runat="server" ID="FileUpload4"  /> <asp:Label runat="server" ForeColor=Red ID="lblfileupload4"></asp:Label> </li>   
                         <li>   <span > Image</span><asp:FileUpload runat="server" ID="FileUpload5"  /><asp:Label runat="server" ForeColor=Red ID="lblfileupload5"></asp:Label>  </li>   
                         <li> <span > </span></li>
                             
                    </ul>
                    <p style=" float:left; width:100%; ">
                        &nbsp;<asp:DataList Width="350" DataKeyField="id" RepeatDirection=Horizontal 
                            RepeatLayout=Flow ID="DlAlbums" style=" float:left; width:400px"    runat="server"   
                                     AutoGenerateColumns="false" ondeletecommand="DlAlbums_DeleteCommand"   
                                    >
                                    
                                        
                                        <ItemTemplate>
                                            <%--<a href=photoalbum.aspx?PhotoAlbum=<%# DataBinder.Eval(Container.DataItem, "Parent_Node_Id")%>>    --%>        
                                            <span style="display:inline-block">
                                                <p> <img src="../Images/Node/<%# DataBinder.Eval(Container.DataItem, "Id")%>_mini.jpg" onclick="ShowActualSize(this);" /></p>
                                               <p> <asp:Button runat="server" ID="btnDelete" Text="delete" CommandName="delete" /></p>
                                           </span>
                                           
                                        </ItemTemplate>                                
                                    
                                </asp:DataList>
                    </p>
                   
                  <p style="float:left">
                     <uc3:Comment ID="Comment1" runat="server" />
                </p>
                
                <p style=" width:100%; float:left">
                    <asp:Button runat="server" ID="btnUpdateBlog" Height=30  OnClientClick="return validate();"
                      Text="Update description and title"   style="margin-bottom:150px; margin-left:100px; float:left "
                     onclick="btnUpdateBlog_Click"  />  
                  </p>
           
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