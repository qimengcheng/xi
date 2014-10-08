using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_Default : Page
{
    HSFD hd=new HSFD();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = hd.QueryReportDue(TextBox1.Text, TextBox2.Text, TextBox3.Text);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }
    protected void Search_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = hd.QueryReportDue(TextBox1.Text, TextBox2.Text, TextBox3.Text);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          

            if (Convert.ToInt32(e.Row.Cells[8].Text)<=60)
            {
                e.Row.ForeColor = Color.Firebrick;
            }
        }
    }
}