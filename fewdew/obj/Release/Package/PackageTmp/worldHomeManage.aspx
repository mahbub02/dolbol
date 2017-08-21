<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="worldHomeManage.aspx.cs" Inherits="BDDoctors.worldHomeManage" %>
<%@ Import  Namespace=BDDoctors.DAL.DataObject %>
<%@ Import Namespace=BDDoctors.DAL.DataAccess %>
<%@ Import Namespace=BDDoctors%>
<%@ Register src="Controls/LinkGenerator.ascx" tagname="LinkGenerator" tagprefix="uc1" %>
<%@ Reference Control="~/Controls/LinkGenerator.ascx" %>
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

    <link href="Css/Layout.css" rel="stylesheet" type="text/css" />
    <link href="Css/ui.resizable.css" rel="stylesheet" type="text/css" />
    <link type="text/css" media="screen" rel="stylesheet" href=colorbox.css />
       
    <script type="text/javascript" src="Js/jquery-1.3.2.min.js" ></script>
    <script type="text/javascript" src="Js/ui.core.js"></script>
    <script type="text/javascript" src="Js/ui.draggable.js"></script>
    <script type="text/javascript" src="Js/ui.droppable.js" ></script>
    <script type="text/javascript" src="Js/ui.resizable.js" ></script>
    <script src="Js/jquery.colorbox-min.js" type="text/javascript"> </script>
    <script src="Js/WorldHomeMange.js" type="text/javascript"></script>

 

 
    
<style type="text/css">
    .draggable { float: left;cursor:move }
    div#controller{width:150px; padding:25px; padding-top:50px; border:1px solid red }
    div#controller span{ width:130px; height:20px;border:1px solid #CCC; cursor:pointer; background-color:#A88054; margin:4px; display:inline-block;}
    div#controller span:hover{ border-color:black}

    div#create-world-form{ background-color:#BF925D}
    div#create-world-form ul li { margin-bottom:10px; }
    div#create-world-form ul li span{ width:150px;vertical-align:top; font-size:14px; font-weight:bold; color:#704527; display:inline-block; text-align:right}
    #menu{position:absolute;width:115px; height:130px; padding-left:10px; padding-top:30px; background-image:url(images/MenuBack.gif); display:none; }
    #menu span{ width:100px; height:20px; border:1px solid #CCC; cursor:pointer; background-color:#A88054; font-size:10px; margin:2px; display:inline-block;}
    #menu span:hover{border:1px solid black;}
    #description-context{position:absolute;width:115px; height:130px; padding-left:10px; padding-top:30px; background-image:url(images/MenuBack.gif); display:none; }

</style>
	
     
       
</head>



<body style="min-height:450px; overflow:hidden;">
<form id="form1" runat="server">
<img src="Images/site/busy.gif" id="loading" style="display:none; position:absolute; z-index:100" alt="wait" />
<input runat="server" id="hiddenParentidContainer" type="hidden" />
     <div id="header-area">
           <%-- <uc2:NewHeaderControl ID="NewHeaderControl1" runat="server" />--%>
     </div>

    

