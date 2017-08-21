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
    public partial class Workstation : System.Web.UI.UserControl
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
            //System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOnly("13", PageOwner());
            //dlWorkInfoList.DataSource = ListNodes;
            //dlWorkInfoList.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AmIThePageOwner();
            if (Page.IsPostBack == false)
            {
                BindDataList();
            }
        }

        protected void dlWorkInfoList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Footer:
                    DropDownList ddlWorkNature = (DropDownList)(e.Item.FindControl("ddlWorkNature"));
                    DropDownList ddlFromYear = (DropDownList)(e.Item.FindControl("ddlFromYear"));
                    DropDownList ddlFromMonth = (DropDownList)(e.Item.FindControl("ddlFromMonth"));
                    DropDownList ddlToYear = (DropDownList)(e.Item.FindControl("ddlToYear"));
                    DropDownList ddlToMonth = (DropDownList)(e.Item.FindControl("ddlToMonth"));
                   
                    UIhelper.PopulateDropDownYear(ddlFromYear, "-1");
                    UIhelper.populateMonth(ddlFromMonth, "-1");
                    UIhelper.PopulateDropDownYear(ddlToYear, "-1");
                    UIhelper.populateMonth(ddlToMonth, "-1");

                    UIhelper.PopulateDropDown(ddlWorkNature,12,"-1");

                    
                    Button btnAdd = (Button)(e.Item.FindControl("btnAdd"));
                    LinkButton lbtnAddMoreInfo = (LinkButton)(e.Item.FindControl("lbtnAddMoreInfo"));
                    btnAdd.Visible = m_I_the_Owner;
                    lbtnAddMoreInfo.Visible = m_I_the_Owner;
                   
                    break;
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    System.Collections.Generic.List<DAL.DataObject.Node> nodes = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Item.DataItem;
                    Label lblWorkNatureValue = (Label)e.Item.FindControl("lblWorkNatureValue");
                    Label lblWhereValue = (Label)e.Item.FindControl("lblWhereValue");
                    Label lblFromValue = (Label)e.Item.FindControl("lblFromValue");

                    Label lblMyRoleValue = (Label)e.Item.FindControl("lblMyRoleValue");
                    Label lblReferanceValue = (Label)e.Item.FindControl("lblReferanceValue");
                    Label lblDescriptionValue = (Label)e.Item.FindControl("lblDescriptionValue");

                    LinkButton lbtnEditWorkInfo = (LinkButton)(e.Item.FindControl("lbtnEditWorkInfo"));
                    lbtnEditWorkInfo.Visible = m_I_the_Owner;


                    foreach (DAL.DataObject.Node nd in nodes)
                    {
                        switch (nd.Attribute_id)
                        {
                            case 13:
                                lblWorkNatureValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 14:
                                lblWhereValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 15:
                                lblFromValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 17:
                                lblMyRoleValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 18:
                                lblReferanceValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 19:
                                lblDescriptionValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                        }
                    }
                    break;
                case ListItemType.EditItem:
                    DropDownList ddlWorkNatureForEdit = (DropDownList)(e.Item.FindControl("ddlWorkNature"));
                    TextBox txtWhereForEdit = (TextBox)e.Item.FindControl("txtWhere");
                    DropDownList ddlFromYearForEdit = (DropDownList)(e.Item.FindControl("ddlFromYear"));
                    DropDownList ddlFromMonthForEdit = (DropDownList)(e.Item.FindControl("ddlFromMonth"));
                    DropDownList ddlToYearForEdit = (DropDownList)(e.Item.FindControl("ddlToYear"));
                    DropDownList ddlToMonthForEdit = (DropDownList)(e.Item.FindControl("ddlToMonth"));
                    
                    TextBox txtMyRoleForEdit = (TextBox)e.Item.FindControl("txtMyRole");
                    TextBox txtReferenceForEdit = (TextBox)e.Item.FindControl("txtReference");
                    TextBox txtDescriptionForEdit = (TextBox)e.Item.FindControl("txtDescription");
                    TextBox txt_Parent_id = (TextBox)e.Item.FindControl("txtParent_id");

                    UIhelper.PopulateDropDownYear(ddlFromYearForEdit, "-1");
                    UIhelper.populateMonth(ddlFromMonthForEdit, "-1");

                    UIhelper.PopulateDropDownYear(ddlToYearForEdit, "-1");
                    UIhelper.populateMonth(ddlToMonthForEdit, "-1");
                    
                    UIhelper.PopulateDropDown(ddlWorkNatureForEdit, 12, "-1");

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


                   
                    foreach (DAL.DataObject.Node nd in nodeList)
                    {
                        switch (nd.Attribute_id)
                        {
                            case 13:
                                ddlWorkNatureForEdit.SelectedValue = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 14:
                                txtWhereForEdit.Text = DAL.Common.RemoveBrFromText( DAL.Common.ToString(nd.Node_value));
                                break;
                            case 15:
                                string[] strToFrom = (DAL.Common.ToString(nd.Node_value)).Split('-');
                                
                                string[] strFrom = (strToFrom[0]).Split(',');
                                ddlFromYearForEdit.SelectedValue = strFrom[0].ToString();
                                ddlFromMonthForEdit.SelectedValue = strFrom[1].ToString();

                                if (strToFrom.Length>1&&strToFrom[1] != "continuing")
                                {
                                    string[] strTo = (strToFrom[1]).Split(',');
                                    ddlToYearForEdit.SelectedValue = strTo[0].ToString();
                                    ddlToMonthForEdit.SelectedValue = strTo[1].ToString();
                                }
                                
                                break;
                            case 17:
                                txtMyRoleForEdit.Text =DAL.Common.RemoveBrFromText( DAL.Common.ToString(nd.Node_value));
                                break;
                            case 18:
                                txtReferenceForEdit.Text =DAL.Common.RemoveBrFromText( DAL.Common.ToString(nd.Node_value));
                                break;
                            case 19:
                                txtDescriptionForEdit.Text =DAL.Common.RemoveBrFromText( DAL.Common.ToString(nd.Node_value));
                                break;
                        }
                    }
                    break;
            }

        }

        protected void dlWorkInfoList_ItemCommand(object source, DataListCommandEventArgs e)
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
                        DropDownList ddlWorkNatureForAdd = (DropDownList)(e.Item.FindControl("ddlWorkNature"));
                        TextBox txtWhereForAdd = (TextBox)e.Item.FindControl("txtWhere");
                        DropDownList ddlFromYearForAdd = (DropDownList)(e.Item.FindControl("ddlFromYear"));
                        DropDownList ddlFromMonthForAdd = (DropDownList)(e.Item.FindControl("ddlFromMonth"));

                        DropDownList ddlToYearForAdd = (DropDownList)(e.Item.FindControl("ddlToYear"));
                        DropDownList ddlToMonthForAdd = (DropDownList)(e.Item.FindControl("ddlToMonth"));

                        TextBox txtMyRoleForAdd = (TextBox)e.Item.FindControl("txtMyRole");
                        TextBox txtReferenceForAdd = (TextBox)e.Item.FindControl("txtReference");
                        TextBox txtDescriptionForAdd = (TextBox)e.Item.FindControl("txtDescription");

                        Label lblMessage = (Label)e.Item.FindControl("lblMessage");
                        string message = "Please Enter";
                        Boolean IsValidate = true;
                        if (ddlWorkNatureForAdd.SelectedValue == "-1")
                        {
                            message += " (Work Nature) ";
                            IsValidate = false;
                        }
                        if (txtWhereForAdd.Text.Trim().Length < 1)
                        {
                            message += " (Work Location) ";
                            IsValidate = false;
                        }
                        if (ddlFromYearForAdd.SelectedItem.Value == "-1")
                        {
                            message += " (Year) ";
                            IsValidate = false;
                        }
                        if (ddlFromMonthForAdd.SelectedItem.Value == "-1")
                        {
                            message += " (Month) ";
                            IsValidate = false;
                        }
                        if (txtMyRoleForAdd.Text.Trim().Length < 1)
                        {
                            message += " (Role) ";
                            IsValidate = false;
                        }
                        ////if (txtReferenceForAdd.Text.Trim().Length < 1)
                        ////{
                        ////    message += " (Reference) ";
                        ////    IsValidate = false;
                        ////}
                        ////if (txtDescriptionForAdd.Text.Trim().Length < 1)
                        ////{
                        ////    message += " (Description) ";
                        ////    IsValidate = false;
                        ////}
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
                        nd.Attribute_id = 13;
                        nd.Node_value = ddlWorkNatureForAdd.SelectedValue;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 14;
                        nd.Node_value = txtWhereForAdd.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 15;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nd.User_id = LoginHandler.LoggedInUser().Id.Value;
                        nd.Node_value = ddlFromYearForAdd.SelectedValue + "," + ddlFromMonthForAdd.SelectedValue;
                        if (ddlToMonthForAdd.SelectedValue != "-1" && ddlToYearForAdd.SelectedValue != "-1")
                        {
                            nd.Node_value = nd.Node_value +"-"+ ddlToYearForAdd.SelectedValue + "," + ddlToMonthForAdd.SelectedValue;
                        }
                        else 
                        {
                            nd.Node_value = nd.Node_value + "-" + "continuing";
                        }
                        
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 17;
                        nd.Node_value = txtMyRoleForAdd.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 18;
                        nd.Node_value = txtReferenceForAdd.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 19;
                        nd.Node_value = txtDescriptionForAdd.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName.ToString();
                        nodeList.Add(nd);

                        DAL.DataAccess.Node.SaveNodes(nodeList);

                        BindDataList();
                    }
                    else {
                        HtmlGenericControl dv = (HtmlGenericControl)e.Item.FindControl("dvFooterContent");
                        dv.Visible = false;
                        LinkButton lbtn = (LinkButton)e.Item.FindControl("lbtnAddMoreInfo");
                        lbtn.Visible = true;
                    }
                    break;
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    dlWorkInfoList.EditItemIndex = e.Item.ItemIndex;
                    BindDataList();
                    break;
                case ListItemType.EditItem:
                    if (e.CommandName == "update")
                    {

                        DropDownList ddlWorkNatureForUpdate = (DropDownList)(e.Item.FindControl("ddlWorkNature"));
                        TextBox txtWhereForUpdate = (TextBox)e.Item.FindControl("txtWhere");
                        DropDownList ddlFromYearForUpdate = (DropDownList)(e.Item.FindControl("ddlFromYear"));
                        DropDownList ddlFromMonthForUpdate = (DropDownList)(e.Item.FindControl("ddlFromMonth"));
                        DropDownList ddlToYearForUpdate = (DropDownList)(e.Item.FindControl("ddlToYear"));
                        DropDownList ddlToMonthForUpdate = (DropDownList)(e.Item.FindControl("ddlToMonth"));
                        TextBox txtMyRoleForUpdate = (TextBox)e.Item.FindControl("txtMyRole");
                        TextBox txtReferenceForUpdate = (TextBox)e.Item.FindControl("txtReference");
                        TextBox txtDescriptionForUpdate = (TextBox)e.Item.FindControl("txtDescription");
                        Label lblMessageForUpdate = (Label)e.Item.FindControl("lblMessage");

                        TextBox txtParent_idForUpdate = (TextBox)e.Item.FindControl("txtParent_id");

                        string messageForUpdate = "Please Enter";
                        Boolean IsValidateForUpdate = true;
                        if (ddlWorkNatureForUpdate.SelectedValue == "-1")
                        {
                            messageForUpdate += " (Work Nature) ";
                            IsValidateForUpdate = false;
                        }
                        if (txtWhereForUpdate.Text.Trim().Length < 1)
                        {
                            messageForUpdate += " (Work Location) ";
                            IsValidateForUpdate = false;
                        }
                        if (ddlFromYearForUpdate.SelectedItem.Value == "-1")
                        {
                            messageForUpdate += " (Year) ";
                            IsValidateForUpdate = false;
                        }
                        if (ddlFromMonthForUpdate.SelectedItem.Value == "-1")
                        {
                            messageForUpdate += " (Month) ";
                            IsValidateForUpdate = false;
                        }
                        if (txtMyRoleForUpdate.Text.Trim().Length < 1)
                        {
                            messageForUpdate += " (Role) ";
                            IsValidateForUpdate = false;
                        }
                        //if (txtReferenceForUpdate.Text.Trim().Length < 1)
                        //{
                        //    messageForUpdate += " (Reference) ";
                        //    IsValidateForUpdate = false;
                        //}
                        //if (txtDescriptionForUpdate.Text.Trim().Length < 1)
                        //{
                        //    messageForUpdate += " (Description) ";
                        //    IsValidateForUpdate = false;
                        //}
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
                        DAL.DataAccess.Node.UpdateNodes(parent_id, 13, ddlWorkNatureForUpdate.SelectedValue);
                        DAL.DataAccess.Node.UpdateNodes(parent_id, 14, txtWhereForUpdate.Text);

                        String StrDuration = ddlFromYearForUpdate.SelectedValue + "," + ddlFromMonthForUpdate.SelectedValue;
                        if (ddlToMonthForUpdate.SelectedValue != "-1" && ddlToYearForUpdate.SelectedValue != "-1")
                        {
                            StrDuration = StrDuration + "-" + ddlToYearForUpdate.SelectedValue + "," + ddlToMonthForUpdate.SelectedValue;
                        }
                        else
                        {
                            StrDuration = StrDuration + "-" + "continuing";
                        }



                        DAL.DataAccess.Node.UpdateNodes(parent_id, 15, StrDuration);
                        DAL.DataAccess.Node.UpdateNodes(parent_id, 17, txtMyRoleForUpdate.Text);
                        DAL.DataAccess.Node.UpdateNodes(parent_id, 18, txtReferenceForUpdate.Text);
                        DAL.DataAccess.Node.UpdateNodes(parent_id, 19, txtDescriptionForUpdate.Text);
                        dlWorkInfoList.EditItemIndex = -1;
                        BindDataList();
                    }
                    else if (e.CommandName == "delete")
                    {
                        TextBox txtParent_idForDelete = (TextBox)e.Item.FindControl("txtParent_id");
                        Int64 parent_id = Convert.ToInt64(txtParent_idForDelete.Text);
                        DAL.DataAccess.Node.DeleteNodes(parent_id);
                        dlWorkInfoList.EditItemIndex = -1;
                        BindDataList();
                    }
                    else if (e.CommandName == "cancel")
                    {
                        dlWorkInfoList.EditItemIndex = -1;
                        BindDataList();
                    }
                    break;


            }

        }
    }
}