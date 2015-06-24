using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public class ValidateEditItem : ITemplate
{
    private string column;

    public ValidateEditItem(string column)
    {
        this.column = column;
    }

    public void BindData(object sender, EventArgs e)
    {
        TextBox box = (TextBox) sender;
        DataGridItem namingContainer = (DataGridItem) box.NamingContainer;
        box.Text = ((DataRowView) namingContainer.DataItem)[this.column].ToString();
    }

    public void InstantiateIn(Control container)
    {
        TextBox child = new TextBox();
        child.DataBinding += new EventHandler(this.BindData);
        container.Controls.Add(child);
        child.ID = this.column;
        RequiredFieldValidator validator = new RequiredFieldValidator {
            Text = "Please Answer",
            ControlToValidate = child.ID,
            Display = ValidatorDisplay.Dynamic,
            ID = "validate" + child.ID
        };
        container.Controls.Add(validator);
    }
}

