using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace BDDoctors
{
    /// <summary>
    /// Summary description for GetMedicalCollege
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class GetMedicalCollege : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        public static string[] GetCompletionListWithContextAndValues(string prefixText, int count, string contextKey)
        {
            System.Collections.Generic.List<string> items = new System.Collections.Generic.List<string>(GetCompletionListWithContext(prefixText, count, contextKey));
            for (int i = 0; i < items.Count; i++)
            {
                items[i] = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(items[i], i.ToString());
            }
            return items.ToArray();
        }
        public static string[] GetCompletionListWithContext(string prefixText, int count, string contextKey)
        {
            if (contextKey != null)
                return "this is a total of fifteen words that will be returned when we use context".Split(' ');

            if (count == 0)
            {
                count = 10;
            }

            if (prefixText.Equals("xyz"))
            {
                return new string[0];
            }

            ArrayList items = new ArrayList(count);
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                char c1 = (char)random.Next(65, 90);
                char c2 = (char)random.Next(97, 122);
                char c3 = (char)random.Next(97, 122);

                items.Add(prefixText + c1 + c2 + c3);
            }

            return (string[])items.ToArray(typeof(string));
        }

    }
}
