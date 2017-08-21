<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadedPhoto.ascx.cs" Inherits="BDDoctors.Controls.UploadedPhoto" %>

                               <asp:LinkButton runat="server" ID="lbtnCreateNewPhotoAlbum" 
                                       Text="Create New Photo Album" onclick="lbtnCreateNewPhotoAlbum_Click" CssClass="post-new" ></asp:LinkButton>
                                        <asp:Label runat="server" ID="lblSuccessMessage"   ></asp:Label>
                                       <div runat="server" id="divCreateNewAlbum" class="blog-transparent" visible=false  >
                                             <asp:LinkButton runat="server" ID="lbtnClose" Text="X" CssClass="imgClose" onclick="lbtnClose_Click" 
                                                                    />
                                            <asp:Label runat="server" ID="lblValidationMessageForAlbum"   ></asp:Label>
                                            <ul runat="server" id="ul1">                                                 
                                                 <li><asp:Label runat="server" ID="Label5" Text="Album Name" CssClass="AttributeLabel2" ></asp:Label><asp:TextBox runat="server" ID="txtTitle"  TextMode="MultiLine" Width="200"  Height="30"  ></asp:TextBox></li>
                                                 <li><asp:Label runat="server" ID="lblPhotoInformation" Text="" CssClass="AttributeLabel2" ></asp:Label>
                                                 <asp:Button runat="Server" ID="btnPost" Text="Create Album" onclick="btnPost_Click"    />
                                                 <asp:Button runat="server" ID="btnClose" Text="Cancel" onclick="btnClose_Click" 
                                                           /></li>
                                             </ul>               
                                       </div>
                                       
                                        <asp:GridView ID="GridViewAlbums"  runat="server" CssClass="YourGridView" 
                                             AutoGenerateColumns="false"   
                                            onrowdatabound="GridViewAlbumbs_RowDataBound" >
                                            <Columns>                            
                                            <asp:TemplateField>
                                                
                                                <ItemTemplate>
                                                
                                                <a runat="server" id="hlinkAlbum" >
                                                
                                                <ul class="album" >
                                                <li><img runat="server" id="ImgAlbum"  Width="100"  src="~/Images/profile/Default"  /></li>
                                                <li><asp:Label runat="server" ID="lblTitleValue" CssClass="album"  ></asp:Label></li>
                                                </ul>
                                                </a>
                                                  
                                                </ItemTemplate>                                
                                            </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                               No Album is Created
                                            </EmptyDataTemplate>
                                        </asp:GridView>
