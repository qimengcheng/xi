using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class REPORT_cc_SaleAnalysis : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.textyear.Text = DateTime.Now.ToString("yyyy");
            try
            {
                if (!((Session["UserRole"].ToString().Contains("销售分析表"))))
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
    private void BindGrid_Detail(string condition, string year)
    {
        Grid_Detail.DataSource = sd.S_CusSalesHistory(condition, year);
        Grid_Detail.DataBind();
    }
    #endregion 绑定

    #region 统计
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (this.textyear.Text.ToString() == "" || this.textyear.Text.ToString().Length != 4)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        string condition = GetCondition();
        string year = textyear.Text.Trim().ToString();
        BindGrid_Detail(condition, year);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (this.textname.Text.ToString() != "")
        {
            temp += " and a.CRMCIF_Name like '%" + this.textname.Text.ToString() + "%'";
        }
        condition = temp;
        return condition;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        Panel_Grid.Visible = true;
        UpdatePanel_Grid.Update();
        textname.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        if (this.textyear.Text.ToString() == "" || this.textyear.Text.ToString().Length != 4)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填入正确的年份！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/SaleAnalysisPrint.aspx?" + "&Year=" + textyear.Text.ToString().Trim() + "&CRMCIF_Name=" + textname.Text.ToString());
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
        string condition = GetCondition();
        string year = textyear.Text.Trim().ToString();
        BindGrid_Detail(condition, year);
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
            tcHeader[1].Text = "客户名称";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].RowSpan = 2;
            tcHeader[2].Text = "超期应收金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].RowSpan = 2;
            tcHeader[3].Text = "超期货款";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].ColumnSpan = 2;
            tcHeader[4].Text = "一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].ColumnSpan = 2;
            tcHeader[5].Text = "二月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].ColumnSpan = 2;
            tcHeader[6].Text = "三月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].ColumnSpan = 2;
            tcHeader[7].Text = "四月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].ColumnSpan = 2;
            tcHeader[8].Text = "五月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].ColumnSpan = 2;
            tcHeader[9].Text = "六月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[10].ColumnSpan = 2;
            tcHeader[10].Text = "七月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[11].ColumnSpan = 2;
            tcHeader[11].Text = "八月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[12].ColumnSpan = 2;
            tcHeader[12].Text = "九月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[13].ColumnSpan = 2;
            tcHeader[13].Text = "十月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[14].ColumnSpan = 2;
            tcHeader[14].Text = "十一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[15].ColumnSpan = 2;
            tcHeader[15].Text = "十二月</th></tr><tr>";

            //第二行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[16].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[17].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[18].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[19].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[20].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[21].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[22].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[23].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[24].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[25].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[26].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[27].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[28].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[29].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[30].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[31].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[32].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[33].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[34].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[35].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[36].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[37].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[38].Text = "发货金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[39].Text = "回款金额</th></tr><tr>";

        }
    }
    #endregion 统计

}