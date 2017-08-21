<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="BDDoctors.test2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>

 

<script language="Javascript">

function fileUpload(form, action_url, div_id)

{

var iframe = document.createElement("iframe");

iframe.setAttribute("id","upload_iframe");

iframe.setAttribute("name","upload_iframe");

iframe.setAttribute("width","0");

iframe.setAttribute("height","0");

iframe.setAttribute("border","0");

iframe.setAttribute("style","width: 0; height: 0; border: none;");

 

form.parentNode.appendChild(iframe);

window.frames['upload_iframe'].name="upload_iframe";

 

iframeId = document.getElementById("upload_iframe");

var eventHandler = function()  {

if (iframeId.detachEvent)

iframeId.detachEvent("onload", eventHandler);

else

iframeId.removeEventListener("load", eventHandler, false);

 

// Message from server...

if (iframeId.contentDocument) {

content = iframeId.contentDocument.body.innerHTML;

} else if (iframeId.contentWindow) {

content = iframeId.contentWindow.document.body.innerHTML;

} else if (iframeId.document) {

content = iframeId.document.body.innerHTML;

}

 

document.getElementById(div_id).innerHTML = content;

 

setTimeout('iframeId.parentNode.removeChild(iframeId)', 250);

}

 

if (iframeId.addEventListener)

iframeId.addEventListener("load", eventHandler, true);

if (iframeId.attachEvent)

iframeId.attachEvent("onload", eventHandler);

 

// Set properties of form...

form.setAttribute("target","upload_iframe");

form.setAttribute("action", action_url);

form.setAttribute("method","post");

form.setAttribute("enctype","multipart/form-data");

form.setAttribute("encoding","multipart/form-data");

 

form.submit();

document.getElementById(div_id).innerHTML = "Uploading...";

}

</script>

<!-- index.php could be any script server-side for receive uploads. -->

<form>

<input type="file" name="datafile" /></br>

<input type="button" value="upload"

onClick="fileUpload(this.form,'index.php','upload'); return false;" >

<div id="upload"></div>

</form>

</html>