<div id="content-area" style=""  >
   
        <div id="droppable"  style="width:760px;float:left; overflow:hidden; height:100%; background-color:Transparent; border:1px solid #916640">
        
              <% BDDoctors.DAL.DataObject.JagPlace ParentPlace=BDDoctors.DAL.DataAccess.jagPlace.GetJagPlaceById(Convert.ToInt32(Request["place_id"])); %>
              

                <input type="hidden"  value="<%=ParentPlace.Description %>" class="parentdescriptin" />
                
                <div class="resizable" id="<%=Request["place_id"]%>" style="width:<%=ParentPlace.width%>px;height:<%=ParentPlace.Height%>px;padding:0px;">
                    <img src="PlaceBackground/Resized/<%=Request["place_id"]%>.jpg" alt="" style="width:100%; height:100%"  />
                </div>  
                
                                
                <% string   aspxPageName=string.Empty;%>
   
                <%foreach(BDDoctors.DAL.DataObject.JagPlace objjagplace in BDDoctors.DAL.DataAccess.jagPlace.GetChildJagPlaceByParentIdAndLevel(Convert.ToInt32(Request["place_id"]),BDDoctors.DAL.DataObject.JagPlaceLevel.WorldPlace))  %>
                <%{ %>
                     <%  aspxPageName = Enum.GetName(typeof( BDDoctors.DAL.DataObject.JagPlaceLevel), objjagplace.Level).ToString();%>
                  <div class="draggable" id="<%=objjagplace.Id%>" style="position:absolute; width:150px; height:58px; overflow:hidden; background-repeat:no-repeat;  background-image:url(images/SmallNamePlate.gif); top:<%=objjagplace.Top%>px;left:<%=objjagplace.Left%>px">
                        <a style="font-size:15px; padding:10px; color:#896733" href="<%=aspxPageName%>.aspx?place_id=<%=objjagplace.Id%>"><%=objjagplace.Name%></a>
                        <input type="hidden"  value="<%=objjagplace.Description %>" class="descriptin" />
                  </div> 
                <%} %>
                
                <div id="history" style="position:absolute; z-index:100; height:180px;width:165px; padding:10px; padding-left:20px; padding-top:50px; display:none; background-repeat:no-repeat; background-image:url(images/papyras.gif); ">
                    <% System.Collections.Generic.List<BDDoctors.DAL.DataObject.JagPlace> PlaceLIst = BDDoctors.DAL.DataAccess.jagPlace.GetJagPlaceMap(Convert.ToInt32(Request["place_id"]));%>
                    <% PlaceLIst.Reverse();%>
                    <% foreach( BDDoctors.DAL.DataObject.JagPlace place in  PlaceLIst)%>
                    <%{ %>
                         <%  aspxPageName = Enum.GetName(typeof( BDDoctors.DAL.DataObject.JagPlaceLevel), place.Level).ToString();%>
                         

                    <div class="history-item" style="max-width:73px; overflow:hidden; min-width:71px;min-height:50px; max-height:50px; margin:2px; display:block ">
                    <div style="width:70px; height:40px">
                    <div style="width:50px; height:40px; overflow:hidden">
                    <a style="color:#896733" href="<%=aspxPageName%>.aspx?place_id=<%=place.Id%>" title="<%=place.Description%>">
                    <img src="PlaceBackground/thumbs/<%=place.Id%>.jpg" style="width:50px; max-height:40px" alt="<%=place.Description%>" />
                    </a>
                    </div>
                    <div>
                    <img style="" src="Images/arrow.gif" alt="" />
                    </div>
                    <div style="width:70px; height:15px;">
                    <span style="font-size:10px; float:left; color:#704527; font-weight:bold"> <%=place.Name%></span>
                    </div>
                    </div>

                    </div>


                    <%}%>
                </div>

                  
        </div>
        
         <div id="controller" style=" background-image:url(images/papyras.gif); background-repeat:no-repeat; float:right;height:100%;background-color:white ">
             
              <span class='create-world-link'>Create new World</span>
              <span class='upload-Background'>BackGround Image</span>
               <span class='pathlink'>Show me my path</span>

               <asp:Label runat="server" style="border:none; background:transparent;" ID="lblbackGroundUploadMessage"></asp:Label> 
               
              <div id="dvUploadImage" style="display:none; padding:10px;  border:2px solid #A88054">
                    <asp:FileUpload runat="server" ID="FuploadBackground" /> <br />
                    <asp:button runat="server" ID="btnUploadBackground" Text="Upload" 
                        onclick="btnUploadBackground_Click" />
                </div>
         </div>
         
             <div style="display:none; ">
                    <div id="create-world-form" >
                        <ul>
                            <li><span>Enter world name</span><input id="txtWorldName" type="text" /></li>
                            <li><span>Enter world Description</span><textarea id="txtWorldDescription" ></textarea></li>
                            <li><span>Access Type</span><input type="radio" name="accessType" checked=checked value="0"   />Public   <input type="radio" name="accessType" value="1"  />Private </li>
                            <li><span></span><input id="btnCreateWorld" type="button" value="Create world" /></li>
                            
                        </ul>
                        
                    </div>
              </div>
              <div  id="menu" style="">
                      
                       <span style="" id="spanSaveChanges">Save changes</span>                       
                        <span style=" background-color:Transparent; border:none; border-top:1px solid black;width:100px; height:60px; overflow:auto; display:inline-block; text-align:justify" id="spandescription">Description</span>
                       <input type=hidden id="idContainer" />
                      
              </div>
             
              
                
              

    </div>

    

    


    <div id="footer">
        <div id="footer-inner">
            footer content will be placed here
        </div>
    </div>
</form>
</body>
</html>