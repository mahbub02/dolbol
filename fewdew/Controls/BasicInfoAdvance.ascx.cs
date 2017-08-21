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
    public partial class BasicInfoAdvance : System.Web.UI.UserControl
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
            System.Collections.Generic.List<System.Collections.Generic.List<DAL.DataObject.Node>> ListNodes = DAL.DataAccess.Node.GetListNodesOrAttribute("User Information", PageOwner());
            foreach (System.Collections.Generic.List<DAL.DataObject.Node> Nodes in ListNodes)
            {
                System.Collections.Generic.IEnumerable<Nullable<Int64>> Parent_Ids = from DAL.DataObject.Node nd in Nodes
                                                                                     where (nd.Parent_Node_Id != null)
                                                                                     select nd.Parent_Node_Id;
                Nullable<Int64> Parent_id = null;
                if (Parent_Ids != null)
                {
                    Parent_id = Parent_Ids.Max();
                }
                txt_Parent_id.Text = Parent_id.ToString();

                dlBasicInfo.DataSource = Nodes;
                dlBasicInfo.DataBind();
            }
        

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            BindDataList();
        }

        protected void dlEduInfoList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            DAL.DataObject.Node nd = (DAL.DataObject.Node)(e.Item.DataItem);
            Label lblAttribute = (Label)e.Item.FindControl("lblAttribute");
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    
                    Label lblValue = (Label)e.Item.FindControl("lblValue");
                    lblAttribute.Text = nd.Attribute_Name;
                    lblValue.Text = DAL.Common.ToString(nd.Node_value);
                    LinkButton lbtnedit = (LinkButton)(e.Item.FindControl("lbtnedit"));
                    lbtnedit.Visible = m_I_the_Owner;
                    break;
                case ListItemType.EditItem:
                    
                    HtmlGenericControl dvEditControls = (HtmlGenericControl)e.Item.FindControl("dvEditControls");
                    dvEditControls.Controls.Add(null);
                   
                    switch (nd.Attribute_id)
                    {
                        case 20:
                            TextBox txtFullName = new TextBox();
                            txtFullName.Text = DAL.Common.ToString(nd.Node_value);
                            dvEditControls.Controls.Add(txtFullName);
                            break;
                        case 21:
                            DropDownList ddlSex = new DropDownList();
                            UIhelper.PopulateDropDown(ddlSex, 1, null);
                            dvEditControls.Controls.Add(ddlSex);
                            ddlSex.SelectedValue = DAL.Common.ToString(nd.Node_value);
                            break;

                        case 22:
                            DropDownList ddlyear = new DropDownList();
                            UIhelper.PopulateDropDownYear(ddlyear, null);
                            dvEditControls.Controls.Add(ddlyear); 
                           
                            DropDownList ddlMonth = new DropDownList();
                            UIhelper.populateMonth(ddlMonth, null);
                            dvEditControls.Controls.Add(ddlMonth);
                           
                            
                            string[] str = (DAL.Common.ToString(nd.Node_value)).Split(',');
                            if (str.Length > 0 && str[0] != null && str[0] != "-1")
                            {
                                ddlyear.SelectedValue = str[0].ToString();
                            }
                            if (str.Length > 1 && str[1] != null && str[1] != "-1")
                            {
                                ddlMonth.SelectedValue = str[1].ToString();
                            }


                            break;
                        case 23:
                            CheckBoxList chkListInterested = new CheckBoxList();
                           // UIhelper.PopulateCheckList(chkListInterestedIn, 15, nd.Node_value);
                            dvEditControls.Controls.Add(chkListInterested);
                            break;
                        case 24:
                            DropDownList ddlHomeTown = new DropDownList();
                            //UIhelper.PopulateDropDown(ddlRelationShip, 17, null);
                           // ddlRelationShip.SelectedValue = DAL.Common.ToString(nd.Node_value);
                         //   dvEditControls.Controls.Add(
                            break;
                        case 25:
                            //DropDownList ddlHomeTown = new DropDownList();
                           // UIhelper.PopulateDropDown(ddlHomeTown, 23, null);
                           // ddlHomeTown.SelectedValue = DAL.Common.ToString(nd.Node_value);
                            break;
                        case 26:
                            TextBox txtContactNumber = new TextBox();
                            txtContactNumber.Text = DAL.Common.ToString(nd.Node_value);
                            dvEditControls.Controls.Add(txtContactNumber);

                           
                            break;
                        case 27:
                            TextBox txtContactEmail = new TextBox();
                            txtContactEmail.Text = DAL.Common.ToString(nd.Node_value);
                            dvEditControls.Controls.Add(txtContactEmail);
                           
                            break;
                        case 28:
                            TextBox txtSpecialist = new TextBox();
                            txtSpecialist.Text = DAL.Common.ToString(nd.Node_value);
                            dvEditControls.Controls.Add(txtSpecialist);
                           
                            break;
                    }
                    break;
            }
        }

        protected void dlEduInfoList_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }
    }
}