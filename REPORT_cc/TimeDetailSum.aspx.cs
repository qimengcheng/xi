using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_TimeDetailSum : System.Web.UI.Page
{
    TimeDetailSumD tdsd = new TimeDetailSumD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Title="年度计时工资信息统计表";
            try
            {
                if (!((Session["UserRole"].ToString().Contains("年度计时工资信息统计表"))))
                {
                    Response.Redirect("~/Default.aspx");
					
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('可能您没有权限操作和查看本页面，请退出选择其他账号登陆，或联系管理员！')", true);
                Response.Redirect("~/Default.aspx");
            }
        }
		
    }
    protected void Grid1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //获取表头所在行的所有单元格
            TableCellCollection tcHeader = e.Row.Cells;
            //清除自动生成的表头
            tcHeader.Clear();

            //第一行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[0].RowSpan = 2;
            tcHeader[0].Text = "工序";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[1].RowSpan = 2;
            tcHeader[1].Text = "项目";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].ColumnSpan = 4;
            tcHeader[2].Text = "一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].ColumnSpan = 4;
            tcHeader[3].Text = "二月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].ColumnSpan = 4;
            tcHeader[4].Text = "三月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].ColumnSpan = 4;
            tcHeader[5].Text = "四月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].ColumnSpan = 4;
            tcHeader[6].Text = "五月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].ColumnSpan = 4;
            tcHeader[7].Text = "六月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].ColumnSpan = 4;
            tcHeader[8].Text = "七月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].ColumnSpan = 4;
            tcHeader[9].Text = "八月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[10].ColumnSpan = 4;
            tcHeader[10].Text = "九月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[11].ColumnSpan = 4;
            tcHeader[11].Text = "十月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[12].ColumnSpan = 4;
            tcHeader[12].Text = "十一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[13].ColumnSpan = 4;
            tcHeader[13].Text = "十二月</th></tr><tr>";

            //第二行表头 一月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[14].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[15].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[16].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[17].Text = "金额";


            //第二行表头 二月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[18].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[19].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[20].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[21].Text = "金额";


            //第二行表头 三月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[22].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[23].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[24].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[25].Text = "金额";


            //第二行表头 四月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[26].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[27].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[28].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[29].Text = "金额";


            //第二行表头 五月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[30].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[31].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[32].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[33].Text = "金额";


            //第二行表头 六月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[34].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[35].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[36].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[37].Text = "金额";


            //第二行表头 七月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[38].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[39].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[40].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[41].Text = "金额";


            //第二行表头 八月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[42].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[43].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[44].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[45].Text = "金额";


            //第二行表头 九月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[46].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[47].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[48].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[49].Text = "金额";


            //第二行表头 十月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[50].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[51].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[52].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[53].Text = "金额";


            //第二行表头 十一月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[54].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[55].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[56].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[57].Text = "金额";


            //第二行表头 十二月
            tcHeader.Add(new TableHeaderCell());
            tcHeader[58].Text = "产量";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[59].Text = "小时";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[60].Text = "工价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[61].Text = "金额";
        }
    }
    protected void BtnSearchMaterial_Click(object sender, EventArgs e)
    {
        if (this.TxtYear.Text.ToString() == "" || this.TxtYear.Text.ToString().Length != 4)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        int year = Convert.ToInt16(TxtYear.Text.Trim().ToString());
        Grid1.DataSource = tdsd.SearchTimeDetailSum(year);
        Grid1.DataBind();
        UpdatePanel2.Update();
    }
    protected void BtnToExcel_Click(object sender, EventArgs e)
    {
        if (this.TxtYear.Text.ToString() == "" || this.TxtYear.Text.ToString().Length != 4)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        Grid1.AllowPaging = false;
        Grid1.AllowSorting = false;
        int year = Convert.ToInt16(TxtYear.Text.Trim().ToString());
        Grid1.DataSource = tdsd.SearchTimeDetailSum(year);
        Grid1.DataBind();
        ExcelHelper.GridViewToExcel(Grid1, "年度计时工资信息统计表");
        Grid1.AllowSorting = true;
        Grid1.AllowPaging = true;
    }
    protected void Grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        { // when click the "GO" Button
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = Grid1.BottomPagerRow;


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
        {  // when click the first, last, previous and next Button
            newPageIndex = e.NewPageIndex;
        }

        // check to prevent form the NewPageIndex out of the range


        int year = Convert.ToInt16(TxtYear.Text.Trim().ToString());
        Grid1.DataSource = tdsd.SearchTimeDetailSum(year);
        UpdatePanel2.Update();

        //bindgridview();
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= Grid1.PageCount ? Grid1.PageCount - 1 : newPageIndex;

        // specify the NewPageIndex
        Grid1.PageIndex = newPageIndex;

        Grid1.PageIndex = newPageIndex;
        Grid1.DataBind();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void BtnResetMaterial_Click(object sender, EventArgs e)
    {
        TxtYear.Text = "";
        Grid1.DataSource = null;
        Grid1.DataBind();
        UpdatePanel2.Update();
    }
}