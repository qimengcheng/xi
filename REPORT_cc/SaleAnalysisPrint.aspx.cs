using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_SaleAnalysisPrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        Labelyear.Text = Request.QueryString["Year"];

        //绑定
        string Year = Request.QueryString["Year"];
        string CRMCIF_Name = Request.QueryString["CRMCIF_Name"];

        string condition = "";
        string temp = "";
        if (CRMCIF_Name != "")
        {
            temp += " and a.CRMCIF_Name like '%" + CRMCIF_Name + "%'";
        }
        condition = temp;
        string year = Year;
        Grid_Detail.DataSource = sd.S_CusSalesHistory(condition, year);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/SaleAnalysis.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "销售分析表");
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
}