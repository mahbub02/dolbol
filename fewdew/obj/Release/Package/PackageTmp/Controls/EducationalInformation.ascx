<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EducationalInformation.ascx.cs" Inherits="BDDoctors.Controls.EducationalInformation" %>





    <asp:DataList runat="server" ID="dlEduInfoList" 
    ShowFooter=true ShowHeader=true onitemcommand="dlEduInfoList_ItemCommand" 
    onitemdatabound="dlEduInfoList_ItemDataBound">
    <ItemTemplate>
        <div class="edit-button">
        <asp:LinkButton runat="server" ID="lbtnEditEduInfo" Text="edit"></asp:LinkButton>
        </div>
        <ul>
          <li>
                <asp:Label runat="server" ID="lblInstitueNameAttribute" CssClass="AttributeLabel"    Text="Institue Name"></asp:Label>
                <asp:Label runat="server" ID="lblInstituteNameValue"  ></asp:Label>    
          </li>
           <li>
               <asp:Label runat="server" ID="lblClassYearAttribute" CssClass="AttributeLabel"    Text="Passing Year"></asp:Label>
               <asp:Label runat="server" ID="lblClassYearValue"  ></asp:Label>
           </li>   
           <li>
               <asp:Label runat="server" ID="lblDegreeAttribute" CssClass="AttributeLabel"    Text="Degree"></asp:Label>
               <asp:Label runat="server" ID="lblDegreeAttributeValue" ></asp:Label>
           </li>
            <li>
               <asp:Label runat="server" ID="lblDescriptionAttribute" CssClass="AttributeLabel"    Text="Description"></asp:Label>
               <asp:Label runat="server" ID="lblDescriptionValue" ></asp:Label>
           </li>
           
           
        </ul>      
    </ItemTemplate>
    <EditItemTemplate>
     
         <ul>
            <li>
             <asp:Label runat="server" ID="lblMessage" CssClass="ErrorMessage"    ></asp:Label>
            </li>
            <li>
             <asp:Label runat="server" ID="lblInstitueNameAttribute" CssClass="AttributeLabel"    Text="Institue Name"></asp:Label>
             <asp:TextBox runat="server" ID="txtInstituteName" ></asp:TextBox>
             <asp:DropDownList runat="server" ID="ddlYear" ></asp:DropDownList>
             </li>
            <li>
                 <asp:Label runat="server" ID="lblDegreeAttribute" CssClass="AttributeLabel"    Text="Degree"></asp:Label>
                 <asp:TextBox runat="server" ID="txtDegreeValue" ></asp:TextBox>
             </li>
             <li>
                 <asp:Label runat="server" ID="lblDescriptionAttribute" CssClass="AttributeLabel"    Text="Description"></asp:Label>
                 <asp:TextBox runat="server" ID="txtDescriptionValue" TextMode="MultiLine" Height="50" Width="300" ></asp:TextBox>
             </li>
             <li>
                <asp:Button runat="server" ID="btnUpdateEduInfo" Text="Update"  CommandName="update" />
                <asp:Button runat="server" ID="btnCancel" Text="Cancel"  CommandName="cancel" />
                <asp:Button runat="server" ID="btnDelete" Text="Delete"  CommandName="delete" />
             </li>
             <asp:TextBox ID="txtParent_id" runat="server" Visible="false" ></asp:TextBox>
             
        </ul>
    </EditItemTemplate>
    <FooterTemplate>
    
    <div runat="server" id="dvFooterContent" visible="false">
        <ul>
            <li>
             <asp:Label runat="server" ID="lblMessage" CssClass="ErrorMessage"    ></asp:Label>
            </li>
            <li>
             <asp:Label runat="server" ID="lblInstitueNameAttribute" CssClass="AttributeLabel"    Text="Institue Name"></asp:Label>
             <asp:TextBox runat="server" ID="txtInstituteName" ></asp:TextBox>
             <asp:DropDownList runat="server" ID="ddlYear" ></asp:DropDownList>
             </li>
            <li>
                 <asp:Label runat="server" ID="lblDegreeAttribute" CssClass="AttributeLabel"    Text="Degree"></asp:Label>
                 <asp:TextBox runat="server" ID="txtDegreeValue" ></asp:TextBox>
             </li>
             <li>
                 <asp:Label runat="server" ID="lblDescriptionAttribute" CssClass="AttributeLabel"    Text="Description"></asp:Label>
                 <asp:TextBox runat="server" ID="txtDescriptionValue" ></asp:TextBox>
             </li>
             <li>
                <asp:Button runat="server" ID="btnAdd" Text="Add" CssClass="btnAddEduInfo" CommandName="save"    />
                 <asp:Button runat="server" ID="btnCancel" Text="Cancel"  CommandName="cancel" />
             </li> 
        </ul>
        
     </div>
     <div class="edit-button">
     <asp:LinkButton runat="server" ID="lbtnAddMoreInfo" Text="add" CommandName="addMore" ></asp:LinkButton>   
     </div>
    </FooterTemplate>
    </asp:DataList>
