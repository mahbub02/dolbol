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
    public partial class CtrlForChatRoom : System.Web.UI.UserControl
    {
        string m_TextBoxvalue = string.Empty;
        string m_RoomId = string.Empty;
        public string TextBoxValue {
            set { m_TextBoxvalue = value; }
            get { return m_TextBoxvalue; }
        }
        public string RoomId
        {
            set { m_RoomId = value; BindUserInThisRoom(); }
            get { return m_RoomId; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void BindUserInThisRoom()
        {
            System.Collections.Generic.List<DAL.DataObject.RoomChatter> RoomChatters = DAL.DataAccess.RoomChatter.GetRoomChatters(Convert.ToInt64(RoomId));
            room.Controls.Clear();
            foreach (DAL.DataObject.RoomChatter rchat in RoomChatters)
            {
                if (rchat.Id.Value != LoginHandler.LoggedInUser().Id.Value)
                {
                    Panel dvOtherContainer = new Panel();


                    Panel dvOther = new Panel();
                    //Label lbl = new Label();
                    //lbl.Text = rchat.DisplayName;
                    //dvOther.Controls.Add(lbl);

                    HyperLink hlink = new HyperLink();
                    hlink.NavigateUrl = "~/Profile.aspx?user=" + rchat.Id.ToString();
                    hlink.Target = "_blank";
                    hlink.ToolTip = "Click Here to visit " + rchat.DisplayName + "'s room";
                    hlink.Text = rchat.DisplayName;
                    hlink.CssClass = "user_name";
                    dvOther.Controls.Add(hlink);
                    dvOther.CssClass = "dvOther";

                    dvOtherContainer.Style.Add("position", "absolute");
                    dvOtherContainer.Style.Add("left", rchat.Left);
                    dvOtherContainer.Style.Add("top", rchat.Top);
                    dvOther.Style.Add("width", "64px");
                    dvOther.Style.Add("height", "64px");
                    dvOther.Style.Add("background-image", rchat.Avatar);
                    dvOther.Style.Add(" background-position", rchat.BackGroundPosition);
                    //string strMyAvatar = txtMyDetails.Value;
                    //string strMyAvatar = m_TextBoxvalue;
                    //if (strMyAvatar.Length > 0)
                    //{
                    //    string[] strSplitted = strMyAvatar.Split('/');


                    //    string backgroundPosition = strSplitted[0];
                    //    string[] topLeft = strSplitted[1].Split(' ');
                    //    string left = topLeft[0];
                    //    string top = topLeft[1];
                    //    dvOtherContainer.Style.Add("left", left);
                    //    dvOtherContainer.Style.Add("top", top);
                    //    dvOther.Style.Add(" background-position", backgroundPosition);
                    //}



                    Panel dvTxtContainer = new Panel();


                    dvTxtContainer.Style.Add("background-image", "url(Images/Site/callout.gif)");

                    dvTxtContainer.Style.Add("z-index", "1");
                    dvTxtContainer.Style.Add("width", "150px");
                    dvTxtContainer.Style.Add("height", "90px");
                    dvTxtContainer.Style.Add("text-align", "left");
                    if (rchat.Message.Length == 0 || rchat.SentTime < DateTime.Now.AddSeconds(-45))
                    {
                        dvTxtContainer.Style.Add("visibility", "hidden");
                    }
                    else
                    {
                        dvTxtContainer.Style.Add("visibility", "visible");
                    }
                    Label lblTxt = new Label();
                    lblTxt.Text = rchat.Message;
                    dvTxtContainer.Controls.Add(lblTxt);

                    dvOtherContainer.Controls.Add(dvTxtContainer);
                    dvOtherContainer.Controls.Add(dvOther);

                    room.Controls.Add(dvOtherContainer);
                }
            }
        }
    }
}