namespace QxRoom.Common.ControlDo
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public sealed class PageDo
    {
        public static bool IsChanged(ref string strEditMess, bool IsSaveTitle, Page page)
        {
            bool yn = false;
            for (int i = 0; i < page.Controls.Count; i++)
            {
                foreach (Control control in page.Controls[i].Controls)
                {
                    if (control.HasControls())
                    {
                        IsChanged(ref yn, ref strEditMess, control, control.Controls, IsSaveTitle, page);
                    }
                    else
                    {
                        IsChanged(ref yn, ref strEditMess, page, control, IsSaveTitle, page);
                    }
                }
            }
            return yn;
        }

        public static void IsChanged(ref bool yn, ref string strEditMess, Control parcontrol, Control control, bool IsSaveTitle, Page page)
        {
            if ((control.ID != null) && (control.ID.IndexOf("_bak") > 0))
            {
                string text = "";
                if (IsSaveTitle)
                {
                    string str2 = "lab" + control.ID.Remove(0, 3);
                    Label label = (Label) parcontrol.FindControl(str2.Replace("_bak", ""));
                    if (label != null)
                    {
                        text = label.Text;
                    }
                }
                if (control is TextBox)
                {
                    TextBox box = (TextBox) parcontrol.FindControl(control.ID.Replace("_bak", ""));
                    TextBox box2 = (TextBox) control;
                    if (((box != null) && (box2 != null)) && (box.Text != box2.Text))
                    {
                        string str3 = strEditMess;
                        strEditMess = str3 + text + " 从 " + box2.Text + " 改为 " + box.Text + " ~ ";
                        yn = true;
                    }
                }
                if (control is HtmlInputHidden)
                {
                    HtmlInputHidden hidden = (HtmlInputHidden) parcontrol.FindControl(control.ID.Replace("_bak", ""));
                    HtmlInputHidden hidden2 = (HtmlInputHidden) control;
                    if (((hidden != null) && (hidden2 != null)) && (hidden.Value != hidden2.Value))
                    {
                        string str4 = strEditMess;
                        strEditMess = str4 + text + " 从 " + hidden2.Value + " 改为 " + hidden.Value + " ~ ";
                        yn = true;
                    }
                }
            }
        }

        public static void IsChanged(ref bool yn, ref string strEditMess, Control parcontrol, ControlCollection controls, bool IsSaveTitle, Page page)
        {
            foreach (Control control in controls)
            {
                if (control.HasControls())
                {
                    IsChanged(ref yn, ref strEditMess, control, control.Controls, IsSaveTitle, page);
                }
                else
                {
                    IsChanged(ref yn, ref strEditMess, parcontrol, control, IsSaveTitle, page);
                }
            }
        }
    }
}

