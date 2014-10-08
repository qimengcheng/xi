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
        GridView2.DataSource = lpp.Query_HSF(TextBox23.Text, TextBox24.Text);
        GridView2.DataBind();
        Panel3.Visible = true;
    }

    private void Bindgrid2()
    {
        GridView2.DataSource = lpp.Query_HSF(TextBox23.Text, TextBox24.Text);
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
        TextBox22.Text = "";
        TextBox23.Text = "";
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
       
        Response.Redirect("~/report_cc/HSFInfoPrint.aspx?name=" + TextBox22.Text + "&provider=" +
                          TextBox23.Text);
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
            var rohs = e.Row.Cells[6].FindControl("rohs") as GridView;
            if (lpp.Query_HSFInfoReport(new Guid(GridView2.DataKeys[e.Row.RowIndex].Value.ToString()), "ROHS").Tables[0].Rows.Count > 0)
            {
                rohs.DataSource = lpp.Query_HSFInfoReport(new Guid(GridView2.DataKeys[e.Row.RowIndex].Value.ToString()), "ROHS");
                rohs.DataBind();
            }
            else
            {
                var dt = new DataTable();
                DataRow dr = dt.NewRow();
                var dc = new DataColumn();
                var dc2 = new DataColumn();
                var dc3 = new DataColumn();
                dc.ColumnName = "HSFReport_Num";
                dc2.ColumnName = "HSFReport_Organization";
                dc3.ColumnName = "HSFReport_Type";
                dt.Columns.Add(dc);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dr[0] = "无对应报告";
                dr[1] = "无对应报告";
                dr[2] = "无对应报告";

                dt.Rows.Add(dr);
                var ds = new DataSet();
                ds.Tables.Add(dt);
                rohs.DataSource = ds;
                rohs.DataBind();
            }


            var reach = e.Row.Cells[7].FindControl("reach") as GridView;
            if (lpp.Query_HSFInfoReport(new Guid(GridView2.DataKeys[e.Row.RowIndex].Value.ToString()), "REACH").Tables[0].Rows.Count > 0)
            {
                reach.DataSource = lpp.Query_HSFInfoReport(new Guid(GridView2.DataKeys[e.Row.RowIndex].Value.ToString()), "REACH");
                reach.DataBind();
            }
            else
            {
                var dt = new DataTable();
                DataRow dr = dt.NewRow();
                var dc = new DataColumn();
                var dc2 = new DataColumn();
                var dc3 = new DataColumn();
                dc.ColumnName = "HSFReport_Num";
                dc2.ColumnName = "HSFReport_Organization";
                dc3.ColumnName = "HSFReport_Type";
                dt.Columns.Add(dc);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dr[0] = "无对应报告";
                dr[1] = "无对应报告";
                dr[2] = "无对应报告";

                dt.Rows.Add(dr);
                var ds = new DataSet();
                ds.Tables.Add(dt);
                reach.DataSource = ds;
                reach.DataBind();
            }

            var cl = e.Row.Cells[8].FindControl("cl") as GridView;
            if (lpp.Query_HSFInfoReport(new Guid(GridView2.DataKeys[e.Row.RowIndex].Value.ToString()), "卤素").Tables[0].Rows.Count > 0)
            {
                cl.DataSource = lpp.Query_HSFInfoReport(new Guid(GridView2.DataKeys[e.Row.RowIndex].Value.ToString()), "卤素");
                cl.DataBind();
            }
            else
            {
                var dt = new DataTable();
                DataRow dr = dt.NewRow();
                var dc = new DataColumn();
                var dc2 = new DataColumn();
                var dc3 = new DataColumn();
                dc.ColumnName = "HSFReport_Num";
                dc2.ColumnName = "HSFReport_Organization";
                dc3.ColumnName = "HSFReport_Type";
                dt.Columns.Add(dc);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dr[0] = "无对应报告";
                dr[1] = "无对应报告";
                dr[2] = "无对应报告";

                dt.Rows.Add(dr);
                var ds = new DataSet();
                ds.Tables.Add(dt);
                cl.DataSource = ds;
                cl.DataBind();
            }

            var br = e.Row.Cells[9].FindControl("br") as GridView;
            if (lpp.Query_HSFInfoReport(new Guid(GridView2.DataKeys[e.Row.RowIndex].Value.ToString()), "六溴環十二烷").Tables[0].Rows.Count > 0)
            {
                br.DataSource = lpp.Query_HSFInfoReport(new Guid(GridView2.DataKeys[e.Row.RowIndex].Value.ToString()), "六溴環十二烷");
                br.DataBind();
            }
            else
            {
                var dt = new DataTable();
                DataRow dr = dt.NewRow();
                var dc = new DataColumn();
                var dc2 = new DataColumn();
                var dc3 = new DataColumn();
                dc.ColumnName = "HSFReport_Num";
                dc2.ColumnName = "HSFReport_Organization";
                dc3.ColumnName = "HSFReport_Type";
                dt.Columns.Add(dc);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dr[0] = "无对应报告";
                dr[1] = "无对应报告";
                dr[2] = "无对应报告";

                dt.Rows.Add(dr);
                var ds = new DataSet();
                ds.Tables.Add(dt);
                br.DataSource = ds;
                br.DataBind();
            }

            var c = e.Row.Cells[10].FindControl("c") as GridView;
            if (lpp.Query_HSFInfoReport(new Guid(GridView2.DataKeys[e.Row.RowIndex].Value.ToString()), "鄰苯二甲酸酯类").Tables[0].Rows.Count > 0)
            {
                c.DataSource = lpp.Query_HSFInfoReport(new Guid(GridView2.DataKeys[e.Row.RowIndex].Value.ToString()), "鄰苯二甲酸酯类");
                c.DataBind();
            }
            else
            {
                var dt = new DataTable();
                DataRow dr = dt.NewRow();
                var dc = new DataColumn();
                var dc2 = new DataColumn();
                var dc3 = new DataColumn();
                dc.ColumnName = "HSFReport_Num";
                dc2.ColumnName = "HSFReport_Organization";
                dc3.ColumnName = "HSFReport_Type";
                dt.Columns.Add(dc);
                dt.Columns.Add(dc2);
                dt.Columns.Add(dc3);
                dr[0] = "无对应报告";
                dr[1] = "无对应报告";
                dr[2] = "无对应报告";

                dt.Rows.Add(dr);
                var ds = new DataSet();
                ds.Tables.Add(dt);
                c.DataSource = ds;
                c.DataBind();
            }
        

            
        }
    }

    protected void ROHS_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow main = e.Row.Parent.Parent.Parent.Parent as GridViewRow;
            SqlDataReader reader = lpp.Query_HSFInfoNet(new Guid(main.Cells[0].Text), "ROHS");
            var dt = new DataTable();
            int i = 0;
            DataRow dr = dt.NewRow();
            while (reader.Read())
            {
                var dc = new DataColumn();
                dc.ColumnName = reader["HSFElement_Name"].ToString();
                dt.Columns.Add(dc);
                dr[i] = reader["HSFDetail_Net"].ToString();
                i++;
            }
            dt.Rows.Add(dr);
            var ds = new DataSet();
            ds.Tables.Add(dt);
            var gv = e.Row.Cells[3].FindControl("rohsdetail") as GridView;
            gv.DataSource = ds;
            gv.DataBind();
        }
    }
    protected void REACH_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow main = e.Row.Parent.Parent.Parent.Parent as GridViewRow;
            SqlDataReader reader = lpp.Query_HSFInfoNet(new Guid(main.Cells[0].Text), "reach");
            var dt = new DataTable();
            int i = 0;
            DataRow dr = dt.NewRow();
            while (reader.Read())
            {
                var dc = new DataColumn();
                dc.ColumnName = reader["HSFElement_Name"].ToString();
                dt.Columns.Add(dc);
                dr[i] = reader["HSFDetail_Net"].ToString();
                i++;
            }
            dt.Rows.Add(dr);
            var ds = new DataSet();
            ds.Tables.Add(dt);
            var gv = e.Row.Cells[3].FindControl("reachdetail") as GridView;
            gv.DataSource = ds;
            gv.DataBind();
        }
    }
    protected void CL_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow main = e.Row.Parent.Parent.Parent.Parent as GridViewRow;
            SqlDataReader reader = lpp.Query_HSFInfoNet(new Guid(main.Cells[0].Text), "卤素");
            var dt = new DataTable();
            int i = 0;
            DataRow dr = dt.NewRow();
            while (reader.Read())
            {
                var dc = new DataColumn();
                dc.ColumnName = reader["HSFElement_Name"].ToString();
                dt.Columns.Add(dc);
                dr[i] = reader["HSFDetail_Net"].ToString();
                i++;
            }
            dt.Rows.Add(dr);
            var ds = new DataSet();
            ds.Tables.Add(dt);
            var gv = e.Row.Cells[3].FindControl("cldetail") as GridView;
            gv.DataSource = ds;
            gv.DataBind();
        }
    }
    protected void BR_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow main = e.Row.Parent.Parent.Parent.Parent as GridViewRow;
            SqlDataReader reader = lpp.Query_HSFInfoNet(new Guid(main.Cells[0].Text), "六溴环十二烷");
            var dt = new DataTable();
            int i = 0;
            DataRow dr = dt.NewRow();
            while (reader.Read())
            {
                var dc = new DataColumn();
                dc.ColumnName = reader["HSFElement_Name"].ToString();
                dt.Columns.Add(dc);
                dr[i] = reader["HSFDetail_Net"].ToString();
                i++;
            }
            dt.Rows.Add(dr);
            var ds = new DataSet();
            ds.Tables.Add(dt);
            var gv = e.Row.Cells[3].FindControl("brdetail") as GridView;
            gv.DataSource = ds;
            gv.DataBind();
        }
    }
    protected void C_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridViewRow main = e.Row.Parent.Parent.Parent.Parent as GridViewRow;
            SqlDataReader reader = lpp.Query_HSFInfoNet(new Guid(main.Cells[0].Text), "鄰苯二甲酸酯类");
            var dt = new DataTable();
            int i = 0;
            DataRow dr = dt.NewRow();
            while (reader.Read())
            {
                var dc = new DataColumn();
                dc.ColumnName = reader["HSFElement_Name"].ToString();
                dt.Columns.Add(dc);
                dr[i] = reader["HSFDetail_Net"].ToString();
                i++;
            }
            dt.Rows.Add(dr);
            var ds = new DataSet();
            ds.Tables.Add(dt);
            var gv = e.Row.Cells[3].FindControl("cdetail") as GridView;
            gv.DataSource = ds;
            gv.DataBind();
        }
    }
   
}