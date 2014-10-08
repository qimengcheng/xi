using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_PerformceDetailPrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        Labelyear.Text = Request.QueryString["Year"];

        //绑定
        string Year = Request.QueryString["Year"];
        string HRDD_StaffNO = Request.QueryString["HRDD_StaffNO"];
        string HRDD_Name = Request.QueryString["HRDD_Name"];
        string BDOS_Name = Request.QueryString["BDOS_Name"];
        string HRP_Post = Request.QueryString["HRP_Post"];

        string condition = "";
        string temp = "";
        if (Year != "")
        {
            temp += " and f.HRP_Year = '" + Year + "'";
        }
        if (HRDD_StaffNO != "")
        {
            temp += " and a.HRDD_StaffNO like '%" + HRDD_StaffNO + "%'";
        }
        if (HRDD_Name != "")
        {
            temp += " and a.HRDD_Name like '%" + HRDD_Name + "%'";
        }
        if (BDOS_Name != "")
        {
            temp += " and BDOS_Name like '%" + BDOS_Name + "%'";
        }
        if (HRP_Post != "")
        {
            temp += " and HRP_Post like '%" + HRP_Post + "%'";
        }
        condition = temp;
        Grid_Detail.DataSource = sd.S_PerformceDetail(condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/PerformceDetail.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "年度中层管理干部绩效考核统计表打印");
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
            tcHeader[1].Text = "工号";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[2].RowSpan = 2;
            tcHeader[2].Text = "姓名";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[3].RowSpan = 2;
            tcHeader[3].Text = "部门";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].RowSpan = 2;
            tcHeader[4].Text = "岗位";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].ColumnSpan = 12;
            tcHeader[5].Text = "分数";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].RowSpan = 2;
            tcHeader[6].Text = "全年平均分</th></tr><tr>";

            //第二行表头
            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].Text = "一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].Text = "二月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].Text = "三月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[10].Text = "四月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[11].Text = "五月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[12].Text = "六月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[13].Text = "七月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[14].Text = "八月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[15].Text = "九月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[16].Text = "十月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[17].Text = "十一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[18].Text = "十二月</th></tr><tr>";

        }
    }
}