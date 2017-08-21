using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Xml.Linq;
using System.IO;
using System.Web.SessionState;

namespace BDDoctors
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class StateUpoad : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
             string id=  context.Request["id"];
             string parent_id = context.Request["parent_id"];
             string name = context.Request["name"];
             

            string strFileName = Path.GetFileName(context.Request.Files[0].FileName);
            string strExtension = Path.GetExtension(context.Request.Files[0].FileName).ToLower();
            if (context.Request.Files[0].ContentType.Contains("jpg") || context.Request.Files[0].ContentType.Contains("jpeg") || context.Request.Files[0].ContentType.Contains("bmp"))
            {
                //DAL.DataObject.Node nd = new BDDoctors.DAL.DataObject.Node();
                //nd.Attribute_id = 63;
                //nd.User_id = LoginHandler.LoggedInUser().Id.Value;
                //nd.User_Name = LoginHandler.LoggedInUser().DisplayName;
                //nd.Node_value = "Nothing";
                //System.Collections.Generic.List<DAL.DataObject.Node> Nodes = new System.Collections.Generic.List<BDDoctors.DAL.DataObject.Node>();
                //Nodes.Add(nd);

                //Int64 parentNodeId = DAL.DataAccess.Node.SaveNodes(Nodes);
                //nd.Parent_Node_Id = nd.Id;
                //DAL.DataAccess.Node.SaveNode(nd);
                


                //context.Request.Files[0].SaveAs(context.Server.MapPath("/images/state/") + parentNodeId.ToString());


                //try
                //{
                //    //BDDoctors.ImageHelper.ResizeAndSave(context.Server.MapPath("/images/Node/"), parentNodeId.ToString(), context.Request.Files[0].ContentType);
                //}
                //catch
                //{
                //    DAL.DataAccess.Node.DeleteNodes(parentNodeId);
                //    context.Response.Write("uploadFailed");

                //}
                //context.Response.ContentType = "text/html";
                //context.Response.Write(parentNodeId.ToString());
            }
            else
            {
                context.Response.ContentType = "text/html";
                context.Response.Write("Invalid file type, only jpg,jpeg,bmp type files are supported");
            }







        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
