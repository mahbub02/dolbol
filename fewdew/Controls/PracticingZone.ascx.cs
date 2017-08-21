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
    public partial class PracticingZone : System.Web.UI.UserControl
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
            System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOnly(29, PageOwner());
            dlPracticeZoneList.DataSource = ListNodes;
            dlPracticeZoneList.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AmIThePageOwner();
            if (Page.IsPostBack == false)
            {
                BindDataList();
            }
        }

        protected void dlPracticeZoneList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            TextBox txtZoneAddress; 
            CheckBoxList chklistDays;
            DropDownList ddlFromValue ;
            DropDownList ddlToValue;
            TextBox txtContactNumberValue;
            switch (e.Item.ItemType)
            {
                case ListItemType.Footer:
                    chklistDays = (CheckBoxList)(e.Item.FindControl("chklistDays"));
                     ddlFromValue = (DropDownList)(e.Item.FindControl("ddlFromValue"));
                    ddlToValue = (DropDownList)(e.Item.FindControl("ddlToValue"));
                 
                    Button btnAdd = (Button)(e.Item.FindControl("btnAdd"));
                    LinkButton lbtnAddMoreInfo = (LinkButton)(e.Item.FindControl("lbtnAddMoreInfo"));
                    btnAdd.Visible = m_I_the_Owner;
                    lbtnAddMoreInfo.Visible = m_I_the_Owner;
                    
                    UIhelper.populateFromTime(ddlFromValue,null);
                    UIhelper.populateToTime(ddlToValue,null);
                    UIhelper.PopulateDayList(chklistDays,null);
                    break;
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    System.Collections.Generic.List<DAL.DataObject.Node> nodes = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Item.DataItem;
                    Label lblZoneAddressValue = (Label)e.Item.FindControl("lblZoneAddressValue");
                    Label lblDaysValue = (Label)e.Item.FindControl("lblDaysValue");
                    Label lblScheduleValue = (Label)e.Item.FindControl("lblScheduleValue");
                    Label lblContactNumberValue = (Label)e.Item.FindControl("lblContactNumberValue");

                    LinkButton lbtnEditZoneInfo = (LinkButton)(e.Item.FindControl("lbtnEditZoneInfo"));
                    lbtnEditZoneInfo.Visible = m_I_the_Owner;

                    foreach (DAL.DataObject.Node nd in nodes)
                    {
                        switch (nd.Attribute_id)
                        {
                            case 29:
                                lblZoneAddressValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 30:
                                lblDaysValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 31:
                                lblScheduleValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                            case 32:
                                lblContactNumberValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                        }
                    }
                    break;
                case ListItemType.EditItem:
                     txtZoneAddress = (TextBox)e.Item.FindControl("txtZoneAddress");
                     chklistDays = ( CheckBoxList)e.Item.FindControl("chklistDays");                  
                    ddlFromValue = (DropDownList)(e.Item.FindControl("ddlFromValue"));
                     ddlToValue = (DropDownList)(e.Item.FindControl("ddlToValue"));
                   txtContactNumberValue = (TextBox)e.Item.FindControl("txtContactNumberValue");
                  TextBox txtParent_id = (TextBox)e.Item.FindControl("txtParent_id");

                   UIhelper.populateFromTime(ddlFromValue, null);
                   UIhelper.populateToTime(ddlToValue, null);
                    System.Collections.Generic.List<DAL.DataObject.Node> nodeList = (System.Collections.Generic.List<DAL.DataObject.Node>)e.Item.DataItem;
                    System.Collections.Generic.IEnumerable<Nullable<Int64>> Parent_Ids = from DAL.DataObject.Node nd in nodeList
                                                                                         where (nd.Parent_Node_Id != null)
                                                                                         select nd.Parent_Node_Id;
                    Nullable<Int64> Parent_id = null;
                    if (Parent_Ids != null)
                    {
                        Parent_id = Parent_Ids.Max();
                    }
                    txtParent_id.Text = Parent_id.ToString();
                 foreach (DAL.DataObject.Node nd in nodeList)
                    {
                        switch (nd.Attribute_id)
                        {
                            case 29:
                                txtZoneAddress.Text = DAL.Common.RemoveBrFromText( DAL.Common.ToString(nd.Node_value));
                                break;
                            case 30:
                                UIhelper.PopulateDayList(chklistDays,DAL.Common.ToString(nd.Node_value));
                                break;
                            case 31:
                                string[] str = (DAL.Common.ToString(nd.Node_value)).Split('-');
                                if (str.Length>0 &&str[0] != null && str[0] != "-1")
                                {
                                    ddlFromValue.SelectedValue = str[0].ToString();
                                }
                                if (str.Length>1 && str[1] != null && str[1] != "-1")
                                {
                                    ddlToValue.SelectedValue = str[1].ToString();
                                }
                                break;

                            case 32:
                                txtContactNumberValue.Text = DAL.Common.ToString(nd.Node_value);
                                break;
                        }
                    }
                    break;
            }

        }

        protected void dlPracticeZoneList_ItemCommand(object source, DataListCommandEventArgs e)
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
                         TextBox txtZoneAddress = (TextBox)e.Item.FindControl("txtZoneAddress");
                        CheckBoxList chklistDays = (CheckBoxList)(e.Item.FindControl("chklistDays"));
                        DropDownList ddlFromValue = (DropDownList)(e.Item.FindControl("ddlFromValue"));
                        DropDownList ddlToValue = (DropDownList)(e.Item.FindControl("ddlToValue"));                        
                       TextBox txtContactNumberValue = (TextBox)e.Item.FindControl("txtContactNumberValue");



                        Label lblMessage = (Label)e.Item.FindControl("lblMessage");
                        string message = "Please Enter";
                        Boolean IsValidate = true;
                        if (txtZoneAddress.Text.Trim().Length < 1)
                        {
                            message += " (Address) ";
                            IsValidate = false;
                        }
                        Boolean singleChecked=false;
                       foreach (ListItem li in chklistDays.Items)
                        {
                           if(li.Selected==true)
                           {
                               singleChecked=true;
                           }
                        }
                        if(singleChecked==false)
                        {
                            message += " (Practice day) ";
                            IsValidate = false;
                        }
                        
                        if (ddlFromValue.SelectedValue=="-1")
                        {
                            message += " (Schedule[From]) ";
                            IsValidate = false;
                        }
                         if (ddlToValue.SelectedValue=="-1")
                        {
                            message += " (Schedule[To]) ";
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
                        nd.Attribute_id = 29;
                        nd.Node_value = txtZoneAddress.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 30;
                        string strDays=string.Empty;
                        foreach (ListItem li in chklistDays.Items)
                        {
                            if(li.Selected==true)
                            {
                                if(strDays.Length==0)
                                {
                                    strDays=strDays+li.Value;
                                   
                                }
                                else{strDays=strDays+","+li.Value;}
                                
                            }
                        }
                        nd.Node_value = strDays;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 31;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                        nd.Node_value = ddlFromValue.SelectedValue+"-"+ddlToValue.SelectedValue;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 32;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                        nd.Node_value = txtContactNumberValue.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
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
                    dlPracticeZoneList.EditItemIndex = e.Item.ItemIndex;
                    BindDataList();
                    break;
                case ListItemType.EditItem:
                    if (e.CommandName == "update")
                    {
                        TextBox txtZoneAddress = (TextBox)e.Item.FindControl("txtZoneAddress");
                        CheckBoxList chklistDays = (CheckBoxList)(e.Item.FindControl("chklistDays"));
                        DropDownList ddlFromValue = (DropDownList)(e.Item.FindControl("ddlFromValue"));
                        DropDownList ddlToValue = (DropDownList)(e.Item.FindControl("ddlToValue"));                        
                        TextBox txtContactNumberValue = (TextBox)e.Item.FindControl("txtContactNumberValue");
                        TextBox txtParent_idForUpdate = (TextBox)e.Item.FindControl("txtParent_id");


                        Label lblMessage = (Label)e.Item.FindControl("lblMessage");
                        string message = "Please Enter";
                        Boolean IsValidate = true;
                        if (txtZoneAddress.Text.Trim().Length < 1)
                        {
                            message += " (Address) ";
                            IsValidate = false;
                        }
                        Boolean singleChecked=false;
                       foreach (ListItem li in chklistDays.Items)
                        {
                           if(li.Selected==true)
                           {
                               singleChecked=true;
                           }
                        }
                        if(singleChecked==false)
                        {
                            message += " (Practice day) ";
                            IsValidate = false;
                        }
                        
                        if (ddlFromValue.SelectedValue=="-1")
                        {
                            message += " (Schedule[From]) ";
                            IsValidate = false;
                        }
                         if (ddlToValue.SelectedValue=="-1")
                        {
                            message += " (Schedule[To]) ";
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
                        nd.Attribute_id = 29;
                        nd.Node_value = txtZoneAddress.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 30;
                        string strDays=string.Empty;
                        foreach (ListItem li in chklistDays.Items)
                        {
                            if(li.Selected==true)
                            {
                                if(strDays.Length==0)
                                {
                                    strDays=strDays+li.Value;
                                   
                                }
                                else{strDays=strDays+","+li.Value;}
                                
                            }
                        }
                        nd.Node_value = strDays;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.Parent_Node_Id=Convert.ToInt64(  txtParent_idForUpdate.Text);
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 31;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                        nd.Node_value = ddlFromValue.SelectedValue+"-"+ddlToValue.SelectedValue;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.Parent_Node_Id = Convert.ToInt64(txtParent_idForUpdate.Text);
                        nodeList.Add(nd);

                        nd = new BDDoctors.DAL.DataObject.Node();
                        nd.Attribute_id = 32;
                        nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                        nd.Node_value = txtContactNumberValue.Text;
                        nd.User_id = LoginHandler.LoggedInUser().Id;
                        nd.Parent_Node_Id = Convert.ToInt64(txtParent_idForUpdate.Text);
                        nodeList.Add(nd);


                        DAL.DataAccess.Node.SaveNodes(nodeList);
                        dlPracticeZoneList.EditItemIndex = -1;
                        BindDataList();
                        

                        
                    }
                    else if (e.CommandName == "delete")
                    {

                        TextBox txtParent_idForDelete = (TextBox)e.Item.FindControl("txtParent_id");
                        Int64 parent_id = Convert.ToInt64(txtParent_idForDelete.Text);
                        DAL.DataAccess.Node.DeleteNodes(parent_id);
                        dlPracticeZoneList.EditItemIndex = -1;
                        BindDataList();
                    }
                    else if (e.CommandName == "cancel")
                    {
                        dlPracticeZoneList.EditItemIndex = -1;
                        BindDataList();
                    }
                    break;


            }

        }
    }
}