using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_QuitCountPercent : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.textyear.Text = DateTime.Now.ToString("yyyy");
            try
            {
                if (!((Session["UserRole"].ToString().Contains("人员流失率年报表"))))
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

    #region 绑定
    private void BindGrid_Detail(int year)
    {
        Grid_Detail.DataSource = sd.S_QuitCountPercent(year);
        Grid_Detail.DataBind();
    }
    #endregion 绑定

    #region 统计
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        if (this.textyear.Text.ToString() == "" || this.textyear.Text.ToString().Length != 4)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        int year = Convert.ToInt16(textyear.Text.Trim().ToString());
        BindGrid_Detail(year);
        UpdatePanel_Grid.Update();
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Panel_Grid.Visible = true;
        textyear.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        if (this.textyear.Text.ToString() == "" || this.textyear.Text.ToString().Length != 4)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/QuitCountPercentPrint.aspx?" + "&Year=" + textyear.Text.ToString().Trim());
    }
    //Grid_Detail翻页
    protected void Grid_Detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_Detail.BottomPagerRow;


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
        int year =Convert.ToInt16(textyear.Text.Trim().ToString());
        BindGrid_Detail(year);
        newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
        newPageIndex = newPageIndex >= this.Grid_Detail.PageCount ? this.Grid_Detail.PageCount - 1 : newPageIndex;
        this.Grid_Detail.PageIndex = newPageIndex;
        this.Grid_Detail.DataBind();
    }
    //Grid_Detail多表头合并
    protected void Grid_Detail_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //判断创建的行是否为表头行
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //获取表头所在行的所有单元格
            TableCellCollection tcHeader = e.Row.Cells;
            //清除自动生成的表头
            tcHeader.Clear();

            //第一行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[0].RowSpan = 2;
            tcHeader[0].Text = "序号";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[1].RowSpan = 2;
            tcHeader[1].Text = "部门";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].RowSpan = 2;
            tcHeader[2].Text = "岗位";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].ColumnSpan = 3;
            tcHeader[3].Text = "一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].ColumnSpan = 3;
            tcHeader[4].Text = "二月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].ColumnSpan = 3;
            tcHeader[5].Text = "三月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].ColumnSpan = 3;
            tcHeader[6].Text = "四月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].ColumnSpan = 3;
            tcHeader[7].Text = "五月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].ColumnSpan = 3;
            tcHeader[8].Text = "六月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].ColumnSpan = 3;
            tcHeader[9].Text = "七月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[10].ColumnSpan = 3;
            tcHeader[10].Text = "八月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[11].ColumnSpan = 3;
            tcHeader[11].Text = "九月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[12].ColumnSpan = 3;
            tcHeader[12].Text = "十月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[13].ColumnSpan = 3;
            tcHeader[13].Text = "十一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[14].ColumnSpan = 3;
            tcHeader[14].Text = "十二月</th></tr><tr>";

            //第二行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[15].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[16].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[17].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[18].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[19].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[20].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[21].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[22].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[23].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[24].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[25].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[26].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[27].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[28].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[29].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[30].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[31].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[32].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[33].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[34].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[35].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[36].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[37].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[38].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[39].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[40].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[41].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[42].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[43].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[44].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[45].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[46].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[47].Text = "离职率";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[48].Text = "总人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[49].Text = "离职人数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[50].Text = "离职率";
        }
    }
    #endregion 统计
}