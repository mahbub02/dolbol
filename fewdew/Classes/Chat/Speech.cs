using System;
using System.Data;
using System.Configuration;
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
    public class Speech
    {
        private static System.Collections.Generic.List<DAL.DataObject.Speech> m_Speech = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Speech>();

        public static System.Collections.Generic.List<DAL.DataObject.Speech> GetSpeeches{
            get { return m_Speech; }
            set { }
        }
        public static void AddSpeechToTheSpeecList(DAL.DataObject.Speech Speech){
           m_Speech.Add(Speech);
        }

        public static System.Collections.Generic.List<DAL.DataObject.Speech> GetAllUnDeliveredSpeechesForThisUser(Int64 UserId){

            System.Collections.Generic.IEnumerable<DAL.DataObject.Speech> Speeches = from DAL.DataObject.Speech sph in m_Speech
                                                                                     where ((sph.User1Id.Value == UserId) && (sph.IsDelivered==0|| sph.LastModifiedDate>DateTime.Now.AddSeconds(-10) ))
                                                                                     select sph;



           

            if (Speeches.ToList<DAL.DataObject.Speech>().Count == 1){
                foreach (DAL.DataObject.Speech Speech in Speeches.ToList<DAL.DataObject.Speech>())
                {
                    Speech.IsDelivered = 1;
                }

                Speeches = from DAL.DataObject.Speech sph in m_Speech
                           where (sph.User1Id.Value == UserId )
                           select sph;
                return Speeches.ToList<DAL.DataObject.Speech>(); 

            }

            return new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Speech>();
           
        }

        public static System.Collections.Generic.List<DAL.DataObject.Speech> GetAllSpeechesForThisUser(Int64 UserId){
            System.Collections.Generic. IEnumerable<DAL.DataObject.Speech> Speeches = from DAL.DataObject.Speech sph in m_Speech
                                                                                      where (sph.User1Id.Value ==UserId  )
                                                                                      select sph;
            if (Speeches.ToList<DAL.DataObject.Speech>().Count == 1){
                foreach (DAL.DataObject.Speech Speech in Speeches.ToList<DAL.DataObject.Speech>()){
                    Speech.IsDelivered = 1;
                }

            }
            return Speeches.ToList<DAL.DataObject.Speech>();
        }


        public static System.Collections.Generic.List<DAL.DataObject.Speech> UpdateSpeech(Int32 UserId,string displayName, string Message)
        {

            Boolean IsOnline=OnlineUser.isOnline(UserId);// jake message pathabo she online kina check kora holo.
            if (IsOnline == false)
            {
                Message = ""; // online na jehetu shehetu text ta 0 length er kore dilam jeno. Amar end chara onno end er speech e kono update na ghote
            }
            
            DAL.DataObject.User ObjSender=new BDDoctors.DAL.DataObject.User();// = DAL.DataAccess.User.GetUser(Convert.ToInt64(UserId));
            ObjSender.Id = UserId;
            ObjSender.DisplayName = displayName;

            System.Collections.Generic.IEnumerable<DAL.DataObject.Speech> Speeches;

            Speeches = from DAL.DataObject.Speech sph in m_Speech
                       where ((sph.User1Id.Value == LoginHandler.LoggedInUser().Id.Value) && (sph.User2Id.Value == UserId))
                       select sph;

            if (Speeches.ToList<DAL.DataObject.Speech>().Count == 1)
            {
                foreach (DAL.DataObject.Speech Speech in Speeches.ToList<DAL.DataObject.Speech>())
                {
                    Speech.IsDelivered = 0;
                    if (IsOnline == false)
                    {
                        Speech.Message = Speech.Message + "<p class=\"user-offline\">"+displayName+" is not online</p>";
                    }
                    else {
                        Speech.Message = GetAppendMessageMarkup(ObjSender, Speech.Message, Message);
                    }
                    
                    Speech.LastModifiedDate = DateTime.Now;
                }
            }
            else if (Speeches.ToList<DAL.DataObject.Speech>().Count == 0)
            {
                DAL.DataObject.Speech speech = new BDDoctors.DAL.DataObject.Speech();
                speech.User1Id = LoginHandler.LoggedInUser().Id.Value;
                speech.User1DisplayName = LoginHandler.LoggedInUser().DisplayName;
                speech.User2Id = ObjSender.Id;
                speech.User2DisplayName = ObjSender.DisplayName;
                speech.WindowStatus = 1;
                speech.IsDelivered = 0;
                if (IsOnline == false)
                {
                    speech.Message = speech.Message + "<p class=\"user-offline\">" + displayName + " is not online</p>";
                }
                else
                {
                    speech.Message = GetAppendMessageMarkup(ObjSender, "", Message);
                }
                
                speech.LastModifiedDate = DateTime.Now;

                AddSpeechToTheSpeecList(speech);

            }
            else if (Speeches.ToList<DAL.DataObject.Speech>().Count > 1)
            {
                throw new ArgumentException("More than one instance created which is unexpected");
            }


            if (Message.Length > 0) 
            {
                Speeches = from DAL.DataObject.Speech sph in m_Speech
                           where ((sph.User2Id.Value == LoginHandler.LoggedInUser().Id.Value) && (sph.User1Id.Value == UserId))
                           select sph;

                if (Speeches.ToList<DAL.DataObject.Speech>().Count == 1)
                {
                    foreach (DAL.DataObject.Speech Speech in Speeches.ToList<DAL.DataObject.Speech>())
                    {
                        Speech.IsDelivered = 0;
                        Speech.Message = GetAppendMessageMarkup(ObjSender, Speech.Message, Message);
                        Speech.LastModifiedDate = DateTime.Now;
                    }
                }
                else if (Speeches.ToList<DAL.DataObject.Speech>().Count == 0)
                {
                    DAL.DataObject.Speech speech = new BDDoctors.DAL.DataObject.Speech();
                    speech.User2Id = LoginHandler.LoggedInUser().Id.Value;
                    speech.User2DisplayName = LoginHandler.LoggedInUser().DisplayName;                   
                    speech.User1Id = ObjSender.Id;
                    speech.User1DisplayName = ObjSender.DisplayName;
                    speech.WindowStatus = 1;
                    speech.IsDelivered = 0;
                    speech.Message = GetAppendMessageMarkup(ObjSender, "", Message);
                    speech.LastModifiedDate = DateTime.Now;
                    AddSpeechToTheSpeecList(speech);

                }
                else if (Speeches.ToList<DAL.DataObject.Speech>().Count > 1)
                {
                    throw new ArgumentException("More than instance created which is unexpected");
                }

            }
            return GetAllUnDeliveredSpeechesForThisUser(LoginHandler.LoggedInUser().Id.Value);

        }

       private static string GetAppendMessageMarkup(DAL.DataObject.User Sender, String CurrentMessage, string newMessage)
       {
           string Output=string.Empty;
           if (newMessage.Length < 1)
           {
               return CurrentMessage;
           }
           Output = CurrentMessage + 
            "<div class=\"speech-box\">"+
                " <div class=\"speech-sender\">"+
                    LoginHandler.LoggedInUser().DisplayName+
                "</div>"+
                "<div class=\"action-time\">"
                  +" " + // +DateTime.Now.ToShortTimeString() +
                "</div>"+
                 "<div class=\"speech\">"
                    +  newMessage +
                "</div>" +
            "</div>";
           if (Output.Length > 600)
           { 
            
           }

           return Output;
       }

       public static System.Collections.Generic.List<DAL.DataObject.Speech> DeleteSpeechWithThisUser(Int64 MyId, Int32 UserId)
       {
           System.Collections.Generic.IEnumerable<DAL.DataObject.Speech> Speeches = from DAL.DataObject.Speech sph in m_Speech
                                                                                    where (sph.User1Id == MyId && sph.User2Id==UserId)
                                                                                    select sph;
           if (Speeches.ToList<DAL.DataObject.Speech>().Count == 1)
           {
               foreach (DAL.DataObject.Speech Speech in Speeches.ToList<DAL.DataObject.Speech>())
               {
                   m_Speech.Remove(Speech);
               }
           }

           return GetAllUnDeliveredSpeechesForThisUser(MyId);
       }
       public static System.Collections.Generic.List<DAL.DataObject.Speech> SendInstanceFriendRequestToThisUser(Int32 UserId, string UserDisplayName)
       {

           try {
           
           DAL.DataObject.FriendShip frndship=DAL.DataAccess.FriendShip.GetFriendShipStatusBetweenThem(UserId, LoginHandler.LoggedInUser().Id.Value);




           DAL.DataObject.User ObjSender = new BDDoctors.DAL.DataObject.User();
           ObjSender.Id = UserId;
           ObjSender.DisplayName = UserDisplayName;

           System.Collections.Generic.IEnumerable<DAL.DataObject.Speech> Speeches;

           Speeches = from DAL.DataObject.Speech sph in m_Speech
                      where ((sph.User1Id.Value == LoginHandler.LoggedInUser().Id.Value) && (sph.User2Id.Value == UserId))
                      select sph;

           if (Speeches.ToList<DAL.DataObject.Speech>().Count == 1)
           {
               foreach (DAL.DataObject.Speech Speech in Speeches.ToList<DAL.DataObject.Speech>())
               {
                   Speech.IsDelivered = 0;
                   if (frndship == null) 
                   {
                       DAL.DataObject.FriendShip frnship = new DAL.DataObject.FriendShip();
                       frnship.User1 = LoginHandler.LoggedInUser().Id;
                       frnship.User2 = UserId;
                       frnship.Status = 0;
                       frnship.ActionDate = DateTime.Now;
                       DAL.DataAccess.FriendShip.SaveFriendShip(frnship);
                       Speech.Message = Speech.Message + "<div class=\"instant-request\"> " + ObjSender.DisplayName + " has to confirm that you are friend</div>";
                   }
                   else if (frndship.Status == 1)
                   {
                       Speech.Message = Speech.Message + "<div class=\"instant-request\"> " + ObjSender.DisplayName + " is  already in your friend list</div>";

                   }
                   else if (frndship.Status == 0 && frndship.User1==UserId)
                   {
                       Speech.Message = Speech.Message + "<div class=\"instant-request\"> " + ObjSender.DisplayName + " has already requested you to be his friend. Check your friend Request list to accept request</div>";  
                   }
                   else if (frndship.Status == 0 && frndship.User2 == UserId)
                   {
                       Speech.Message = Speech.Message + "<div class=\"instant-request\"> You have already requested " + ObjSender.DisplayName + " to be your friend</div>";
                   }


                   
                   Speech.LastModifiedDate = DateTime.Now;
               }
           }
           else if (Speeches.ToList<DAL.DataObject.Speech>().Count == 0)
           {
               DAL.DataObject.Speech speech = new BDDoctors.DAL.DataObject.Speech();
               speech.User1Id = LoginHandler.LoggedInUser().Id.Value;
               speech.User1DisplayName = LoginHandler.LoggedInUser().DisplayName;
               speech.User2Id = ObjSender.Id;
               speech.User2DisplayName = ObjSender.DisplayName;
               speech.WindowStatus = 1;
               speech.IsDelivered = 0;
               //speech.Message = speech.Message + "<div class=\"instant-request\"> " + ObjSender.DisplayName + " has to confirm that you are friend</div>";

               if (frndship == null)
               {
                   speech.Message = speech.Message + "<div class=\"instant-request\"> " + ObjSender.DisplayName + " has to confirm that you are friend</div>";
               }
               else if (frndship.Status == 1)
               {
                   speech.Message = speech.Message + "<div class=\"instant-request\"> " + ObjSender.DisplayName + " is  already in your friend list</div>";

               }
               else if (frndship.Status == 0 && frndship.User1 == UserId)
               {
                   speech.Message = speech.Message + "<div class=\"instant-request\"> " + ObjSender.DisplayName + " has already requested you to be his friend. Check your friend Request list to accept request</div>";
               }
               else if (frndship.Status == 0 && frndship.User2 == UserId)
               {
                   speech.Message = speech.Message + "<div class=\"instant-request\"> You have already requested " + ObjSender.DisplayName + " to be your friend</div>";
               }

               speech.LastModifiedDate = DateTime.Now;

               AddSpeechToTheSpeecList(speech);

           }
           else if (Speeches.ToList<DAL.DataObject.Speech>().Count > 1)
           {
               throw new ArgumentException("More than one instance created which is unexpected");
           }

           if (frndship == null) 
           {
              
           
          
               Speeches = from DAL.DataObject.Speech sph in m_Speech
                          where ((sph.User2Id.Value == LoginHandler.LoggedInUser().Id.Value) && (sph.User1Id.Value == UserId))
                          select sph;

               if (Speeches.ToList<DAL.DataObject.Speech>().Count == 1)
               {
                   foreach (DAL.DataObject.Speech Speech in Speeches.ToList<DAL.DataObject.Speech>())
                   {
                       Speech.IsDelivered = 0;
                       Speech.Message = Speech.Message + "<div class=\"instant-request\">" + LoginHandler.LoggedInUser().DisplayName + " has requested you to be his friend.Would you like to be his friend?<span class=\"friendConfirm\" onclick=\"ConfirmFriend(" + LoginHandler.LoggedInUser().Id.ToString() + ");\" >YES</span><span onclick=\"RejectFriend(" + LoginHandler.LoggedInUser().DisplayName + ");\">NO</span>";

                       Speech.LastModifiedDate = DateTime.Now;
                   }
               }
               else if (Speeches.ToList<DAL.DataObject.Speech>().Count == 0)
               {
                   DAL.DataObject.Speech speech = new BDDoctors.DAL.DataObject.Speech();
                   speech.User2Id = LoginHandler.LoggedInUser().Id.Value;
                   speech.User2DisplayName = LoginHandler.LoggedInUser().DisplayName;
                   speech.User1Id = ObjSender.Id;
                   speech.User1DisplayName = ObjSender.DisplayName;
                   speech.WindowStatus = 1;
                   speech.IsDelivered = 0;

                   speech.Message = speech.Message + "<div class=\"instant-request\">" + LoginHandler.LoggedInUser().DisplayName + " has requested you to be his friend.Would you like to be his friend?<span class=\"friendConfirm\" onclick=\"ConfirmFriend(" + LoginHandler.LoggedInUser().Id.ToString() + ");\" >YES</span><span onclick=\"RejectFriend(" + LoginHandler.LoggedInUser().DisplayName + ");\">NO</span>";

                   speech.LastModifiedDate = DateTime.Now;
                   AddSpeechToTheSpeecList(speech);

               }
               else if (Speeches.ToList<DAL.DataObject.Speech>().Count > 1)
               {
                   throw new ArgumentException("More than instance created which is unexpected");
               }

           }
           }
           catch (Exception e)
           {
           }
           return GetAllUnDeliveredSpeechesForThisUser(LoginHandler.LoggedInUser().Id.Value);
           
       }


       public static System.Collections.Generic.List<DAL.DataObject.Speech> ConfirmedAsFriend(Int32 UserId)
       {
           DAL.DataObject.User ObjRequester = DAL.DataAccess.User.GetUser(UserId);
           DAL.DataObject.FriendShip frndShip=new BDDoctors.DAL.DataObject.FriendShip();
           frndShip.User1=ObjRequester.Id.Value;
           frndShip.User2=LoginHandler.LoggedInUser().Id.Value;
           frndShip.Status=1;

           if (DAL.DataAccess.FriendShip.SaveFriendShip(frndShip) == false) 
           {
             return  GetAllUnDeliveredSpeechesForThisUser(LoginHandler.LoggedInUser().Id.Value);
           }
            

           System.Collections.Generic.IEnumerable<DAL.DataObject.Speech> Speeches;

           Speeches = from DAL.DataObject.Speech sph in m_Speech
                      where ((sph.User1Id.Value == LoginHandler.LoggedInUser().Id.Value) && (sph.User2Id.Value == UserId))
                      select sph;

           if (Speeches.ToList<DAL.DataObject.Speech>().Count == 1)
           {
               foreach (DAL.DataObject.Speech Speech in Speeches.ToList<DAL.DataObject.Speech>())
               {
                   Speech.IsDelivered = 0;
                   Speech.Message = Speech.Message + "<div class=\"instant-reply\"> you have accepted  " + ObjRequester.DisplayName + " as your friend</div>";
                   Speech.LastModifiedDate = DateTime.Now;
               }
           }
           else if (Speeches.ToList<DAL.DataObject.Speech>().Count == 0)
           {
               DAL.DataObject.Speech speech = new BDDoctors.DAL.DataObject.Speech();
               speech.User1Id = LoginHandler.LoggedInUser().Id.Value;
               speech.User1DisplayName = LoginHandler.LoggedInUser().DisplayName;
               speech.User2Id = ObjRequester.Id;
               speech.User2DisplayName = ObjRequester.DisplayName;
               speech.WindowStatus = 1;
               speech.IsDelivered = 0;
               speech.Message = speech.Message + "<div class=\"instant-reply\"> you have accepted " + ObjRequester.DisplayName + " as your friend</div>";
               speech.LastModifiedDate = DateTime.Now;

               AddSpeechToTheSpeecList(speech);

           }
           else if (Speeches.ToList<DAL.DataObject.Speech>().Count > 1)
           {
               throw new ArgumentException("More than one instance created which is unexpected");
           }



           Speeches = from DAL.DataObject.Speech sph in m_Speech
                      where ((sph.User2Id.Value == LoginHandler.LoggedInUser().Id.Value) && (sph.User1Id.Value == UserId))
                      select sph;

           if (Speeches.ToList<DAL.DataObject.Speech>().Count == 1)
           {
               foreach (DAL.DataObject.Speech Speech in Speeches.ToList<DAL.DataObject.Speech>())
               {
                   Speech.IsDelivered = 0;
                   Speech.Message = Speech.Message + "<div class=\"instant-reply\"> " + LoginHandler.LoggedInUser().DisplayName.ToString() + " has accepted  you as his friend</div>";

                   Speech.LastModifiedDate = DateTime.Now;
               }
           }
           else if (Speeches.ToList<DAL.DataObject.Speech>().Count == 0)
           {
               DAL.DataObject.Speech speech = new BDDoctors.DAL.DataObject.Speech();
               speech.User2Id = LoginHandler.LoggedInUser().Id.Value;
               speech.User2DisplayName = LoginHandler.LoggedInUser().DisplayName;
               speech.User1Id = ObjRequester.Id;
               speech.User1DisplayName = ObjRequester.DisplayName;
               speech.WindowStatus = 1;
               speech.IsDelivered = 0;

               speech.Message = speech.Message + "<div class=\"instant-reply\"> " + LoginHandler.LoggedInUser().DisplayName + "has accepted you as his friend</div>";


               speech.LastModifiedDate = DateTime.Now;
               AddSpeechToTheSpeecList(speech);

           }
           else if (Speeches.ToList<DAL.DataObject.Speech>().Count > 1)
           {
               throw new ArgumentException("More than instance created which is unexpected");
           }


           return GetAllUnDeliveredSpeechesForThisUser(LoginHandler.LoggedInUser().Id.Value);

       }
    }




}
