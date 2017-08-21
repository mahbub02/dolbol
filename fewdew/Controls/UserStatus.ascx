<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserStatus.ascx.cs" Inherits="BDDoctors.Controls.UserStatus" %>
                       
                       
                        <%@ Register src="Comment.ascx" tagname="Comment" tagprefix="uc1" %>
                       
                       
                        <div style=" width:100%; ">
                           STATUS: <asp:Label runat="server" ID="lblCurrentStatus" Text="I am going I would like you to go with me since your holiday is ...." ForeColor="#818181" ></asp:Label>
                            <asp:LinkButton runat="server" ID="lbtnStatusChangeInit" Text="Change/Set" 
                                 onclick="lbtnStatusChangeInit_Click"></asp:LinkButton>
                         </div>
                         <div style="width:100%; float:left; background-color:#CAF2EE" visible=false runat="server" id="dvStatus">
                            <%--<asp:ImageButton runat="server" ID=imgButtonStatusChange ImageUrl="~/Images/Site/StatusChange.gif" />--%>
                            <asp:TextBox runat="server" id="txtUserStatus" TextMode="MultiLine" CssClass="status-text-box"  ></asp:TextBox> 
                            <asp:Button runat="server" ID="btnStatusChange" Text="SET"  style="vertical-align:top; height:50px"  />
                         </div>
                         
                     <asp:GridView ID="GridEmail" runat="server" CssClass="YourGridView" 
                                         AutoGenerateColumns="false"   
                                        onrowdatabound="GridEmail_RowDataBound" >
                            <Columns>                            
                            <asp:TemplateField>
                                
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblStatus"></asp:Label>
                                    <uc1:Comment ID="Comment1" runat="server" />
                                </ItemTemplate>                                
                            </asp:TemplateField>
                            </Columns>
                        <EmptyDataTemplate>
                           No status message is given so far..
                        </EmptyDataTemplate>
                    </asp:GridView>

