using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_QuitCountPercentPrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        Labelyear.Text = Request.QueryString["Year"];

        //绑定
        int Year =Convert.ToInt16(Request.QueryString["Year"]);

        int year = Year;
        Grid_Detail.DataSource = sd.S_QuitCountPercent(year);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/QuitCountPercent.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "人员流失率年报表");
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
}