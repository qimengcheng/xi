using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class REPORT_cc_SMDetailReportPrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        LabelName.Text = Request.QueryString["CRMCIF_Name"];
        //发货时间
        if (Request.QueryString["TextBox2"] == null || Request.QueryString["TextBox2"] == "")
        {
            Labelstart.Text = "始";
        }
        else
        {
            Labelstart.Text = Request.QueryString["TextBox2"];
        }
        if (Request.QueryString["TextBox3"] == null || Request.QueryString["TextBox3"] == "")
        {
            Labelend.Text = "今";
        }
        else
        {
            Labelend.Text = Request.QueryString["TextBox3"];
        }
        //回款时间
        if (Request.QueryString["TextBox4"] == null || Request.QueryString["TextBox4"] == "")
        {
            Label9.Text = "始";
        }
        else
        {
            Label9.Text = Request.QueryString["TextBox4"];
        }
        if (Request.QueryString["TextBox5"] == null || Request.QueryString["TextBox5"] == "")
        {
            Label11.Text = "今";
        }
        else
        {
            Label11.Text = Request.QueryString["TextBox5"];
        }
        //绑定
        string CRMCIF_Name = Request.QueryString["CRMCIF_Name"];
        string TextBox2 = Request.QueryString["TextBox2"];
        string TextBox3 = Request.QueryString["TextBox3"];
        string TextBox4 = Request.QueryString["TextBox4"];
        string TextBox5 = Request.QueryString["TextBox5"];

        //Grid_Detail绑定
        string condition = "";
        string temp = "";
        if (CRMCIF_Name != "")
        {
            temp += " and CRMCIF_Name like '%" + CRMCIF_Name + "%'";
        }
        //发货时间
        if (TextBox2 != "" && TextBox3 != "")
        {
            temp += " and SMOD_Time >= '" + TextBox2 + "' and SMOD_Time <= '" + TextBox3 + "'";
        }
        if (TextBox2 != "" && TextBox3 == "")
        {
            temp += " and SMOD_Time >= '" + TextBox2 + "'";
        }
        if (TextBox2 == "" && TextBox3 != "")
        {
            temp += " and SMOD_Time <= '" + TextBox3 + "'";
        }
        if (TextBox2 == "" && TextBox3 == "")
        {
            temp += "";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_SMDetailReport_shd(condition);
        Grid_Detail.DataBind();

        //GridView1绑定
        string condition1 = "";
        string temp1 = "";
        if (CRMCIF_Name != "")
        {
            temp1 += " and CRMCIF_Name like '%" + CRMCIF_Name + "%'";
        }
        //交货时间
        if (TextBox4 != "" && TextBox5 != "")
        {
            temp1 += " and SMCP_PaymentTime >= '" + TextBox4 + "' and SMCP_PaymentTime <= '" + TextBox5 + "'";
        }
        if (TextBox4 != "" && TextBox5 == "")
        {
            temp1 += " and SMCP_PaymentTime >= '" + TextBox4 + "'";
        }
        if (TextBox4 == "" && TextBox5 != "")
        {
            temp1 += " and SMCP_PaymentTime <= '" + TextBox5 + "'";
        }
        if (TextBox4 == "" && TextBox5 == "")
        {
            temp1 += "";
        }
        condition1 = temp1;
        GridView1.DataSource = sd.S_SMDetailReport_hkb(condition1);
        GridView1.DataBind();

        //应收帐款和账期
        DataSet ds = sd.S_SMDetailReport_yszk(condition);
        DataTable dt = ds.Tables[0];
        this.Labelpay.Text = dt.Rows[0][0].ToString();
        this.Labeltime11.Text = dt.Rows[0][1].ToString();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/SMDetailReport.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "客户明细账打印");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(GridView1, "借方回款");
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
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
            tcHeader[1].Width = 18;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].RowSpan = 2;
            tcHeader[2].Text = "客户名称";
            tcHeader[2].Width = 30;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].RowSpan = 2;
            tcHeader[3].Text = "产品型号";
            tcHeader[3].Width = 18;

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].RowSpan = 2;
            tcHeader[4].Text = "产品备注";
            tcHeader[4].Width = 15;

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
        string CRMCIF_Name = Request.QueryString["CRMCIF_Name"];
        string TextBox2 = Request.QueryString["TextBox2"];
        string TextBox3 = Request.QueryString["TextBox3"];
        string TextBox4 = Request.QueryString["TextBox4"];
        string TextBox5 = Request.QueryString["TextBox5"];
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string condition3 = "";
            string temp3 = "";
            if (CRMCIF_Name != "")
            {
                temp3 += " and CRMCIF_Name like '%" + CRMCIF_Name + "%'";
            }
            //发货时间
            if (TextBox2 != "" && TextBox3 != "")
            {
                temp3 += " and SMOD_Time >= '" + TextBox2 + "' and SMOD_Time <= '" + TextBox3+ "'";
            }
            if (TextBox2 != "" && TextBox3 == "")
            {
                temp3 += " and SMOD_Time >= '" + TextBox2 + "'";
            }
            if (TextBox2 == "" && TextBox3 != "")
            {
                temp3 += " and SMOD_Time <= '" + TextBox3 + "'";
            }
            if (TextBox2 == "" && TextBox3 == "")
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