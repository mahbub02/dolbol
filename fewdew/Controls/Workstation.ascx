<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Workstation.ascx.cs" Inherits="BDDoctors.Controls.Workstation" %>


    <asp:DataList runat="server" ID="dlWorkInfoList" 
    ShowFooter=true ShowHeader=true onitemcommand="dlWorkInfoList_ItemCommand" 
    onitemdatabound="dlWorkInfoList_ItemDataBound">
    <ItemTemplate>
            <div class="edit-button">
                <asp:LinkButton runat="server" ID="lbtnEditWorkInfo" Text="edit"></asp:LinkButton>
            </div>
        <ul>
             
            <li>
               <asp:Label runat="server" ID="lblWorkNatureAttribute" CssClass="AttributeLabel"    Text="Work Nature"></asp:Label>
               <asp:Label runat="server" ID="lblWorkNatureValue"  ></asp:Label>
           </li>  
           
          <li>
                <asp:Label runat="server" ID="lblWhereAttribute" CssClass="AttributeLabel"    Text="Where"></asp:Label>
                <asp:Label runat="server" ID="lblWhereValue"  ></asp:Label>    
          </li>
            
           <li>
               <asp:Label runat="server" ID="lblFromAttribute" CssClass="AttributeLabel"    Text="From"></asp:Label>
               <asp:Label runat="server" ID="lblFromValue" ></asp:Label>
           </li>
            <li>
               <asp:Label runat="server" ID="lblMyRoleAttribute" CssClass="AttributeLabel"    Text="My role"></asp:Label>
               <asp:Label runat="server" ID="lblMyRoleValue" ></asp:Label>
           </li>
           <li>
               <asp:Label runat="server" ID="lblReferanceAttribute" CssClass="AttributeLabel"    Text="Reference"></asp:Label>
               <asp:Label runat="server" ID="lblReferanceValue" ></asp:Label>
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
               <asp:Label runat="server" ID="lblWorkNatureAttribute" CssClass="AttributeLabel"    Text="Work Nature"></asp:Label>
               <asp:DropDownList runat="server" ID="ddlWorkNature" ></asp:DropDownList>
             </li>
            <li>
                  <asp:Label runat="server" ID="lblWhereAttribute" CssClass="AttributeLabel"    Text="Where"></asp:Label>
                 <asp:TextBox runat="server" ID="txtWhere" TextMode="MultiLine" Height="50" Width="300" ></asp:TextBox>
             </li>
             <li>
               <asp:Label runat="server" ID="lblFromAttribute" CssClass="AttributeLabel"    Text="From"></asp:Label>
               <asp:DropDownList runat="server" ID="ddlFromYear" ></asp:DropDownList>
               <asp:DropDownList runat="server" ID="ddlFromMonth" ></asp:DropDownList>
                To
               <asp:DropDownList runat="server" ID="ddlToMonth" Visible="true" ></asp:DropDownList>
               <asp:DropDownList runat="server" ID="ddlToYear" Visible="true" ></asp:DropDownList>
             </li>
            
             <li>
                  <asp:Label runat="server" ID="lblMyRoleAttribute" CssClass="AttributeLabel"    Text="My role"></asp:Label>
                 <asp:TextBox runat="server" ID="txtMyRole" Width="300" ></asp:TextBox>
             </li>
              <li>
                  <asp:Label runat="server" ID="lblReferenceAttribute" CssClass="AttributeLabel"    Text="Reference"></asp:Label>
                 <asp:TextBox runat="server" ID="txtReference" Height="50" Width="300" TextMode="MultiLine" ></asp:TextBox>
             </li>
             <li>
                  <asp:Label runat="server" ID="lblDescriptionAttribute" CssClass="AttributeLabel"    Text="Description"></asp:Label>
                 <asp:TextBox runat="server" ID="txtDescription" Height="50" Width="300" TextMode="MultiLine" ></asp:TextBox>
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
               <asp:Label runat="server" ID="lblWorkNatureAttribute" CssClass="AttributeLabel"    Text="Work Nature"></asp:Label>
               <asp:DropDownList runat="server" ID="ddlWorkNature" ></asp:DropDownList>
             </li>
            <li>
                  <asp:Label runat="server" ID="lblWhereAttribute" CssClass="AttributeLabel"    Text="Where"></asp:Label>
                 <asp:TextBox runat="server" ID="txtWhere" ></asp:TextBox>
             </li>
             <li>
               <asp:Label runat="server" ID="lblFromAttribute" CssClass="AttributeLabel"    Text="From"></asp:Label>
               <asp:DropDownList runat="server" ID="ddlFromMonth" ></asp:DropDownList>
               <asp:DropDownList runat="server" ID="ddlFromYear" ></asp:DropDownList>
               To
               <asp:DropDownList runat="server" ID="ddlToMonth" Visible="true" ></asp:DropDownList>
               <asp:DropDownList runat="server" ID="ddlToYear" Visible="true" ></asp:DropDownList>
             </li>
             
             <li>
                  <asp:Label runat="server" ID="lblMyRoleAttribute" CssClass="AttributeLabel"    Text="My role"></asp:Label>
                 <asp:TextBox runat="server" ID="txtMyRole" ></asp:TextBox>
             </li>
              <li>
                  <asp:Label runat="server" ID="lblReferenceAttribute" CssClass="AttributeLabel"    Text="Reference"></asp:Label>
                 <asp:TextBox runat="server" ID="txtReference" ></asp:TextBox>
             </li>
             <li>
                  <asp:Label runat="server" ID="lblDescriptionAttribute" CssClass="AttributeLabel"    Text="Description"></asp:Label>
                 <asp:TextBox runat="server" ID="txtDescription" Height="50" Width="300" TextMode="MultiLine" ></asp:TextBox>
             </li>
             <li>
                <asp:Button runat="server" ID="btnAdd" Text="Add" CssClass="btnAddEduInfo"  CommandName="save"   />
                 <asp:Button runat="server" ID="btnCancel" Text="Cancel"  CommandName="cancel" />
             </li> 
        </ul>
        
     </div>
     <div class="edit-button">
     <asp:LinkButton runat="server" ID="lbtnAddMoreInfo" Text="add" CommandName="addMore" ></asp:LinkButton>   
     </div>
    </FooterTemplate>
    </asp:DataList>
