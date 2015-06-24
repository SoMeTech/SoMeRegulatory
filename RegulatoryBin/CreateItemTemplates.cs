using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public class CreateItemTemplates : ITemplate
{
    private string column;

    public CreateItemTemplates(string column)
    {
        this.column = column;
    }

    public void BindData(object sender, EventArgs e)
    {
        Literal literal = (Literal) sender;
        DataGridItem namingContainer = (DataGridItem) literal.NamingContainer;
        literal.Text = ((DataRowView) namingContainer.DataItem)[this.column].ToString();
    }

    public void InstantiateIn(Control container)
    {
        Literal child = new Literal();
        child.DataBinding += new EventHandler(this.BindData);
        container.Controls.Add(child);
    }
}

