<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasicInfo.ascx.cs" Inherits="BDDoctors.Controls.BasicInfo" %>

    <asp:DataList runat="server" ID="dlBasicInfo" 
    ShowFooter=true ShowHeader=true onitemcommand="dlEduInfoList_ItemCommand" 
    onitemdatabound="dlEduInfoList_ItemDataBound">
    <ItemTemplate>
            <div class="edit-button">
                <asp:LinkButton runat="server" ID="lbtnBasicEdit" Text="edit"></asp:LinkButton>
            </div>
        <ul>
          
          <li>
                <asp:Label runat="server" ID="lblFullNameAttribute" CssClass="AttributeLabel"    Text="Full Name:"></asp:Label>
                <asp:Label runat="server" ID="lblFullNameValue"  ></asp:Label>    
          </li>
           <li>
               <asp:Label runat="server" ID="lblSexAttribute" CssClass="AttributeLabel"    Text="Sex:"></asp:Label>
               <asp:Label runat="server" ID="lblSexValue"  ></asp:Label>
           </li>   
           <li>
               <asp:Label runat="server" ID="lblDateOfBirthAttribute" CssClass="AttributeLabel"    Text="Birth Year &Month:"></asp:Label>
               <asp:Label runat="server" ID="lblDateOfBirthValue" ></asp:Label>
           </li>
            <li>
               <asp:Label runat="server" ID="lblRelationShipStatusAttribute" CssClass="AttributeLabel"    Text="Relationship status:"></asp:Label>
               <asp:Label runat="server" ID="lblRelationShipStatusValue" ></asp:Label>
           </li>
           <li>
               <asp:Label runat="server" ID="lblInterestedInAttribute" CssClass="AttributeLabel"    Text="Interested In:"></asp:Label>
               <asp:Label runat="server" ID="lblInterestedInValue" ></asp:Label>
           </li>
           <li>
               <asp:Label runat="server" ID="lblHomeTownAttribute" CssClass="AttributeLabel"    Text="Hometown:"></asp:Label>
               <asp:Label runat="server" ID="lblHomeTownValue" ></asp:Label>
           </li>
           <li>
               <asp:Label runat="server" ID="lblContactnumberAttribute" CssClass="AttributeLabel"    Text="Contact Number:"></asp:Label>
               <asp:Label runat="server" ID="lblContactNumberValue" ></asp:Label>
           </li>
           <li>
               <asp:Label runat="server" ID="lblContactEmailAttribute" CssClass="AttributeLabel"    Text="Contact Email:"></asp:Label>
               <asp:Label runat="server" ID="lblContactEmailValue" ></asp:Label>
           </li>
           <li>
               <asp:Label runat="server" ID="lblSpecialityAttribute" CssClass="AttributeLabel"    Text="Specialist:"></asp:Label>
               <asp:Label runat="server" ID="lblSpecialistValue" ></asp:Label>
           </li>
           
           
        </ul>      
    </ItemTemplate>
    <EditItemTemplate>
     
         <ul>
            <li>
             <asp:Label runat="server" ID="lblMessage" CssClass="ErrorMessage"    ></asp:Label>
            </li>
            <li>
             <asp:Label runat="server" ID="lblFullNameAttribute" CssClass="AttributeLabel"    Text="Full Name"></asp:Label>
             <asp:TextBox runat="server" ID="txtFullName" MaxLength="50" ></asp:TextBox>
             
             </li>
            <li>
                 <asp:Label runat="server" ID="lblSexAttribute" CssClass="AttributeLabel"    Text="Sex"></asp:Label>
                 <asp:DropDownList runat="server" ID="ddlSex" ></asp:DropDownList>
             </li>
             <li>
                 <asp:Label runat="server" ID="lblDateOfBirthAttribute" CssClass="AttributeLabel"    Text="Birth Year & Month"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlFromYear" ></asp:DropDownList>
                <asp:DropDownList runat="server" ID="ddlMonth" ></asp:DropDownList>
             </li>
             <li>
                 <asp:Label runat="server" ID="lblRelationShipStatusAttribute" CssClass="AttributeLabel"    Text="Relationship status"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlRelationShip" ></asp:DropDownList>
               
             </li>
             <li >
                 <asp:Label runat="server" ID="lblInterestedInAttribute" CssClass="AttributeLabel"    Text="Interested In "></asp:Label>
                <asp:CheckBoxList runat="server" CssClass="checkbox" style="margin-left:120px; " ID="chkListInterestedIn" ></asp:CheckBoxList>
             </li>
             <li >
                 
               <asp:Label runat="server" ID="lblHomeTownAttribute" CssClass="AttributeLabel"    Text="Home Town"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlHomeTown" ></asp:DropDownList>
             </li>
             <li>
                 <asp:Label runat="server" ID="lblContactNumberAttribute" CssClass="AttributeLabel"    Text="Contact Number"></asp:Label>
                 <asp:TextBox runat="server" ID="txtContactNumber" MaxLength="50" ></asp:TextBox>
             </li>
             <li>
                 <asp:Label runat="server" ID="lblContactEmailAttribute" CssClass="AttributeLabel"    Text="Contact Email"></asp:Label>
                 <asp:TextBox runat="server" ID="txtContactEmail" MaxLength="50" ></asp:TextBox>
             </li>
             <li>
                 <asp:Label runat="server" ID="lblSpecialListAttribute" CssClass="AttributeLabel"    Text="Specialist"></asp:Label>
                 <asp:TextBox runat="server" ID="txtSpecialist" MaxLength="100" ></asp:TextBox>
             </li>
             <li>
                <asp:Button runat="server" ID="btnUpdateEduInfo" Text="Update"  CommandName="update" />
                <asp:Button runat="server" ID="btnCancel" Text="Cancel"  CommandName="cancel" />
             
             </li>
             <asp:TextBox ID="txt_Parent_id" runat="server" Visible="false" ></asp:TextBox>
             
        </ul>
        </EditItemTemplate>
</asp:DataList>
