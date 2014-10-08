using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_PieceChage : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("计件工价变动表"))))
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

    //绑定
    private void BindGrid_Detail(string condition)
    {
        Grid_Detail.DataSource = sd.S_PieceChage(condition);
        Grid_Detail.DataBind();
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string condition = GetCondition();
        BindGrid_Detail(condition);
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (this.textgongxu.Text.ToString() != "")
        {
            temp += " and PBC_Name like '%" + this.textgongxu.Text.ToString() + "%'";
        }
        if (this.textxilie.Text.ToString() != "")
        {
            temp += " and SPS_Name like '%" + this.textxilie.Text.ToString() + "%'";
        }
        if (this.textxiangmu.Text.ToString() != "")
        {
            temp += " and SPI_Name like '%" + this.textxiangmu.Text.Trim() + "%'";
        }
        //时间
        if (this.laststar.Text.ToString() != "" && this.lastend.Text.ToString() != "")
        {
            temp += " and SPICR_ExecDate >= '" + laststar.Text.Trim() + "' and SPICR_ExecDate <= '" + lastend.Text.Trim() + "'";
        }
        if (this.laststar.Text.ToString() != "" && this.lastend.Text.ToString() == "")
        {
            temp += " and SPICR_ExecDate >= '" + laststar.Text.Trim() + "'";
        }
        if (this.laststar.Text.ToString() == "" && this.lastend.Text.ToString() != "")
        {
            temp += " and SPICR_ExecDate <= '" + lastend.Text.Trim() + "'";
        }
        if (this.laststar.Text.ToString() == "" && this.lastend.Text.ToString() == "")
        {
            temp += "";
        }
        condition = temp;
        return condition;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        textgongxu.Text = "";
        textxilie.Text = "";
        textxiangmu.Text = "";
        laststar.Text = "";
        lastend.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("../REPORT_cc/PieceChagePrint.aspx?" + "&PBC_Name=" + textgongxu.Text.ToString() + "&SPS_Name=" + textxilie.Text.ToString() + "&SPI_Name=" + textxiangmu.Text.ToString() + "&startime=" + laststar.Text + "&endtime=" + lastend.Text);
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
        BindGrid_Detail(condition);
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
            tcHeader[1].Text = "工序";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].RowSpan = 2;
            tcHeader[2].Text = "计件系列";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].RowSpan = 2;
            tcHeader[3].Text = "计件项目";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].RowSpan = 2;
            tcHeader[4].Text = "单价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].ColumnSpan = 4;
            tcHeader[5].Text = "调整情况</th></tr><tr>";

            //第二行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].Text = "原单价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].Text = "现单价";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].Text = "调整金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].Text = "调整比率(%)";
        }
    }

}