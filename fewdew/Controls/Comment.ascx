<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="Comment.ascx.cs" Inherits="BDDoctors.Controls.Comment" %>
 



    <div style="width:420px;display:inline-block; float:left;" class="CommentContainer" id="CommentContainer">
        
        <a runat="server" id="seeAll" class="seeComment" style="float:left; "  ></a>
           <input type="hidden" id="hiddenParentContainer" class="parent-id-container" runat="server" />
     <div class="dvCommentTable" style="display:none">
        <asp:DataList ID="GridComment" runat="server"  CssClass="comment"
AutoGenerateColumns="false" ShowFooter=true ShowHeader="false" style="width:420px;"  DataKeyNames="Id"
                  
            >
        
                                    
                                    <ItemTemplate>
                                    <div class="hidden<%# DataBinder.Eval(Container.DataItem, "User_id")%>">
                                          <div style="width:50px;float:left; ">  <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "User_id")%>_mini.jpg" /></a></div>
                                          
                                          <div style="width:100px;float:left; text-align:left">
                                            <a href=Profile.aspx?user=<%# DataBinder.Eval(Container.DataItem, "User_id")%>>   <%# DataBinder.Eval(Container.DataItem, "User_Name")%></a>
                                            <div style="color:#2F3337; font-size:10px"><abbr class="timeago" title=<%# ((DateTime)DataBinder.Eval(Container.DataItem, "action_date")).ToString("yyyy-MM-ddTHH:mm:ss", null) %> ></abbr>
</div>
                                          </div>
                                          
                                          <div style="width:250px;float:left; max-width:240px; text-align:left">
                                                <div><asp:label runat="server" style="display:inline" ID="lblMessage"   Text=<%# DataBinder.Eval(Container.DataItem, "Node_value")%>></asp:label> </div>
                                          </div>
                                          <div style="float:left; width:10px; cursor:pointer" class="delete-comment-of<%# DataBinder.Eval(Container.DataItem, "User_id")%>" >
                                           <span id=<%# DataBinder.Eval(Container.DataItem, "Id")%> class="delete-comment" >X</span> 
                                          </div>
                                     </div>     
                                    </ItemTemplate> 
                                    
                                    <FooterTemplate>
                                           <div  style="float:right" class="comment-box">
                                            
                                           <textarea  id="txtEnterMessage" class="txtEnterMessage" cols="30"></textarea>
                                            <input type=button id="btnPostMessage" class="btnPostMessage"  value="Send" />
                                            
                                            </div>
                                            

                                            
                                    </FooterTemplate>   
                                                                   
                             
                                 
                                
       
        
    </asp:DataList>
    </div>     
    
    </div>
    
   