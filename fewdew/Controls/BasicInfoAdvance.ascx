<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasicInfoAdvance.ascx.cs" Inherits="BDDoctors.Controls.BasicInfoAdvance" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="Conditional">
<ContentTemplate>aa
<ul>
    <asp:TextBox ID="txt_Parent_id" Visible="false" runat="server"></asp:TextBox>
    <asp:DataList runat="server" ID="dlBasicInfo" 
    ShowFooter=true ShowHeader=true onitemcommand="dlEduInfoList_ItemCommand" 
    onitemdatabound="dlEduInfoList_ItemDataBound">
    <ItemTemplate>
        <li>
                 <asp:Label runat="server" ID="lblAttribute" CssClass="AttributeLabel"    Text="Full Name"></asp:Label>
                <asp:Label runat="server" ID="lblValue"  ></asp:Label> 
                <asp:LinkButton runat="server" ID="lbtnedit" Text="edit"></asp:LinkButton>  
        </li>       
    </ItemTemplate>
    <EditItemTemplate>
                 <asp:Label runat="server" ID="lblAttribute" CssClass="AttributeLabel"    Text="Full Name"></asp:Label>
                  <div runat="server" id="dvEditControls" style="display:inline">
                    <asp:LinkButton runat="server" ID="lbtnedit" Text="edit"></asp:LinkButton>  
                  </div>  
                
    </EditItemTemplate>
    </asp:DataList>
</ContentTemplate>
</asp:UpdatePanel>  
</ul>