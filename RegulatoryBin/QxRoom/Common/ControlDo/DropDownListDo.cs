namespace QxRoom.Common.ControlDo
{
    using System;
    using System.Web.UI.WebControls;

    public sealed class DropDownListDo
    {
        public static void BandData_Text(ref DropDownList ddl)
        {
            DropDownList list = new DropDownList();
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                int num2 = 0;
                if (list.Items.Count > 0)
                {
                    for (int k = 0; k < list.Items.Count; k++)
                    {
                        if (ddl.Items[i].Text == list.Items[k].Text)
                        {
                            num2++;
                            break;
                        }
                    }
                }
                if (num2 == 0)
                {
                    list.Items.Add(ddl.Items[i]);
                }
            }
            ddl.Items.Clear();
            for (int j = 0; j < list.Items.Count; j++)
            {
                ddl.Items.Add(list.Items[j]);
            }
        }

        public static void BandData_Value(ref DropDownList ddl)
        {
            DropDownList list = new DropDownList();
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                int num2 = 0;
                if (list.Items.Count > 0)
                {
                    for (int k = 0; k < list.Items.Count; k++)
                    {
                        if (ddl.Items[i].Value == list.Items[k].Value)
                        {
                            num2++;
                            break;
                        }
                    }
                }
                if (num2 == 0)
                {
                    list.Items.Add(ddl.Items[i]);
                }
            }
            ddl.Items.Clear();
            for (int j = 0; j < list.Items.Count; j++)
            {
                ddl.Items.Add(list.Items[j]);
            }
        }

        public static void BindData(ref DropDownList ddl, object obj, string text, string value)
        {
            ddl.DataSource = obj;
            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataBind();
        }

        public static void CopyData(ref DropDownList ddl_new, DropDownList ddl_old, DropDownListCopyType ddlct, string tj)
        {
            ddl_new.Items.Clear();
            for (int i = 0; i < ddl_old.Items.Count; i++)
            {
                switch (ddlct)
                {
                    case DropDownListCopyType.Value:
                        if (ddl_old.Items[i].Value == tj)
                        {
                            ddl_new.Items.Add(ddl_old.Items[i]);
                        }
                        break;

                    case DropDownListCopyType.Text:
                        if (ddl_old.Items[i].Text == tj)
                        {
                            ddl_new.Items.Add(ddl_old.Items[i]);
                        }
                        break;
                }
            }
        }
    }
}

