using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_HSFInfo : Page
{
    private readonly LaputaPrintPoolD lpp = new LaputaPrintPoolD();
    private readonly HSFMaterialElementD me = new HSFMaterialElementD();
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView2.DataSource = me.QueryMaterial("", "");
        GridView2.DataBind();
    }

    protected void Button37_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = lpp.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;

            var id = new Guid(e.CommandArgument.ToString());
            mid.Text = e.CommandArgument.ToString();
            Panel2.Visible = false;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView1.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid1();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView1.PageCount ? GridView1.PageCount - 1 : newPageIndex;
        GridView1.PageIndex = newPageIndex;
        GridView1.DataBind();
    }

    protected void SearchInStoreMain(object sender, EventArgs e)
    {
        if (TextBox5.Text == "" || TextBox6.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('请选择时间段！');", true);
            return;
        }
        GridView2.DataSource = lpp.Query_ProjectInfoEquipment(Convert.ToDateTime(TextBox5.Text),
            Convert.ToDateTime(TextBox6.Text));
        GridView2.DataBind();
        Panel3.Visible = true;
    }

    private void Bindgrid2()
    {
        GridView2.DataSource = lpp.Query_ProjectInfoEquipment(Convert.ToDateTime(TextBox5.Text),
            Convert.ToDateTime(TextBox6.Text));
        GridView2.DataBind();
    }

    private void Bindgrid1()
    {
        GridView1.DataSource = lpp.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView1.DataBind();
        GridView1.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = GridView2.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid2();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= GridView2.PageCount ? GridView2.PageCount - 1 : newPageIndex;
        GridView2.PageIndex = newPageIndex;
        GridView2.DataBind();
    }


    protected void Reset_Click(object sender, EventArgs e)
    {
        mid.Text = "mid";
        TextBox5.Text = "";
        TextBox6.Text = "";
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }


    protected void ChooseMaterial_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        GridView1.DataSource = lpp.Query_Material(TextBox21.Text, TextBox22.Text);
        GridView1.DataBind();
    }

    protected void print(object sender, EventArgs e)
    {
        if (TextBox5.Text == "" || TextBox6.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('请填写时间段！');", true);
            return;
        }
        Response.Redirect("~/report_cc/ProjectInfoEquipmentPrint.aspx?stime=" + TextBox5.Text + "&etime=" +
                          TextBox6.Text);
    }

    protected void searchprotype_Click(object sender, EventArgs e)
    {
        GridView3.DataSource = lpp.Query_ProType(TextBox1.Text, TextBox2.Text);
        GridView3.DataBind();
    }

    protected void ChooseProType_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        GridView3.DataSource = lpp.Query_ProType(TextBox1.Text, TextBox2.Text);
        GridView3.DataBind();
    }

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var theGrid = sender as GridView; // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = theGrid.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox) pagerRow.FindControl("textbox");
                // refer to the TextBox with the NewPageIndex value
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
        Bindgrid3();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        theGrid.DataBind();
    }

    private void Bindgrid3()
    {
        GridView3.DataSource = lpp.Query_ProType(TextBox1.Text, TextBox2.Text);
        GridView3.DataBind();
    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Choose")
        {
            var row = ((LinkButton) e.CommandSource).Parent.Parent as GridViewRow;

            var id = new Guid(e.CommandArgument.ToString());
            mid.Text = e.CommandArgument.ToString();
            Panel1.Visible = false;
        }
    }

    protected void GIG_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var rohs = e.Row.Cells[7].FindControl("rohs") as GridView;
            rohs.DataSource = lpp.Query_HSFInfoReport(new Guid(e.Row.Cells[0].Text), "ROSH");
            rohs.DataBind();

            SqlDataReader reader = lpp.Query_HSFInfoNet(new Guid(e.Row.Cells[0].Text),"ROSH");
            var dt = new DataTable();
            int i = 0;
            DataRow dr = dt.NewRow();
            while (reader.Read())
            {
                var dc = new DataColumn();
                dc.ColumnName = reader["WOBP_Type"].ToString();
                dt.Columns.Add(dc);
                dr[i] = reader["WOBP_Num"].ToString();
                i++;
            }
            dt.Rows.Add(dr);
            var ds = new DataSet();
            ds.Tables.Add(dt);
            var gv = e.Row.Cells[7].FindControl("GIG") as GridView;
            gv.DataSource = ds;
            gv.DataBind();
        }
    }
}