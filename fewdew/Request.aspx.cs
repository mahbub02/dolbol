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

namespace BDDoctors
{
    public partial class Request : System.Web.UI.Page
    {
        private void BindRequest()
        {
            System.Collections.Generic.List<DAL.DataObject.Friend> frndlist = DAL.DataAccess.FriendShip.GetFriendAwaitingForMyResponse(LoginHandler.LoggedInUser().Id.Value);
            if (frndlist.Count == 0)
            {
                lblRequestMessage.Text = "There is no request.";
            }
            else { lblRequestMessage.Text = ""; }
            dlRequestList.DataSource = frndlist;
            dlRequestList.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindRequest();
            } 
        }

        protected void dlRequestList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            TextBox txtUserId = (TextBox)e.Item.FindControl("txtUserId");
            if (e.CommandName == "accept")
            {
                
                if (txtUserId.Text.Length > 0)
                {
                    DAL.DataObject.FriendShip frndshp = new BDDoctors.DAL.DataObject.FriendShip();
                    frndshp.User1 = LoginHandler.LoggedInUser().Id;
                    frndshp.User2 = Convert.ToInt64(txtUserId.Text);
                    frndshp.Status = 1;
                    DAL.DataAccess.FriendShip.SaveFriendShip(frndshp);
                   
                }
            }
            else {
                DAL.DataAccess.FriendShip.DeleteFriendShip( Convert.ToInt64(txtUserId.Text), LoginHandler.LoggedInUser().Id.Value);
            }
            e.Item.Visible = false;
            BindRequest();
        }

        protected void dlRequestList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            DAL.DataObject.Friend frndReq = (DAL.DataObject.Friend)e.Item.DataItem;

            HyperLink hlink=(HyperLink)e.Item.FindControl("hlinkImage");
            hlink.NavigateUrl=ResolveClientUrl("/Profile.aspx?user="+frndReq.UserId.ToString());
            HyperLink lbtnUserName = (HyperLink)e.Item.FindControl("lbtnUserName");
             lbtnUserName.Text = frndReq.DisplayName;
             lbtnUserName.NavigateUrl = ResolveClientUrl("/Profile.aspx?user=" + frndReq.UserId.ToString());

            TextBox txtUserId=(TextBox)e.Item.FindControl("txtUserId");
            txtUserId.Text = frndReq.UserId.Value.ToString();

            HtmlImage imgBtn = (HtmlImage)e.Item.FindControl("imgFriendPic");
            //imgBtn.ImageUrl = Server.MapPath("/images/profile/") + frndReq.UserId.Value.ToString()+"_mini.jpg";
            imgBtn.Src = ResolveClientUrl("/images/profile/" + frndReq.UserId.Value.ToString() + "_thumb.jpg");
            

           
            

        }
    }
}
