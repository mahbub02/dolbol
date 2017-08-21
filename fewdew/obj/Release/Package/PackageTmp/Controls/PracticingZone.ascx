<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PracticingZone.ascx.cs" Inherits="BDDoctors.Controls.PracticingZone" %>



    <asp:DataList runat="server" ID="dlPracticeZoneList"  CssClass="datalistPractice"
    ShowFooter=true ShowHeader=true onitemcommand="dlPracticeZoneList_ItemCommand" 
    onitemdatabound="dlPracticeZoneList_ItemDataBound">
    <ItemTemplate>
    
            <div class="edit-button_practice">
            <asp:LinkButton runat="server" ID="lbtnEditZoneInfo" style="margin-left:160px" Text="edit"></asp:LinkButton>
            </div>
        <ul>
          <li>
                <asp:Label runat="server" ID="lblZoneAddressAttribute" CssClass="AttributeLabel"    Text="Address"></asp:Label>
                <asp:Label runat="server" ID="lblZoneAddressValue"  ></asp:Label>    
          </li>
           <li>
               <asp:Label runat="server" ID="lblDaysAttribute" CssClass="AttributeLabel"    Text="Days"></asp:Label>
               <asp:Label runat="server" ID="lblDaysValue"  ></asp:Label>
           </li>
           <li>
               <asp:Label runat="server" ID="lblScheduleAttribute" CssClass="AttributeLabel"    Text="Schedule"></asp:Label>
               <asp:Label runat="server" ID="lblScheduleValue" ></asp:Label>
           </li>   
           <li>
               <asp:Label runat="server" ID="lblContactnumberAttribute" CssClass="AttributeLabel"    Text="Contact number"></asp:Label>
               <asp:Label runat="server" ID="lblContactNumberValue" ></asp:Label>
           </li>
        </ul>      
    </ItemTemplate>
    <EditItemTemplate>
     
         <ul>
            <li>
             <asp:Label runat="server" ID="lblMessage" CssClass="ErrorMessage"    ></asp:Label>
            </li>
            <li>
             <asp:Label runat="server" ID="lblZoneAddressAttribute" CssClass="AttributeLabel"    Text="Address"></asp:Label>
             <asp:TextBox runat="server" ID="txtZoneAddress" TextMode="MultiLine" Height="50" Width="300"></asp:TextBox>
           
             </li>
            <li>
               <asp:Label runat="server" ID="lblDaysAttribute" CssClass="AttributeLabel"    Text="Days"></asp:Label>
                <asp:CheckBoxList runat="server" ID="chklistDays" style="margin-left:130px" CssClass="checkbox" ></asp:CheckBoxList>
             </li>
             <li>
                  <asp:Label runat="server" ID="lblScheduleAttribute" CssClass="AttributeLabel"    Text="Schedule"></asp:Label>
                  <asp:DropDownList runat="server" ID="ddlFromValue"></asp:DropDownList>
                  <asp:DropDownList runat="server" ID="ddlToValue"></asp:DropDownList>
             </li>
             <li>
                 <asp:Label runat="server" ID="lblContactnumberAttribute" CssClass="AttributeLabel"    Text="Contact number"></asp:Label>
                 <asp:TextBox runat="server" ID="txtContactNumberValue" ></asp:TextBox>
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
             <asp:Label runat="server" ID="lblZoneAddressAttribute" CssClass="AttributeLabel"    Text="Address"></asp:Label>
             <asp:TextBox runat="server" ID="txtZoneAddress" ></asp:TextBox>
           
             </li>
            <li>
               <asp:Label runat="server" ID="lblDaysAttribute" CssClass="AttributeLabel"    Text="Days"></asp:Label>
                <asp:CheckBoxList runat="server" ID="chklistDays" style="margin-left:130px" CssClass="checkbox" ></asp:CheckBoxList>
             </li>
             <li>
                  <asp:Label runat="server" ID="lblScheduleAttribute" CssClass="AttributeLabel"    Text="Schedule"></asp:Label>
                  <asp:DropDownList runat="server" ID="ddlFromValue"></asp:DropDownList>
                  <asp:DropDownList runat="server" ID="ddlToValue"></asp:DropDownList>
        
             </li>
             <li>
                 <asp:Label runat="server" ID="lblContactNumberAttribute" CssClass="AttributeLabel"    Text="Contact number"></asp:Label>
                 <asp:TextBox runat="server" ID="txtContactNumberValue" ></asp:TextBox>
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
