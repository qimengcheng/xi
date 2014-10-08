using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_ProjectInfoEquipmentPrint: Page
{
    private readonly LaputaPrintPoolD lpp = new LaputaPrintPoolD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if ( Request.QueryString["stime"] == null || Request.QueryString["etime"] == null)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('数据获取异常');", true);
        }
        else
        {
    
            TextBox5.Text = Request.QueryString["stime"];
            TextBox6.Text = Request.QueryString["etime"];
            Label6.Text = Request.QueryString["stime"];
            Label7.Text = Request.QueryString["etime"];
        }
        try
        {
            Label4.Text = Session["UserName"].ToString();
        }
        catch 
        {
            Response.Redirect("~/Default.aspx");
        }
        Label5.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);

        GridView2.DataSource = lpp.Query_ProjectInfoEquipment(Convert.ToDateTime(TextBox5.Text),
             Convert.ToDateTime(TextBox6.Text));
        GridView2.DataBind();
        Panel3.Visible = true;
        
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
            Label3.Text = row.Cells[2].Text;
            Panel2.Visible = false;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }

    protected void SearchInStoreMain(object sender, EventArgs e)
    {
        if (mid.Text == "mid" || TextBox5.Text == "" || TextBox6.Text == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof (Page), "alert", "alert('请选择物料和时间段！');", true);
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

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        Bindgrid2();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;
        theGrid.PageIndex = newPageIndex;
        theGrid.DataBind();
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
     
    }

    protected void ToExcel_Click(object sender, EventArgs e)
    {
        SearchInStoreMain(sender, e);
        GridView2.AllowPaging = false;
        Bindgrid2();
        ExcelHelper.GridViewToExcel(GridView2, TextBox5.Text + "至" + TextBox6.Text + "产品型号合格率");
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
    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/report_cc/ProjectInfoEquipment.aspx");
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Convert.ToInt32(e.Row.Cells[10].Text)>0)
            {
                  SqlDataReader reader = lpp.Query_ProjectReportEquipmentBad(new Guid(e.Row.Cells[0].Text), e.Row.Cells[5].Text, e.Row.Cells[1].Text.Replace("&amp;", "&"), Convert.ToDateTime(TextBox5.Text),
            Convert.ToDateTime(TextBox6.Text));
            var dt = new DataTable();
            int i = 0; DataRow dr = dt.NewRow();
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
}