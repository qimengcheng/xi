using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Laputa_SunMasterTypeYearsSeriesPrint : Page
{
    private readonly LaputaPrintPoolD lpp = new LaputaPrintPoolD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if ( Request.QueryString["year"] == null )
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof (Page), "alert", "alert('数据获取异常');", true);
            return;
        }
        else
        {

            DropDownList1.Text = Request.QueryString["year"];
            Label6.Text = Request.QueryString["year"];
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

        GridView2.DataSource = lpp.Query_SunMasterYearSeries(DropDownList1.Text);
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
       
    }

    private void Bindgrid2()
    {
        GridView2.DataSource = lpp.Query_SunMasterYearSeries(DropDownList1.Text);
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
        ExcelHelper.GridViewToExcel(GridView2, Label6.Text+ "年塑封桥、浇灌桥和模块事业部产品产量和合格率趋势图");
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
        Response.Redirect("~/report_cc/SunMasterTypeYearTrendsSeries.aspx");
    }

    protected void Chart1_Load(object sender, EventArgs e)
    {
        //设置图表的数据源

        DataSet ds = lpp.Query_SunMasterTypeMonthTrends();
        //Chart1.DataSource= ds.Tables[0].Select("年份="+DateTime.Now.Year);
        //ChartArea ca=new ChartArea();
        //Series mySeries= new Series();
        //Chart1.ChartAreas.Add(ca);
        //Chart1.Series.Add(mySeries)

        ; //设置图表Y轴对应项

        //Chart1.Series[0].YValueMembers ="出站数";
        //Chart1.Series[2].YValueMembers = "合格率";

        ////设置图表X轴对应项
        //Chart1.Series[0].XValueMember = "月份";
        //Chart1.Series[2].XValueMember = "月份";
        //Chart1.DataSource = ds.Tables[0].Select("年份=" + (DateTime.Now.Year-1));
        //ChartArea ca=new ChartArea();
        //Series mySeries= new Series();
        //Chart1.ChartAreas.Add(ca);
        //Chart1.Series.Add(mySeries)

        ; //设置图表Y轴对应项
        DataTable dt = new DataTable();
        if (ds.Tables[0].Select("类型='塑封桥' and 年份=" + (DropDownList1.Text)).Any())
        {
            dt = ds.Tables[0].Select("类型='塑封桥' and 年份=" + (DropDownList1.Text)).CopyToDataTable();
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Chart1.Series[0].Points.AddXY(dr["月份"], dr["出站数"]);
                Chart1.Series[3].Points.AddXY(dr["月份"], dr["合格率"]);
            }
        }
        if (ds.Tables[0].Select("类型='浇灌桥' and 年份=" + (DropDownList1.Text)).Any())
        {
            dt = ds.Tables[0].Select("类型='浇灌桥' and 年份=" + (DropDownList1.Text)).CopyToDataTable();
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Chart1.Series[1].Points.AddXY(dr["月份"], dr["出站数"]);
                Chart1.Series[4].Points.AddXY(dr["月份"], dr["合格率"]);
            }
        }
        if (ds.Tables[0].Select("类型='模块事业部产品' and 年份=" + (DropDownList1.Text)).Any())
        {

            dt = ds.Tables[0].Select("类型='模块事业部产品' and 年份=" + (DropDownList1.Text)).CopyToDataTable();
            foreach (DataRow dr in dt.AsEnumerable())
            {
                Chart1.Series[2].Points.AddXY(dr["月份"], dr["出站数"]);
                Chart1.Series[5].Points.AddXY(dr["月份"], dr["合格率"]);
            }
        }


        Chart1.Titles[0].Text = DropDownList1.Text + "年塑封桥、浇灌桥和模块事业部产品产量和合格率趋势图";
       

        //设置图表X轴对应项


        //绑定数据
        Chart1.DataBind();
    }
}