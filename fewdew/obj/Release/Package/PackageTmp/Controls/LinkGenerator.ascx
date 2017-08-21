<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinkGenerator.ascx.cs" Inherits="BDDoctors.Controls.LinkGenerator" %>
<%--<%@ Import Namespace="BDDoctors.DAL.DataObject" %>
<%@ Import Namespace="BDDoctors.DAL.DataAccess" %>--%>

<% string   aspxPageName=string.Empty;%>

<%  aspxPageName = Enum.GetName(typeof( BDDoctors.DAL.DataObject.JagPlaceLevel), JagPlace.Level).ToString();%>
 <div class="draggable" id="<%=JagPlace.Id%>" style="position:absolute; width:150px; height:58px; overflow:hidden; background-repeat:no-repeat;  background-image:url(images/SmallNamePlate.gif); top:<%=JagPlace.Top%>px;left:<%=JagPlace.Left%>px"><a style="font-size:15px; padding:10px; color:#896733" href="<%=aspxPageName%>.aspx?place_id=<%=JagPlace.Id%>"><%=JagPlace.Name%></a>
    <input type="hidden"  value="<%=JagPlace.Description %>" class="descriptin" />
 </div>    