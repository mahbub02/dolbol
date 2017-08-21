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
using BDDoctors.Controls;


namespace BDDoctors
{
    public class UIhelper
    {
        public static void PopulateDropDown(DropDownList dl, Int64 source_id,String SelectedText)
        {
            System.Collections.Generic.List<String> itemList= DAL.DataAccess.Node.GetSourceTextList(source_id);
            dl.Items.Clear();
            ListItem FirstItem = new ListItem("Select", "-1");
            dl.Items.Add(FirstItem);
            foreach(string str in itemList)
            {
                ListItem li = new ListItem(str, str);
                if (SelectedText == li.Value)
                {
                    li.Selected = true;
                }

                dl.Items.Add(li);
            }
        }
        public static void populateMonth(DropDownList dl,String SelectedText)
        {
            ListItem FirstItem = new ListItem("Month", "-1");
            dl.Items.Add(FirstItem);
            for (int i = 1; i <= 12; i++)
            {
                System.Globalization.DateTimeFormatInfo dinf = new System.Globalization.DateTimeFormatInfo();
                ListItem item = new ListItem(dinf.GetMonthName(i), dinf.GetMonthName(i));
                dl.Items.Add(item);               
            }
            dl.SelectedValue = SelectedText;
            
        }
        public static void populateFromTime(DropDownList dl, String SelectedText)
        {
            ListItem FirstItem = new ListItem("From", "-1");
            dl.Items.Add(FirstItem);
            DateTime starttime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1);
            DateTime endTime = starttime.AddDays(1);
            while (starttime < endTime)
            {
                ListItem item = new ListItem(starttime.ToShortTimeString(),starttime.ToShortTimeString());
                dl.Items.Add(item);
                starttime = starttime.AddMinutes(15);
            }
            dl.SelectedValue = SelectedText;

        }
        public static void populateToTime(DropDownList dl, String SelectedText)
        {
            ListItem FirstItem = new ListItem("To", "-1");
            dl.Items.Add(FirstItem);
            DateTime starttime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 1);
            DateTime endTime = starttime.AddDays(1);
            while (starttime < endTime)
            {
                ListItem item = new ListItem(starttime.ToShortTimeString(), starttime.ToShortTimeString());
                dl.Items.Add(item);
                starttime = starttime.AddMinutes(15);
            }
            dl.SelectedValue = SelectedText;


        }
        public static void PopulateDropDownClassYear(DropDownList dl,String SelectedText)
        {
            
            dl.Items.Clear();
            ListItem liNullValue = new ListItem("Passing year", "-1");
            if (SelectedText == null)
            {
                liNullValue.Selected = true;
            }
            dl.Items.Add(liNullValue);
            for( Int64 i=1910;i<2015;i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                if (SelectedText!=null && SelectedText == li.Value)
                {
                    li.Selected = true;
                }

                dl.Items.Add(li);
            }
        }

        public static void PopulateDropDownYear(DropDownList dl, String SelectedText)
        {

            dl.Items.Clear();
            ListItem liNullValue = new ListItem("Year", "-1");
            if (SelectedText == null)
            {
                liNullValue.Selected = true;
            }
            dl.Items.Add(liNullValue);
            for (Int64 i = 1910; i < 2015; i++)
            {
                ListItem li = new ListItem(i.ToString(), i.ToString());
                if (SelectedText != null && SelectedText == li.Value)
                {
                    li.Selected = true;
                }

                dl.Items.Add(li);
            }
        }
        public static void PopulateRadioList(RadioButtonList dl, Int64 source_id, String SelectedText)
        {
            System.Collections.Generic.List<String> itemList = DAL.DataAccess.Node.GetSourceTextList(source_id);
            dl.Items.Clear();

            foreach (string str in itemList)
            {
                ListItem li = new ListItem(str, str);
                if (SelectedText == li.Value)
                {
                    li.Selected = true;
                }

                dl.Items.Add(li);
            }
        }
        public static void PopulateCheckList(CheckBoxList dl, Int64 source_id,String SelectedText)
        {
            dl.Items.Clear();
            System.Collections.Generic.List<String> itemList = DAL.DataAccess.Node.GetSourceTextList(source_id);
            if (SelectedText == null)
            {
                SelectedText = "";
            }
            String[] strs = SelectedText.Split(',');
            foreach (string str in itemList)
            {
                ListItem li = new ListItem(str, str);
                for (int i = 0; i < strs.Length; i++)
                {
                    if (string.Compare(strs[i], str) == 0)
                    {
                        li.Selected = true;
                    }
                }
                dl.Items.Add(li);
            }
        }
        public static void PopulateDayList(CheckBoxList dl,String SelectedText)
        {

           
            dl.Items.Clear();
            System.Collections.Generic.List<String> itemList=new System.Collections.Generic.List<string>();
            itemList.Add("Sat");
            itemList.Add("Sun");
            itemList.Add("Mon");
            itemList.Add("Tue");
            itemList.Add("Wed");
            itemList.Add("thur");
            itemList.Add("Fri");
            if (SelectedText == null)
            {
                SelectedText = "";
            }
            String[] strs = SelectedText.Split(',');
            foreach (string str in itemList)
            {
                ListItem li = new ListItem(str, str);
                for (int i = 0; i < strs.Length; i++)
                {
                    if (string.Compare(strs[i], str) == 0)
                    {
                        li.Selected = true;
                    }
                }
                dl.Items.Add(li);
            }
        }

        public static void BindNodeWithConrol(Control cntrl, DAL.DataObject.Node Node,BDDoctors.Type.DisplayMood displayMood)
        {
            //ControlBase cb = (ControlBase)cntrl.Page.LoadControl("Controls/DropDown_SingleSelect.ascx");
            //cb.Node = Node;
            //cb.DisplayMood = displayMood;
            //cntrl.Controls.Add(cb);
        }
    }
}
