<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="CreatePoll.aspx.cs" Inherits="BDDoctors.CreatePoll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Fewdew:Create Blog</title>
    <link href="CSS/Global.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
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
    <style type="text/css">
    textarea{ height:20px}
    </style>
    
</head>
<body onload="TextAreaChange();">
    <form id="form1" runat="server">
    <div runat="server" id="dvCreatePoll" enableviewstate=true>
    <ul>
    <li><div runat="server" id="dvMessage"></div></li>
    <li><span class="AttributeLabel">Enter Your Question</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtQuestion"></asp:TextBox>
        <asp:FileUpload ID="FileUploadQuestion" runat="server" />
                </li>
    <li><span class="AttributeLabel">Answer 1:</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtAnswer1"></asp:TextBox><asp:FileUpload ID="FileUpload1" runat="server" /></li> 
    <li><span class="AttributeLabel">Answer 2:</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtAnswer2"></asp:TextBox><asp:FileUpload ID="FileUpload2" runat="server" /></li> 
    <li><span class="AttributeLabel">Answer 3:</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtAnswer3"></asp:TextBox><asp:FileUpload ID="FileUpload3" runat="server" /></li>
    <li><span class="AttributeLabel">Answer 4:</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtAnswer4"></asp:TextBox><asp:FileUpload ID="FileUpload4" runat="server" /></li>
    <li><span class="AttributeLabel">Answer 5:</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtAnswer5"></asp:TextBox><asp:FileUpload ID="FileUpload5" runat="server" /></li>
    <li><span class="AttributeLabel">Answer 6:</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtAnswer6"></asp:TextBox><asp:FileUpload ID="FileUpload6" runat="server" /></li>
    <li><span class="AttributeLabel">Answer 7:</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtAnswer7"></asp:TextBox><asp:FileUpload ID="FileUpload7" runat="server" /></li>
    <li><span class="AttributeLabel">Answer 8:</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtAnswer8"></asp:TextBox><asp:FileUpload ID="FileUpload8" runat="server" /></li>
    <li><span class="AttributeLabel">Answer 9:</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtAnswer9"></asp:TextBox><asp:FileUpload ID="FileUpload9" runat="server" /></li>
    <li><span class="AttributeLabel">Answer 10:</span><asp:TextBox runat="server" TextMode=MultiLine ID="txtAnswer10"></asp:TextBox><asp:FileUpload ID="FileUpload10" runat="server" /></li>
    <li><span class="AttributeLabel">Answer type?</span></li>
    <li><span class="AttributeLabel"></span>
        <asp:RadioButtonList runat="server" style="display:inline" ID="rdoListSingleOrMulti">
            <asp:ListItem Text="Single" Selected=True Value="0" > </asp:ListItem>
            <asp:ListItem Text="Multiple" Value="1"> </asp:ListItem>
        </asp:RadioButtonList>
    </li>
    <li><span class="AttributeLabel"></span><asp:Button runat="server" ID="btnSubmit" 
            Text="Create Poll" onclick="btnSubmit_Click" /></li>
    </ul>
    <div>
    
    </div>
    
    </div>
    </form>
</body>
</html>
