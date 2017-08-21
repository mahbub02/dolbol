using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace BDDoctors.Controls
{
    public partial class EducationalInformation : System.Web.UI.UserControl
    {
        private bool m_I_the_Owner = false;

        private void AmIThePageOwner()
        {
            if (LoginHandler.IsLoggedIn && PageOwner() == LoginHandler.LoggedInUser().Id)
            {
                m_I_the_Owner = true;
            }
            else 
            {
                m_I_the_Owner = false; 
            }
        }
        private Int64 PageOwner()
        {
            Int64 user_id = 0;
            if (Request["user"] != null)
            {
                user_id = Convert.ToInt64(Request["user"]);
            }
            if (user_id == 0)
            {
                user_id = Convert.ToInt64(LoginHandler.LoggedInUser().Id);
            }
            return user_id;
        }

        private void BindDataList()
        {
            System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOnly(9, PageOwner());
            dlEduInfoList.DataSource = ListNodes;
            dlEduInfoList.DataBind();
          
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AmIThePageOwner();
            if (Page.IsPostBack == false)
            {
                BindDataList();
            }
        }
       
        protected void dlEduInfoList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Footer:
                    DropDownList dl = (DropDownList)(e.Item.FindControl("ddlYear"));
                    Button btnAdd = (Button)(e.Item.FindControl("btnAdd"));
                   LinkButton lbtnAddMoreInfo=(LinkButton)(e.Item.FindControl("lbtnAddMoreInfo"));
                   btnAdd.Visible = m_I_the_Owner;
                   lbtnAddMoreInfo.Visible=m_I_the_Owner;

                    if (dl != null)
                    {
                        UIhelper.PopulateDropDownClassYear(dl, null);
                    }
                    break;
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    System.Collections.Generic.List<DAL.DataObject.Node> nodes =(System.Collections.Generic.List<DAL.DataObject.Node> )e.Item.DataItem;
                    Label lblInstituteNameValue = (Label)e.Item.FindControl("lblInstituteNameValue");
                    Label lblClassYearValue = (Label)e.Item.FindControl("lblClassYearValue");
                    Label lblDegreeAttributeValue = (Label)e.Item.FindControl("lblDegreeAttributeValue");
                    Label lblDescriptionValue = (Label)e.Item.FindControl("lblDescriptionValue");
                    LinkButton lbtnEditEduInfo = (LinkButton)(e.Item.FindControl("lbtnEditEduInfo"));
                    lbtnEditEduInfo.Visible = m_I_the_Owner;
                    
                    foreach( DAL.DataObject.Node nd in nodes)
                    {
                        switch (nd.Attribute_id )
                        { 
                            case 9:
                                lblInstituteNameValue.Text = DAL.Common.ToString(nd.Node_value);
                            break;
                            case 10:
                            lblClassYearValue.Text = DAL.Common.ToString(nd.Node_value);
                            break;
                            case 11:
                            lblDegreeAttributeValue.Text = DAL.Common.ToString(nd.Node_value);
                            break;
                            case 12:
                            lblDescriptionValue.Text =DAL.Common.ToString( nd.Node_value);
                            break;
                        }
                    }
                    break;
                case ListItemType.EditItem:
                    TextBox txtInstituteName = (TextBox)e.Item.FindControl("txtInstituteName");
                    DropDownList ddlyear = (DropDownList)e.Item.FindControl("ddlYear");
                    TextBox txtDegreeValue = (TextBox)e.Item.FindControl("txtDegreeValue");
                    TextBox txtDescriptionValue = (TextBox)e.Item.FindControl("txtDescriptionValue");
                    Label lblMessage = (Label)e.Item.FindControl("lblMessage");
                    TextBox txtParent_id = (TextBox)e.Item.FindControl("txtParent_id");
                    DropDownList ddlYear = (DropDownList)(e.Item.FindControl("ddlYear"));
                    
                    
                    System.Collections.Generic.List<DAL.DataObject.Node> nodeList = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Item.DataItem;
                    System.Collections.Generic.IEnumerable<Nullable<Int64>> Parent_Ids = from DAL.DataObject.Node nd in nodeList
                                                                                         where (nd.Parent_Node_Id != null)
                                                                                         select nd.Parent_Node_Id;
                    Nullable<Int64> Parent_id = null;
                    if (Parent_Ids != null)
                    {
                        Parent_id = Parent_Ids.Max();
                    }
                    txtParent_id.Text= Parent_id.ToString();



                    if (ddlYear != null)
                    {
                        UIhelper.PopulateDropDownClassYear(ddlYear, null);
                    }
                    foreach (DAL.DataObject.Node nd in nodeList)
                    {
                        switch (nd.Attribute_id)
                        {
                            case 9:
                                txtInstituteName.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 10:
                                ddlYear.SelectedValue = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 11:
                                txtDegreeValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 12:
                                txtDescriptionValue.Text =DAL.Common.RemoveBrFromText( DAL.Common.ToString(nd.Node_value));
                                break;
                        }
                    }
                    break;
            }
            
        }
      
        protected void dlEduInfoList_ItemCommand(object source, DataListCommandEventArgs e)
        {

            switch (e.Item.ItemType)
            { 
                case ListItemType.Footer:
                    if (e.CommandName == "addMore")
                    {
                        HtmlGenericControl dv = (HtmlGenericControl)e.Item.FindControl("dvFooterContent");
                        dv.Visible = true;
                        LinkButton lbtn = (LinkButton)e.Item.FindControl("lbtnAddMoreInfo");
                        lbtn.Visible = false;
                       
                    }
                    else if (e.CommandName == "save")
                    {
                        TextBox txtInstituteName = (TextBox)e.Item.FindControl("txtInstituteName");
                        DropDownList ddlyear = (DropDownList)e.Item.FindControl("ddlYear");
                        TextBox txtDegreeValue = (TextBox)e.Item.FindControl("txtDegreeValue");
                        TextBox txtDescriptionValue = (TextBox)e.Item.FindControl("txtDescriptionValue");
                        Label lblMessage = (Label)e.Item.FindControl("lblMessage");
                        string message = "Please Enter";
                        Boolean IsValidate = true;
                        if (txtInstituteName.Text.Trim().Length < 1)
                        {
                            message += " (Institute name) ";
                            IsValidate = false;
                        }
                        if (ddlyear.SelectedItem.Value == "-1")
                        {
                            message += " (Passing Year) ";
                            IsValidate = false;
                        }
                        if (txtDegreeValue.Text.Trim().Length < 1)
                        {
                            message += " (Degree name) ";
                            IsValidate = false;
                        }
                        if (IsValidate == false)
                        {
                            lblMessage.Text = message;
                            return;
                        }
                        else
                        {
                            lblMessage.Text = "";
                        }
                        DAL.DataObject.Node nd;
                        System.Collections.Generic.List<DAL.DataObject.Node> nodeList = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 9;
                        nd.Node_value = txtInstituteName.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 10;
                        nd.Node_value = ddlyear.SelectedValue;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 11;
                        nd.Node_value = txtDegreeValue.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 12;
                        nd.Node_value = txtDescriptionValue.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nodeList.Add(nd);


                        DAL.DataAccess.Node.SaveNodes(nodeList);

                        BindDataList();
                    }
                    else 
                    {
                        HtmlGenericControl dv = (HtmlGenericControl)e.Item.FindControl("dvFooterContent");
                        dv.Visible = false;
                        LinkButton lbtn = (LinkButton)e.Item.FindControl("lbtnAddMoreInfo");
                        lbtn.Visible = true;
                    }
                    break;
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    dlEduInfoList.EditItemIndex = e.Item.ItemIndex;
                    BindDataList();
                    break;
                case ListItemType.EditItem:
                    if (e.CommandName == "update")
                    {

                        TextBox txtInstituteNameForUpdate = (TextBox)e.Item.FindControl("txtInstituteName");
                        DropDownList ddlyearForUpdate = (DropDownList)e.Item.FindControl("ddlYear");
                        TextBox txtDegreeValueForUpdate = (TextBox)e.Item.FindControl("txtDegreeValue");
                        TextBox txtDescriptionValueForUpdate = (TextBox)e.Item.FindControl("txtDescriptionValue");
                        Label lblMessageForUpdate = (Label)e.Item.FindControl("lblMessage");
                        TextBox txtParent_idForUpdate = (TextBox)e.Item.FindControl("txtParent_id");
                        string messageForUpdate = "Please Enter";
                        Boolean IsValidateForUpdate = true;
                        if (txtInstituteNameForUpdate.Text.Trim().Length < 1)
                        {
                            messageForUpdate += " (Institute name) ";
                            IsValidateForUpdate = false;
                        }
                        if (ddlyearForUpdate.SelectedItem.Value == "-1")
                        {
                            messageForUpdate += " (Passing Year) ";
                            IsValidateForUpdate = false;
                        }
                        if (txtDegreeValueForUpdate.Text.Trim().Length < 1)
                        {
                            messageForUpdate += " (Degree name) ";
                            IsValidateForUpdate = false;
                        }
                        if (IsValidateForUpdate == false)
                        {
                            lblMessageForUpdate.Text = messageForUpdate;
                            return;
                        }
                        else
                        {
                            lblMessageForUpdate.Text = "";
                        }

                        Int64 parent_id = Convert.ToInt64(txtParent_idForUpdate.Text);
                        DAL.DataAccess.Node.UpdateNodes(parent_id, 9, txtInstituteNameForUpdate.Text);
                        DAL.DataAccess.Node.UpdateNodes(parent_id, 10, ddlyearForUpdate.SelectedValue);
                        DAL.DataAccess.Node.UpdateNodes(parent_id, 11, txtDegreeValueForUpdate.Text);
                        DAL.DataAccess.Node.UpdateNodes(parent_id, 12, txtDescriptionValueForUpdate.Text);
                        dlEduInfoList.EditItemIndex = -1;
                        BindDataList();
                    }
                    else if (e.CommandName == "delete")
                    {
                        TextBox txtParent_idForDelete = (TextBox)e.Item.FindControl("txtParent_id");
                        Int64 parent_id = Convert.ToInt64(txtParent_idForDelete.Text);
                        DAL.DataAccess.Node.DeleteNodes(parent_id);
                        dlEduInfoList.EditItemIndex = -1;
                        BindDataList();
                    }
                    else if(e.CommandName=="cancel") 
                    {
                        dlEduInfoList.EditItemIndex = -1;
                        BindDataList();
                    }
                    break;


            }
            
        }
    }
}