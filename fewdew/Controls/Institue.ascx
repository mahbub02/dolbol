<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Institue.ascx.cs" Inherits="BDDoctors.Controls.Institue" %>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode="Conditional">
    <ContentTemplate>
    <ul>
                <li><asp:ImageButton runat="server" ID="imgBtnRemove" ImageUrl="~/Images/Help.gif" 
                        onclick="imgBtnRemove_Click" />  </li>
                <li>
                    <asp:Label runat="server" ID="lblInstitueNameAttribute" CssClass="AttributeLabel"  Visible="true"  Text="Institue Name"></asp:Label>
                    <asp:Label runat="server" ID="lblInstituteNameValue" Visible="true" ></asp:Label>
                    <asp:TextBox runat="server" ID="txtInstituteName" Visible="true"></asp:TextBox>
                    <asp:DropDownList runat="server" ID="ddlYear" ></asp:DropDownList>
                </li>
                <li>
                    <asp:Label runat="server" ID="lblDegreeNameAttribute" CssClass="AttributeLabel"   Visible="true"  Text="Degree"></asp:Label>
                    <asp:Label runat="server" ID="lblDegreeNameValue" Visible="true" ></asp:Label>
                    <asp:TextBox runat="server" ID="txtDegreeName" Visible="true"></asp:TextBox>
                </li>
       
    </ul>
    </ContentTemplate>
  </asp:UpdatePanel> 