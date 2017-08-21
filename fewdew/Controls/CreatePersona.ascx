<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatePersona.ascx.cs" Inherits="BDDoctors.Controls.CreatePersona" %>


 

                             <div runat="server" id="divCreatePersona"  style="background-color:#393D3D; margin-top:20px; color:White; height:80px" >
                                    
                                       <span> Your Personal facade that you can presents to the world </span>
                                       <span style="font-size:smaller">(Maximum 10 persona allowed)</span>
                                        <asp:Label runat="server" ID="lblValidationMessage"   ></asp:Label>
                                            <ul runat="server" id="ulControl">
                                            
                                                <li><asp:Label runat="server" ID="Label1" Text="Enter Persona display name" ></asp:Label> <asp:TextBox ID="txtPersonaName" MaxLength="20" runat="server"></asp:TextBox> <asp:Button runat="Server" ID="btnCreate" Text="Create" 
                                                         onclick="btnCreate_Click"   /></li>
                                                  
                     
                                            </ul> 
                                   
                                </div>

        
        
        
If you click any persona then you will turn into a new person. To hide or express yourself with new look and behaviour, try it.
<asp:DataList ID="GridViewPersona" runat="server" CssClass="Persona"   DataKeyField="id"
    RepeatDirection="Horizontal" RepeatLayout=Flow  
        AutoGenerateColumns="false" ShowFooter="false"  DataKeyNames="ID"  style="float:left; width:100%"
    ShowHeader="false" oneditcommand="GridViewPersona_EditCommand"      
        >
  
            <ItemTemplate>
            
                <ul style="background-color:black; padding:5px; margin:5px;">
                   <%--<li><asp:ImageButton   ImageUrl=<%#"~/Images/profile/"+ DataBinder.Eval(Container.DataItem,"Id")+"_display.jpg"%> runat="server" ID="imgUser" CommandName="edit" /></li> --%>
                    <li><asp:LinkButton runat="server" ID="lbtnStartConversation" CommandName="edit" ><img src="Images/profile/<%# DataBinder.Eval(Container.DataItem, "Id")%>_thumb.jpg" />  </asp:LinkButton></li> 
                    <li style="color:White" ><%#DataBinder.Eval(Container.DataItem, "DisplayName")%> </li>
                </ul>
                
            </ItemTemplate>   
                                           
      
 </asp:DataList>
 
 
 

                               