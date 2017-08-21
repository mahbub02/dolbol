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

namespace BDDoctors.DAL
{
    public class Common
    {
       public static Nullable< Int64> ToInt64(object obj)
       {
           if (obj is DBNull)
           {
               return null;
              
           }
           else { return Convert.ToInt64(obj); }
       }
       public static Nullable<Int32> ToInt32(object obj)
       {
           if (obj is DBNull)
           {
               return null;

           }
           else { return Convert.ToInt32(obj); }
       }
       public static Nullable<Int16> ToInt16 (object obj)
       {
           if (obj is DBNull)
           {
               return null;

           }
           else { return Convert.ToInt16(obj); }
       }
       public static Nullable<DateTime> ToDateTime(object obj)
       {
           if (obj is DBNull)
           {
               return null;

           }
           else { return Convert.ToDateTime(obj); }
       }
       public static  Nullable< Boolean> ToBoolean(object obj)
       {
           if (obj is DBNull)
           {
               return null;

           }
           else { return Convert.ToBoolean(obj); }
       }
       public static Boolean ToBool(object obj)
       {
           if (obj is DBNull)
           {
               return false;

           }
           else { return Convert.ToBoolean(obj); }
       }
       public static String ToString(object obj)
       {
           if (obj is DBNull)
           {
               return null;

           }
           else { return Convert.ToString(obj); }
       }
       public static String GetString(object obj)
       {
           if (obj is Nullable)
           {
               return "";

           }
           else { return Convert.ToString(obj); }
       }
       public static Int64 GetValueFromNull(object obj)
       {
           if (obj == null)
           {
               return 0;
           }
           else { return Convert.ToInt64(obj); }
       }
       public static String GetTextWithBr(string str)
       {
           string Output = string.Empty;
           if (str != null)
           {

               string[] arr = str.Split(' ');
               

               //if (arr.Length == 1)
               //{
               //    Output = arr[0];
               //}
               //else
               //{
                   for (Int64 i = 0; i < arr.Length; i++)
                   {
                       if (arr[i].Length > 30)
                       {
                           Output=Output+" "+ LongWordRemover(arr[i]);
                           
                       }
                       else 
                       {
                           Output = Output +" "+ arr[i];
                       }
                   }
               //}

               return Output.Replace("\n", "<br />").Trim();
           }
           return Output.Trim();
       }
       public static string LongWordRemover(string arr)
       {
           if (arr.Contains("http"))
           {
               return arr;
           }
           string temp=string.Empty;
           //for (Int64 i = 0; i < arr.Length; i++)
           //{

           //    if (arr[i].Length > 20)
           //    {
                   for (int j = 1; j <= Math.Floor( Convert.ToDecimal(arr.Length / 30)); j++)
                   {
                       arr = arr.Insert(30 * j, " ");
                      
                   }

           //    }
           //    temp = temp + arr[i];
           //}
           //return temp;
                   return arr;
       }
       public static String RemoveBrFromText(string str)
       {
           if (str != null)
           {
               return str.Replace("<br />", "\n");
           }
           return str;
           
       }
        
        
      
    }
    
}
