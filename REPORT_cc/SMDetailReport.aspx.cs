using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class REPORT_cc_SMDetailReport : System.Web.UI.Page
{
    SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!((Session["UserRole"].ToString().Contains("客户明细账"))))
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
        Grid_Detail.DataSource = sd.S_SMDetailReport_shd(condition);
        Grid_Detail.DataBind();
    }
    private void BindGridView1(string condition1)
    {
        GridView1.DataSource = sd.S_SMDetailReport_hkb(condition1);
        GridView1.DataBind();
    }
    //检索按钮
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填写客户名称！')", true);
            return;
        }
        this.Label2.Visible = true;
        this.Label3.Visible = true;
        string condition = GetCondition();
        BindGrid_Detail(condition);
        string condition1 = GetCondition1();
        BindGridView1(condition1);
        //应收帐款和账期
        DataSet ds = sd.S_SMDetailReport_yszk(condition);
        DataTable dt = ds.Tables[0];
        this.Labelpay.Text = dt.Rows[0][0].ToString();
        this.Labeltime.Text = dt.Rows[0][1].ToString();
        UpdatePanel_Grid.Update();
    }
    protected string GetCondition()
    {
        string condition;
        string temp = "";
        if (this.TextBox1.Text.ToString() != "")
        {
            temp += " and CRMCIF_Name like '%" + this.TextBox1.Text.Trim() + "%'";
        }
        //发货时间
        if (this.TextBox2.Text.ToString() != "" && this.TextBox3.Text.ToString() != "")
        {
            temp += " and SMOD_Time >= '" + TextBox2.Text.Trim() + "' and SMOD_Time <= '" + TextBox3.Text.Trim() + "'";
        }
        if (this.TextBox2.Text.ToString() != "" && this.TextBox3.Text.ToString() == "")
        {
            temp += " and SMOD_Time >= '" + TextBox2.Text.Trim() + "'";
        }
        if (this.TextBox2.Text.ToString() == "" && this.TextBox3.Text.ToString() != "")
        {
            temp += " and SMOD_Time <= '" + TextBox3.Text.Trim() + "'";
        }
        if (this.TextBox2.Text.ToString() == "" && this.TextBox3.Text.ToString() == "")
        {
            temp += "";
        }
        condition = temp;
        return condition;
    }
    protected string GetCondition1()
    {
        string condition1;
        string temp1 = "";
        if (this.TextBox1.Text.ToString() != "")
        {
            temp1 += " and CRMCIF_Name like '%" + this.TextBox1.Text.Trim() + "%'";
        }
        //回款时间
        if (this.TextBox4.Text.ToString() != "" && this.TextBox5.Text.ToString() != "")
        {
            temp1 += " and SMCP_PaymentTime >= '" + TextBox4.Text.Trim() + "' and SMCP_PaymentTime <= '" + TextBox5.Text.Trim() + "'";
        }
        if (this.TextBox4.Text.ToString() != "" && this.TextBox5.Text.ToString() == "")
        {
            temp1 += " and SMCP_PaymentTime >= '" + TextBox4.Text.Trim() + "'";
        }
        if (this.TextBox4.Text.ToString() == "" && this.TextBox5.Text.ToString() != "")
        {
            temp1 += " and SMCP_PaymentTime <= '" + TextBox5.Text.Trim() + "'";
        }
        if (this.TextBox4.Text.ToString() == "" && this.TextBox5.Text.ToString() == "")
        {
            temp1 += "";
        }
        condition1 = temp1;
        return condition1;
    }
    //重置按钮
    protected void BtnReset_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        UpdatePanel_Grid.Update();
    }
    //打印报表按钮
    protected void BtnPrint_Click(object sender, EventArgs e)
    {
        if (this.TextBox1.Text.Trim() == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "alert", "alert('请填写客户名称！')", true);
            return;
        }
        Response.Redirect("../REPORT_cc/SMDetailReportPrint.aspx?" + "&CRMCIF_Name=" + TextBox1.Text+ "&TextBox2=" + TextBox2.Text + "&TextBox3=" + TextBox3.Text + "&TextBox4=" + TextBox4.Text + "&TextBox5=" + TextBox5.Text);
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
    //GridView1翻页
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView theGrid = sender as GridView;  // refer to the GridView
        int newPageIndex = 0;

        if (-2 == e.NewPageIndex)
        {
            TextBox txtNewPageIndex = null;
            GridViewRow pagerRow = this.Grid_Detail.BottomPagerRow;


            if (null != pagerRow)
            {
                txtNewPageIndex = (TextBox)pagerRow.FindControl("textbox1");   // refer to the TextBox with the NewPageIndex value
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
        string condition1 = GetCondition1();
        BindGridView1(condition1);
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
            tcHeader[0].Text = "发货ID";
            tcHeader[0].Visible = false;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[1].RowSpan = 2;
            tcHeader[1].Text = "发货时间";
            tcHeader[1].Width = 20;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].RowSpan = 2;
            tcHeader[2].Text = "客户名称";
            tcHeader[2].Width = 20;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].RowSpan = 2;
            tcHeader[3].Text = "产品型号";
            tcHeader[3].Width = 20;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].RowSpan = 2;
            tcHeader[4].Text = "产品备注";
            tcHeader[4].Width = 20;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].ColumnSpan = 5;
            tcHeader[5].Text = "借方";
            tcHeader[5].Width = 200;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].ColumnSpan = 4;
            tcHeader[6].Width = 200;
            tcHeader[6].Text = "开票信息</th></tr><tr>";

            //第二行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].Text = "送货数量";
            tcHeader[7].Width = 50;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].Text = "退货数量";
            tcHeader[8].Width = 50;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].Text = "订单单价";
            tcHeader[9].Width = 50;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[10].Text = "发货总额";
            tcHeader[10].Width = 50;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[11].Text = "已付款金额";
            tcHeader[11].Width = 50;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[12].Text = "开票日期";
            tcHeader[12].Width = 50;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[13].Text = "开票数量";
            tcHeader[13].Width = 50;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[14].Text = "开票单价";
            tcHeader[14].Width = 50;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[15].Text = "金额";
            tcHeader[15].Width = 50;
        }
    }
    //GridView1多表头合并
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
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
            tcHeader[0].ColumnSpan = 3;
            tcHeader[0].Text = "借方回款</th></tr><tr>";

            //第二行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[1].Text = "回款时间";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].Text = "回款金额";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].Text = "备注</th></tr><tr>";
        }
    }
    //Grid_Detail嵌套
    protected void Grid_Detail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string condition3 = "";
            string temp3 = "";
            if (TextBox1.Text != "")
            {
                temp3 += " and CRMCIF_Name like '%" + TextBox1.Text + "%'";
            }
            //发货时间
            if (this.TextBox2.Text.ToString() != "" && this.TextBox3.Text.ToString() != "")
            {
                temp3 += " and SMOD_Time >= '" + TextBox2.Text.Trim() + "' and SMOD_Time <= '" + TextBox3.Text.Trim() + "'";
            }
            if (this.TextBox2.Text.ToString() != "" && this.TextBox3.Text.ToString() == "")
            {
                temp3 += " and SMOD_Time >= '" + TextBox2.Text.Trim() + "'";
            }
            if (this.TextBox2.Text.ToString() == "" && this.TextBox3.Text.ToString() != "")
            {
                temp3 += " and SMOD_Time <= '" + TextBox3.Text.Trim() + "'";
            }
            if (this.TextBox2.Text.ToString() == "" && this.TextBox3.Text.ToString() == "")
            {
                temp3 += "";
            }
            Guid q = new Guid(Grid_Detail.DataKeys[e.Row.RowIndex].Value.ToString());
            temp3 += " and SMOD_ID = '" + q + "'";
            condition3 = temp3;

            var gv = e.Row.Cells[10].FindControl("GridView3") as GridView;
            gv.DataSource = sd.S_SMDetailReport_kpb(condition3);
            gv.DataBind();
        }

    }
    #region 合并单元格 合并一行中的几列
    /// <param name="GridView1">GridView ID</param>
    /// <param name="rows">行</param>
    /// <param name="sCol">开始列</param>
    /// <param name="eCol">结束列</param>
    public static void GroupRow(GridView GridView1, int rows, int sCol, int eCol)
    {
        TableCell oldTc = GridView1.Rows[rows].Cells[sCol];
        for (int i = 1; i <= eCol - sCol; i++)
        {
            TableCell tc = GridView1.Rows[rows].Cells[i + sCol];　 //Cells[0]就是你要合并的列
            tc.Visible = false;
            if (oldTc.ColumnSpan == 0)
            {
                oldTc.ColumnSpan = 1;
            }
            oldTc.ColumnSpan++;
            oldTc.VerticalAlign = VerticalAlign.Middle;
        }
    }
    protected void Grid_Detail_DataBound(object sender, EventArgs e)
    {
        for (int j = 0; j < Grid_Detail.Rows.Count; j++)
        {
            GroupRow(Grid_Detail, j, 10, 13);
        }
    }
    #endregion



}