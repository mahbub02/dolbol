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
    public partial class BasicInfo : System.Web.UI.UserControl
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
            System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOrAttribute(20, PageOwner());
            dlBasicInfo.DataSource = ListNodes;
            dlBasicInfo.DataBind();

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
            System.Collections.Generic.List<DAL.DataObject.Node> nodes = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Item.DataItem;
                  
            switch (e.Item.ItemType)
            {

                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                     Label lblFullNameValue = (Label)e.Item.FindControl("lblFullNameValue");
                    Label lblSexValue = (Label)e.Item.FindControl("lblSexValue");
                    Label lblDateOfBirthValue = (Label)e.Item.FindControl("lblDateOfBirthValue");
                    Label lblRelationShipStatusValue = (Label)e.Item.FindControl("lblRelationShipStatusValue");
                    Label lblInterestedInValue = (Label)e.Item.FindControl("lblInterestedInValue");
                    Label lblHomeTownValue = (Label)e.Item.FindControl("lblHomeTownValue");
                    Label lblContactNumberValue = (Label)e.Item.FindControl("lblContactNumberValue");
                    Label lblContactEmailValue = (Label)e.Item.FindControl("lblContactEmailValue");
                    Label lblSpecialistValue = (Label)e.Item.FindControl("lblSpecialistValue");


                    LinkButton lbtnBasicEdit = (LinkButton)(e.Item.FindControl("lbtnBasicEdit"));
                    lbtnBasicEdit.Visible = m_I_the_Owner;


                    foreach (DAL.DataObject.Node nd in nodes)
                    {
                        switch (nd.Attribute_id)
                        {
                            case 20:
                                lblFullNameValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 21:
                                lblSexValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 22:
                                lblDateOfBirthValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 23:
                                lblRelationShipStatusValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 24:
                                lblInterestedInValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 25:
                                lblHomeTownValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 26:
                                lblContactNumberValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 27:
                                lblContactEmailValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 28:
                                lblSpecialistValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            
                        }


                    }
                    break;
                case ListItemType.EditItem:
                    TextBox txtFullName = (TextBox)e.Item.FindControl("txtFullName");
                    DropDownList ddlSex = (DropDownList)e.Item.FindControl("ddlSex");
                    DropDownList ddlFromYear = (DropDownList)e.Item.FindControl("ddlFromYear");
                    DropDownList ddlMonth = (DropDownList)e.Item.FindControl("ddlMonth");
                    DropDownList ddlRelationShip = (DropDownList)e.Item.FindControl("ddlRelationShip");
                    CheckBoxList chkListInterestedIn = (CheckBoxList)e.Item.FindControl("chkListInterestedIn");
                    DropDownList ddlHomeTown = (DropDownList)e.Item.FindControl("ddlHomeTown");
                    TextBox txtContactNumber = (TextBox)e.Item.FindControl("txtContactNumber");
                    TextBox txtContactEmail = (TextBox)e.Item.FindControl("txtContactEmail");
                    TextBox txtSpecialist = (TextBox)e.Item.FindControl("txtSpecialist");
                    TextBox txt_Parent_id = (TextBox)e.Item.FindControl("txt_Parent_id");
                    System.Collections.Generic.List<DAL.DataObject.Node> nodeList = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Item.DataItem;
                    System.Collections.Generic.IEnumerable<Nullable<Int64>> Parent_Ids = from DAL.DataObject.Node nd in nodeList
                                                                                         where (nd.Parent_Node_Id != null)
                                                                                         select nd.Parent_Node_Id;
                    Nullable<Int64> Parent_id = null;
                    if (Parent_Ids != null)
                    {
                        Parent_id = Parent_Ids.Max();
                    }
                    txt_Parent_id.Text = Parent_id.ToString();

                    UIhelper.PopulateDropDownYear(ddlFromYear, null);
                    UIhelper.populateMonth(ddlMonth, null);
                    UIhelper.PopulateCheckList(chkListInterestedIn, 15, null);
                    UIhelper.PopulateDropDown(ddlRelationShip, 17, null);
                    UIhelper.PopulateDropDown(ddlHomeTown, 23, null);
                    UIhelper.PopulateDropDown(ddlSex, 1, null);    
                    foreach (DAL.DataObject.Node nd in nodeList)
                    {
                        switch (nd.Attribute_id)
                        {
                            case 20:
                                txtFullName.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 21:
                                ddlSex.SelectedValue = DAL.Common.ToString(nd.Node_value);
                                break;
                                
                            case 22:

                                string[] str = (DAL.Common.ToString(nd.Node_value)).Split(',');
                                if (str.Length>0 &&str[0] != null && str[0] != "-1")
                                {
                                    ddlFromYear.SelectedValue = str[0].ToString();
                                }
                                if (str.Length>1 && str[1] != null && str[1] != "-1")
                                {
                                    ddlMonth.SelectedValue = str[1].ToString();
                                }
                                
                               
                                break;
                           
                            case 23:
                                ddlRelationShip.SelectedValue = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 24:
                                UIhelper.PopulateCheckList(chkListInterestedIn, 15, nd.Node_value);
                                break;
                            case 25:
                                ddlHomeTown.SelectedValue = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 26:
                                txtContactNumber.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 27:
                                txtContactEmail.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 28:
                                txtSpecialist.Text = DAL.Common.ToString(nd.Node_value);
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
                case ListItemType.Item:
                    dlBasicInfo.EditItemIndex = e.Item.ItemIndex;
                    BindDataList();
                    break;
                case ListItemType.EditItem:
                    if (e.CommandName == "update")
                    {
                        TextBox txtFullName = (TextBox)e.Item.FindControl("txtFullName");
                        DropDownList ddlSex = (DropDownList)e.Item.FindControl("ddlSex");
                        DropDownList ddlFromYear = (DropDownList)e.Item.FindControl("ddlFromYear");
                        DropDownList ddlMonth = (DropDownList)e.Item.FindControl("ddlMonth");
                        DropDownList ddlRelationShip = (DropDownList)e.Item.FindControl("ddlRelationShip");
                        CheckBoxList chkListInterestedIn = (CheckBoxList)e.Item.FindControl("chkListInterestedIn");
                        DropDownList ddlHomeTown = (DropDownList)e.Item.FindControl("ddlHomeTown");
                        TextBox txtContactNumber = (TextBox)e.Item.FindControl("txtContactNumber");
                        TextBox txtContactEmail = (TextBox)e.Item.FindControl("txtContactEmail");
                        TextBox txtSpecialist = (TextBox)e.Item.FindControl("txtSpecialist");
                        TextBox txt_Parent_id = (TextBox)e.Item.FindControl("txt_Parent_id");

                        Label lblMessage = (Label)e.Item.FindControl("lblMessage");

                        string message = "Please Enter";
                        Boolean IsValidate = true;

                        System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOrAttribute(20, PageOwner());

                        foreach (System.Collections.Generic.List<DAL.DataObject.Node> nodes in ListNodes)
                        {
                          
                            foreach (DAL.DataObject.Node nd in nodes)
                            {
                                if (txt_Parent_id.Text.Length == 0)
                                {
                                    nd.Parent_Node_Id = null;
                                }
                                else {
                                    nd.Parent_Node_Id = Convert.ToInt64(txt_Parent_id.Text);
                                }
                                nd.User_id = LoginHandler.LoggedInUser().Id.Value;
                                nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                                nd.Node_value = null;
                                switch (nd.Attribute_id)
                                {
                                    case 20:
                                       nd.Node_value= txtFullName.Text;
                                        break;
                                    case 21:
                                        if (ddlSex.SelectedValue != "-1")
                                        {
                                            nd.Node_value = ddlSex.SelectedValue;
                                        }
                                       // else { nd.Node_value = null; }
                                        break;
                                    case 22:
                                        if (ddlFromYear.SelectedValue != "-1" && ddlMonth.SelectedValue != "-1")
                                        {
                                            nd.Node_value = ddlFromYear.SelectedValue.ToString() + "," + ddlMonth.SelectedValue.ToString();
                                        }
                                      //  else { nd.Node_value = null; }
                                        break;
                                    case 23:
                                        if (ddlRelationShip.SelectedValue != "-1")
                                        {
                                            nd.Node_value = ddlRelationShip.SelectedValue;
                                        }
                                       // else { nd.Node_value = null; }
                                       
                                        break;
                                    case 24:
                                        string interestedIn=string.Empty;
                                        foreach (ListItem lItem in chkListInterestedIn.Items)
                                        {
                                            if (lItem.Selected == true)
                                            {
                                                if (interestedIn == string.Empty)
                                                {
                                                    interestedIn = interestedIn +  lItem.Value;
                                                }
                                                else {
                                                    interestedIn = interestedIn +","+ lItem.Value;
                                                }
                                                
                                            }
                                        }
                                        nd.Node_value = interestedIn;
                                        break;
                                    case 25:
                                        if (ddlHomeTown.SelectedValue != "-1")
                                        {
                                            nd.Node_value = ddlHomeTown.SelectedValue;
                                        }
                                       // else { nd.Node_value = null; }
                                     
                                        break;
                                    case 26:
                                       nd.Node_value= txtContactNumber.Text;
                                        break;
                                    case 27:
                                        nd.Node_value = txtContactEmail.Text;
                                        break;
                                    case 28:
                                      nd.Node_value=  txtSpecialist.Text;
                                        break;
                                }
                            }
                           
                                DAL.DataAccess.Node.SaveNodes(nodes);
                           
                            
                        }


                        dlBasicInfo.EditItemIndex = -1;
                        BindDataList();
                       
                    }
                    if (e.CommandName == "cancel")
                    {
                        dlBasicInfo.EditItemIndex = -1;
                        BindDataList();
                    }
                    break;
            }

        }
    }
}