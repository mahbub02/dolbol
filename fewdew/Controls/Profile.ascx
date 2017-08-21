<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Profile.ascx.cs" Inherits="BDDoctors.Controls.Profile2" %>

    
        <ul>
            
            <li>
                
                 <img runat="server" id="imgProfile"  class="ProfileImage" onerror="this.onerror=null; this.src='~/Images/profile/Default'" /> 
                
            </li>
            <li><asp:FileUpload ID="FileProfileUpload" runat="server" Height="20" Width="20" CssClass="fileUpload"   /></li>
            <li><asp:Button runat="server" ID="btnPhotoUpload" Text="Upload" 
                    onclick="btnPhotoUpload_Click" /></li>
            <li><asp:Label runat="server" ID="lblPhotoInformation"></asp:Label></li>
        </ul>
         
         


    
       <div runat="server" id="dvProfileContainer" class="dvProfileContainer">
       <asp:LinkButton runat="server" ID="lbtnAddAsFriend" Text="Add As Friend" 
               onclick="lbtnAddAsFriend_Click"></asp:LinkButton>
       
            <ul>
                <li>
                    <asp:Label runat="server" ID="lblFullNameAttribute" CssClass="AttributeLabel"  Visible="false"  Text="Full Name"></asp:Label>
                    <asp:Label runat="server" ID="lblFullNameValue" Visible="false" ></asp:Label>
                    <asp:TextBox runat="server" ID="txtFullName" Visible="false"></asp:TextBox>
                </li>
                <li>
                    <asp:Label runat="server" ID="lblGenderAttribute" CssClass="AttributeLabel"   Visible="false"  Text="Gender"></asp:Label>
                    <asp:Label runat="server" ID="lblGenderValue" Visible="false" ></asp:Label>
                     <asp:RadioButtonList runat="server" ID="rdoGender" RepeatLayout="Flow" RepeatDirection="Horizontal" Visible="false">
                        <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    </asp:RadioButtonList>
                </li>
                <li>
                    <asp:Label runat="server" ID="lblCityAttribute" CssClass="AttributeLabel"  Visible="false"   Text="City"></asp:Label>
                    <asp:Label runat="server" ID="lblCityValue" Visible="false" ></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlCity" RepeatLayout="Flow" Visible="false">
                     <asp:ListItem Text="Dhaka" Value="Dhaka" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Chittagong" Value="Chittagong"></asp:ListItem>
                    </asp:DropDownList>
                </li>
                <li>
                    <asp:Label runat="server" ID="lblAddressAttribute" CssClass="AttributeLabel"  Visible="false"   Text="Address"></asp:Label>
                    <asp:Label runat="server" ID="lblAddressValue" Visible="false" ></asp:Label>
                    <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" Visible="false"></asp:TextBox>
                </li>
                 <li>
                    <asp:Label runat="server" ID="lblPassedFromAttribute" CssClass="AttributeLabel"  Visible="false"   Text="Passed From"></asp:Label>
                    <asp:Label runat="server" ID="lblPassedFromValue" Visible="false"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlPassedFrom" RepeatLayout="Flow" Visible="false">
                     <asp:ListItem Text="DMC" Value="DMC" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="SOMC" Value="SOMC"></asp:ListItem>
                    </asp:DropDownList>
                </li>
                <li>
                    <asp:Label runat="server" ID="lblDegreeAttribute" CssClass="AttributeLabel"  Visible="false"  Text="Degrees" ></asp:Label>
                    <asp:Label runat="server" ID="lblDegressValue" Visible="false" ></asp:Label>
                    <asp:TextBox runat="server" ID="txtDegree" Visible="false"></asp:TextBox>
                    <asp:ImageButton runat="server" ID="ImgBtnDegreeHelp" 
                        ImageUrl="~/Images/Help.gif" Visible="false" onclick="ImgBtnDegreeHelp_Click" />
                    
                    <div runat="server" id="dvChkListDegree" class="dvCheckListDegree" Visible="false"   >
                      <asp:CheckBoxList runat="server" ID="ChklistDegree" RepeatLayout="Flow" Height="100"    >
                        <asp:ListItem Text="FCPS"  Value="FCPS"></asp:ListItem>
                        <asp:ListItem Text="FRCS"  Value="FRCS"></asp:ListItem>
                        <asp:ListItem Text="MD"  Value="MD"></asp:ListItem>
                        <asp:ListItem Text="Other"  Value="Other"></asp:ListItem>
                       </asp:CheckBoxList>
                    </div>
                                           
                </li>
            </ul> 
            <asp:Button runat="server" ID="btnSave" Text="Edit/Create/Update" onclick="btnSave_Click" />
       </div> 
  
   