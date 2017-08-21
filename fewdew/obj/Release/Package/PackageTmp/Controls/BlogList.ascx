<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BlogList.ascx.cs" Inherits="BDDoctors.Controls.BlogList" %>
                        <%@ Register src="Comment.ascx" tagname="Comment" tagprefix="uc1" %>
                 
                                        <asp:GridView ID="GridEmail" runat="server" 
                                             AutoGenerateColumns="false"   
                                            onrowdatabound="GridEmail_RowDataBound" >
                                            <Columns>                            
                                            <asp:TemplateField>
                                                
                                                <ItemTemplate>
                                                <div >
                                                  <ul >
                                                    <li>
                                                        <asp:HyperLink runat="server" ID="hlinkUserImage" ><img runat="server"   ID="imgUser" /><asp:Label runat="server" ID="lblUserName" Text="User Name" style="vertical-align:top" ></asp:Label>  </asp:HyperLink><asp:Label runat="server" ID="lblDateTime" style="vertical-align:top"></asp:Label><asp:HyperLink runat="server" ID="hlinkReadMore" Text="Details" style="float:right" ></asp:HyperLink> 
                                                    </li>
                                                 <li>   <asp:Label runat="server" ID="lblCategoryValue"></asp:Label></li>
                                                    <li style="color:#2F9A8F;">"<asp:Label runat="server" ID="lblTitleValue"  ></asp:Label>"</li>
                                                    <li style=" color:#2F9A8F;"> <asp:Label runat="server" ID="lblDescriptionValue"></asp:Label> </li>
                                                    <li><img runat="server"  ID="BlogImage" visible=false /></li>
                                                   
                                                   
                                                  
                                                  </ul>
                                                   <uc1:Comment ID="Comment1" runat="server" />
                                                 </div>   
                                                </ItemTemplate>                                
                                            </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                               No blog is posted
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    
                                        
                          