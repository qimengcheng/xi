using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

public partial class Laputa_SunMasterTypeYearTrendsMainSeries : System.Web.UI.Page
{
    private readonly LaputaPrintPoolD lpp = new LaputaPrintPoolD();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int maxyear = DateTime.Now.Year;
            for(int i=2013;i<=maxyear;i++)
            {
                DropDownList1.Items.Add(new ListItem(i.ToString(),i.ToString()));
            }
           
        }

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
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
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
        panelGraph.Visible = false;
        GridView2.DataSource = lpp.Query_SunMasterYearMainSeries(DropDownList1.SelectedValue);
        GridView2.DataBind();
        Panel3.Visible = true;
    }

    private void Bindgrid2()
    {
        GridView2.DataSource = lpp.Query_SunMasterYearMainSeries(DropDownList1.SelectedValue);

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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
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

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Gra")
        {
            panelGraph.Visible = true;
            DataSet ds = lpp.Query_SunMasterYearMainSeries(DropDownList1.SelectedValue);
            DataTable dt = new DataTable();
            if (ds.Tables[0].Select("大型号='" + (e.CommandArgument) + "'").Any())
            {
                dt = ds.Tables[0].Select("大型号='" + (e.CommandArgument) + "'").CopyToDataTable();
                foreach (DataRow dr in dt.AsEnumerable())
                {
                    Chart1.Series[0].Points.AddXY(dr["月份"], dr["出站数"]);
                    Chart1.Series[1].Points.AddXY(dr["月份"], dr["合格率"]);
                }
            }
            Chart1.Series[0].Name = e.CommandArgument + "产量";
            Chart1.Series[1].Name = e.CommandArgument + "合格率";
            //if (ds.Tables[0].Select("类型='浇灌桥' and 月份=" + (DropDownList1.SelectedValue)).Any())
            //{
            //    dt = ds.Tables[0].Select("类型='浇灌桥' and 月份=" + (DropDownList1.SelectedValue)).CopyToDataTable();
            //    foreach (DataRow dr in dt.AsEnumerable())
            //    {
            //        Chart1.Series[1].Points.AddXY(dr["年份"], dr["出站数"]);
            //        Chart1.Series[4].Points.AddXY(dr["年份"], dr["合格率"]);
            //    }
            //}
            //if (ds.Tables[0].Select("类型='模块事业部产品' and 月份=" + (DropDownList1.SelectedValue)).Any())
            //{

            //    dt = ds.Tables[0].Select("类型='模块事业部产品' and 月份=" + (DropDownList1.SelectedValue)).CopyToDataTable();
            //    foreach (DataRow dr in dt.AsEnumerable())
            //    {
            //        Chart1.Series[2].Points.AddXY(dr["年份"], dr["出站数"]);
            //        Chart1.Series[5].Points.AddXY(dr["年份"], dr["合格率"]);
            //    }
            //}




            //设置图表X轴对应项


            //绑定数据
         
           
            Chart1.Titles[0].Text = e.CommandArgument + "-"+DropDownList1.SelectedValue+"年塑封桥、浇灌桥和模块事业部产品产量和合格率趋势图";
   Chart1.DataBind();
            //Chart1.DataBind();
            
        }
    }

    protected void Reset_Click(object sender, EventArgs e)
    {
        mid.Text = "mid";
    
  
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
    
        Response.Redirect("~/report_cc/SunMasterTypeYearTrendsMainSeriesPrint.aspx?year="+DropDownList1.SelectedValue);
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
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox");
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
            var row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

            var id = new Guid(e.CommandArgument.ToString());
            mid.Text = e.CommandArgument.ToString();
            Panel1.Visible = false;
        }
    }
    protected void Chart1_Load(object sender, EventArgs e)
    {
      
        ////设置图表的数据源
        
        //    DataSet ds= lpp.Query_SunMasterTypeMonthTrends();
        //    //Chart1.DataSource= ds.Tables[0].Select("年份="+DateTime.Now.Year);
        ////ChartArea ca=new ChartArea();
        ////Series mySeries= new Series();
        ////Chart1.ChartAreas.Add(ca);
        ////Chart1.Series.Add(mySeries)

        //    ; //设置图表Y轴对应项
       
        ////Chart1.Series[0].YValueMembers ="出站数";
        ////Chart1.Series[2].YValueMembers = "合格率";

        //////设置图表X轴对应项
        ////Chart1.Series[0].XValueMember = "月份";
        ////Chart1.Series[2].XValueMember = "月份";
        ////Chart1.DataSource = ds.Tables[0].Select("年份=" + (DateTime.Now.Year-1));
        ////ChartArea ca=new ChartArea();
        ////Series mySeries= new Series();
        ////Chart1.ChartAreas.Add(ca);
        ////Chart1.Series.Add(mySeries)

        //; //设置图表Y轴对应项
        //DataTable dt=new DataTable();
        //if (ds.Tables[0].Select("类型='塑封桥' and 年份=" + (DropDownList1.SelectedValue)).Any())
        //{
        //    dt = ds.Tables[0].Select("类型='塑封桥' and 年份=" + (DropDownList1.SelectedValue)).CopyToDataTable();
        //    foreach (DataRow dr in dt.AsEnumerable())
        //    {
        //        Chart1.Series[0].Points.AddXY(dr["月份"], dr["出站数"]);
        //        Chart1.Series[3].Points.AddXY(dr["月份"], dr["合格率"]);
        //    }
        //}
        //if (ds.Tables[0].Select("类型='浇灌桥' and 年份=" + (DropDownList1.SelectedValue)).Any())
        //{
        //    dt = ds.Tables[0].Select("类型='浇灌桥' and 年份=" + (DropDownList1.SelectedValue)).CopyToDataTable();
        //    foreach (DataRow dr in dt.AsEnumerable())
        //    {
        //        Chart1.Series[1].Points.AddXY(dr["月份"], dr["出站数"]);
        //        Chart1.Series[4].Points.AddXY(dr["月份"], dr["合格率"]);
        //    }
        //}
        //if (ds.Tables[0].Select("类型='模块事业部产品' and 年份=" + (DropDownList1.SelectedValue)).Any())
        //{

        //    dt = ds.Tables[0].Select("类型='模块事业部产品' and 年份=" + (DropDownList1.SelectedValue)).CopyToDataTable();
        //    foreach (DataRow dr in dt.AsEnumerable())
        //    {
        //        Chart1.Series[2].Points.AddXY(dr["月份"], dr["出站数"]);
        //        Chart1.Series[5].Points.AddXY(dr["月份"], dr["合格率"]);
        //    }
        //}

        //Chart1.Titles[0].Text = DropDownList1.SelectedValue + "年塑封桥、浇灌桥和模块事业部产品产量和合格率趋势图";
       

        ////设置图表X轴对应项


        ////绑定数据
        //Chart1.DataBind();
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].Text = e.Row.Cells[7].Text + "%";

        }
    }
}