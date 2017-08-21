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
    public class AvatarSample
    {
        private string m_avatar_file_Name = string.Empty;
        public string AvatarFileName
        {
            get { return m_avatar_file_Name; }
            set { m_avatar_file_Name = value; }
        }
    }
    public partial class ChatRoom : System.Web.UI.Page
    {
        private void BindSampleAvatarList()
        {

            System.Collections.Generic.List<AvatarSample> samples = new System.Collections.Generic.List<AvatarSample>();
            AvatarSample av;
            for (int i = 1; i < 7; i++)
            {
                av = new AvatarSample();
                av.AvatarFileName = "a" + i.ToString() + ".png";
                samples.Add(av);
            }
            dlAvatarList.DataSource = samples;
            dlAvatarList.DataBind();
        }

        private void SetMyPosition()
        {
            string strMyAvatar = txtMyDetails.Value;
            if (strMyAvatar.Length > 0)
            {
                string[] strSplitted = strMyAvatar.Split('/');


                string backgroundPosition = strSplitted[0];
                string[] topLeft = strSplitted[1].Split(' ');
                string left = topLeft[0];
                string top = topLeft[1];
                DAL.DataAccess.RoomChatter.UpdateUserState(Convert.ToInt64(Request["room_id"]), backgroundPosition, top, left,txtHiddenUserText.Value);
                txtHiddenUserText.Value = "";
                txtMyDetails.Value = "";
            }


        }

        private void BindUserInThisRoom()
        {
            System.Collections.Generic.List<DAL.DataObject.RoomChatter> RoomChatters = DAL.DataAccess.RoomChatter.GetRoomChatters(Convert.ToInt64(Request["room_id"]));
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
                    string strMyAvatar = txtMyDetails.Value;
                    if (strMyAvatar.Length > 0)
                    {
                        string[] strSplitted = strMyAvatar.Split('/');


                        string backgroundPosition = strSplitted[0];
                        string[] topLeft = strSplitted[1].Split(' ');
                        string left = topLeft[0];
                        string top = topLeft[1];
                        dvOtherContainer.Style.Add("left", left);
                        dvOtherContainer.Style.Add("top", top);
                        dvOther.Style.Add(" background-position", backgroundPosition);
                    }



                    Panel dvTxtContainer = new Panel();
                    

                    dvTxtContainer.Style.Add("background-image", "url(Images/Site/callout.gif)");

                    dvTxtContainer.Style.Add("z-index", "1");
                    dvTxtContainer.Style.Add("width", "150px");
                    dvTxtContainer.Style.Add("height", "90px");
                    dvTxtContainer.Style.Add("text-align", "left");
                    if (rchat.Message.Length==0 || rchat.SentTime < DateTime.Now.AddSeconds(-45))
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



        protected void Timer1_Tick(object sender, EventArgs e)
        {

        }

        protected void dlAvatarList_EditCommand(object source, DataListCommandEventArgs e)
        {


            ImageButton imguser = (ImageButton)e.Item.FindControl("imgUser");
            //DAL.DataAccess.RoomChatter.JoinAtRoom(

            DAL.DataObject.RoomChatter rtr = new BDDoctors.DAL.DataObject.RoomChatter();
            rtr.Id = LoginHandler.LoggedInUser().Id.Value;
            rtr.DisplayName = LoginHandler.LoggedInUser().DisplayName;
            rtr.Avatar = "url(" + imguser.ImageUrl.Replace("/sample", "").Replace("~/", "") + ")";// "url(Images/AvatarChat/avatar/a1.png)";
            rtr.CurrentRoom = Convert.ToInt64(Request["room_id"]);
            // LoginHandler.LoggedInUser().CurrentRoom = "wooden";
            rtr.BackGroundPosition = "4px 4px";
            MyAvatarImgContainer.Style.Add("background-image", rtr.Avatar);
            upanelMyAvatar.Update();
            DAL.DataAccess.RoomChatter.JoinAtRoom(rtr);

            txtMyDetails.Value = "192px 128px/8px 78px";
            btnRemoveMyAvatar.Visible = true;

            btnRemoveMyAvatar.Text = "";
            UpdatePanelMyDetails.Update();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // DAL.DataAccess.RoomChatter.Dispose();


            if (Page.IsPostBack)
            {
                SetMyPosition();
                BindUserInThisRoom();
                BindConversation();
                txtMyChtBox.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnChatPost.UniqueID + "').click(); return false;}} else {PutUserInputInHiddenBox('txtMyChtBox');return false}; ");

                txtChat.Attributes.Add("onkeydown", "if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + btnTextPost.UniqueID + "').click(); return false;}} else {return true}; ");



            }
            else
            {
                //if (LoginHandler.LoggedInUser().Id.Value == Convert.ToInt64(Request["room_id"]))
                //{
                //    hlinkChangeRoom.Visible = true;
                //}


                System.Drawing.Image oImg = System.Drawing.Image.FromFile(Server.MapPath("/images/AvatarChat/Background/") + @"\" + Convert.ToString(Request["room_id"]) + "_world.jpg");

                room.Style.Add("width", oImg.Width.ToString() + "px");
                room.Style.Add("height", oImg.Height.ToString() + "px");
                maindiv.Style.Add("height", oImg.Height.ToString() + "px");


                room.Style.Add("background-image", "url(Images/AvatarChat/Background/" + Convert.ToString(Request["room_id"]) + "_world.jpg?state="+DateTime.Now.Millisecond.ToString());
                dvConversation.Attributes.Add("latestconversation", BDDoctors.ChatAndOnlineUser.GetMaxRoomConversationId(Convert.ToInt64(Request["room_id"])).ToString());
                BindSampleAvatarList();
                DAL.DataAccess.RoomChatter.RemoveLoggedInUserFromThisRoom(Convert.ToInt64(Request["room_id"]));

                if (LoginHandler.LoggedInUser().Id.Value == Convert.ToInt64(Request["room_id"]))
                {
                    dvUploadPicture.Visible = true;
                }
                // DAL.DataAccess.RoomChatter.JoinAtRoom("wooden");

            }

        }
        private void BindConversation()
        {

            foreach (DAL.DataObject.Conversation cnvr in BDDoctors.ChatAndOnlineUser.GetConversationAtThisRoom(Convert.ToInt64(Request["room_id"]), Convert.ToInt64(dvConversation.Attributes["latestconversation"])))
            {
                dvConversation.InnerHtml += "<b>" + "<a href=" + ResolveClientUrl("~\\ChatRoom.aspx?room_id=") + cnvr.Sender_id.ToString() + ">" + cnvr.Sender_Name.ToString() + "<a>" + "</b> :<span>" + cnvr.Message.ToString() + "</span><br/>";
                dvConversation.Attributes.Add("latestconversation", cnvr.Id.ToString());
            }
        }

        protected void btnTextPost_Click(object sender, EventArgs e)
        {
            if (txtChat.Value.Length > 0)
            {
                DAL.DataObject.Conversation cnv = new BDDoctors.DAL.DataObject.Conversation();
                cnv.Message = DAL.Common.GetTextWithBr(txtChat.Value);
                cnv.Sender_id = LoginHandler.LoggedInUser().Id.Value;
                cnv.Sender_Name = LoginHandler.LoggedInUser().DisplayName;
                cnv.Room_id = Convert.ToInt64(Request["room_id"]);
                cnv.Action_date = DateTime.Now;
                BDDoctors.ChatAndOnlineUser.AddConversationToTheConversationList(cnv);
                BindConversation();
                txtChat.Value = "";
                UpdatePanel2.Update();
            }

        }

        protected void btnRemoveMyAvatar_Click(object sender, EventArgs e)
        {
            DAL.DataAccess.RoomChatter.RemoveLoggedInUserFromThisRoom(Convert.ToInt64(Request["room_id"]));
            Response.Redirect(ResolveClientUrl("~\\ChatRoom.aspx?room_id=") + Convert.ToString(Request["room_id"]));
            //txtMyDetails.Value = "";
            //BindUserInThisRoom();
            //btnRemoveMyAvatar.Text = "Your Avatar is Deactivated";
            //UpdatePanelMyDetails.Update();

        }

        protected void btnRoomBackUpload_Click(object sender, EventArgs e)
        {
            try {

                if (fileuploadRoomBack.HasFile)
                {
                    if (fileuploadRoomBack.PostedFile.ContentType.Contains("jpg") || fileuploadRoomBack.PostedFile.ContentType.Contains("jpeg") || fileuploadRoomBack.PostedFile.ContentType.Contains("bmp") || fileuploadRoomBack.PostedFile.ContentType.Contains("gif"))
                    {
                        fileuploadRoomBack.PostedFile.SaveAs(Server.MapPath("/Images/AvatarChat/Background/") + Convert.ToString(Request["room_id"]));
                        BDDoctors.ImageHelper.ResizeAndSave(Server.MapPath("/Images/AvatarChat/Background/"), Convert.ToString(Request["room_id"]), fileuploadRoomBack.PostedFile.ContentType);
                        string path;
                        path = "/Chatroom.aspx";
                        HttpResponse.RemoveOutputCacheItem(path); 
                    }
                    else
                    {
                        lbtnUploadMessage.Text = "jpg,png,gif,bmp images are supported";
                    }
                }
                else { lbtnUploadMessage.Text = "Browse a image to upload"; }
            }
            catch
            {
            }

        }
    }
}