using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_HSFElement : Page
{
    private readonly HSFElementD ele = new HSFElementD();

    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = ele.Query(null);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        string name = TextBox1.Text;
        GridView1.DataSource = ele.Query(name);
        GridView1.DataBind();
        GridView1.SelectedIndex = -1;
        UpdatePanel2.Update();
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }

    private void Bind()
    {
        string name = TextBox1.Text;
        GridView1.DataSource = ele.Query(name);
        GridView1.DataBind();
        UpdatePanel2.Update();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;
            GridView1.SelectedIndex = row.RowIndex;
            Label1.Text = "修改";

            TextBox11.Text = row.Cells[1].Text;

            if (row.Cells[2].Text != "禁用")
            {
                int length = row.Cells[2].Text.Length;
                TextBox12.Text = row.Cells[2].Text.Substring(4, length - 4);
                if (row.Cells[2].Text.Substring(0, 4) == "&lt;")
                {
                    DropDownList4.SelectedIndex = DropDownList4.Items.IndexOf(DropDownList4.Items.FindByText("小于"));
                }
                if (row.Cells[2].Text.Substring(0, 4) == "&gt;")
                {
                    DropDownList4.SelectedIndex = DropDownList4.Items.IndexOf(DropDownList4.Items.FindByText("大于"));
                }
            }

            TextBox13.Text = row.Cells[3].ToolTip;
            TextBox14.Text = row.Cells[6].ToolTip;
            ElementID.Text = e.CommandArgument.ToString();
            Panel3.Visible = true;
            UpdatePanel3.Update();
        }
        if (e.CommandName == "Del")
        {
            ele.DeleteElement(new Guid(e.CommandArgument.ToString()));
            Bind();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");   // refer to the TextBox with the NewPageIndex value
            }

            if (null != txtNewPageIndex && txtNewPageIndex.Text != "")
            {
                newPageIndex = int.Parse(txtNewPageIndex.Text) - 1; // get the NewPageIndex
            }
        }
        else
        {
            newPageIndex = e.NewPageIndex;
        }
        
      Bind();
      newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ?GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
       Bind();
    }

    protected void Summit_Click(object sender, EventArgs e)
    {
        if (Label1.Text == "新增")

        {
            string name = TextBox11.Text;
            string standard = "";
            if (TextBox12.Text == "")
            {
                standard = "禁用";
            }
            else
            {
                standard = DropDownList4.SelectedValue + TextBox12.Text;
            }

            string obj = TextBox13.Text;
            string note = TextBox14.Text;
            int a = ele.InsertElement(name, standard, obj, Session["UserName"].ToString(), note);
            if (a == 1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('新增成功！')",
                    true);
                Panel3.Visible = false;
                UpdatePanel3.Update();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('失败了诶...')",
                    true);
                Panel3.Visible = false;
                UpdatePanel3.Update();
            }
            GridView1.DataSource = ele.Query("");
            GridView1.DataBind();
            UpdatePanel2.Update();
        }
        else
        {
            var id = new Guid(ElementID.Text);
            string name = TextBox11.Text;
            string standard = "";
            if (TextBox12.Text == "")
            {
                standard = "禁用";
            }
            else
            {
                standard = DropDownList4.SelectedValue + TextBox12.Text;
            }

            string obj = TextBox13.Text;
            string note = TextBox14.Text;
            int a = ele.UpdateElement(id, name, standard, obj, Session["UserName"].ToString(), note);
            if (a == 1)
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('更新成功！')",
                    true);
                Panel3.Visible = false;
                UpdatePanel3.Update();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('失败了诶...')",
                    true);
                Panel3.Visible = false;
                UpdatePanel3.Update();
            }
            GridView1.DataSource = ele.Query("");
            GridView1.DataBind();
            UpdatePanel2.Update();
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[3].Text.Length > 12)
            {
                e.Row.Cells[3].ToolTip = e.Row.Cells[3].Text;
                e.Row.Cells[3].Text = e.Row.Cells[3].Text.Substring(0, 12);
            }
            if (e.Row.Cells[4].Text.Length > 12)
            {
                e.Row.Cells[6].ToolTip = e.Row.Cells[6].Text;
                e.Row.Cells[6].Text = e.Row.Cells[6].Text.Substring(0, 12);
            }
        }
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        Label1.Text = "新增";
        TextBox11.Text = "";
        TextBox12.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        Panel3.Visible = true;
        UpdatePanel3.Update();
    }

    protected void close_Click(object sender, EventArgs e)
    {
        Panel3.Visible = false;
        UpdatePanel3.Update();
    }
}