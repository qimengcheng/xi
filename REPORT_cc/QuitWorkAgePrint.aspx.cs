using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REPORT_cc_QuitWorkAgePrint : System.Web.UI.Page
{
    private readonly SalesD sd = new SalesD();
    protected void Page_Load(object sender, EventArgs e)
    {
        Labelpeople.Text = Session["UserName"].ToString();
        Labeltime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        Labelyear.Text = Request.QueryString["Year"];

        //绑定
        string Year = Request.QueryString["Year"];
        string dep = Request.QueryString["dep"];
        string post = Request.QueryString["post"];

        string year = Year;
        string condition = "";
        if (dep != "请选择" && dep != "")
        {
            condition += "and a.部门 like '%" + dep + "%'";
            if (post!= "")
            {
                condition += "and a.岗位 like '%" + post + "%'";
            }
        }
        Grid_Detail.DataSource = sd.S_QuitWorkAge(year, condition);
        Grid_Detail.DataBind();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/REPORT_cc/QuitWorkAge.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExcelHelper.GridViewToExcel(Grid_Detail, "人员流失工龄年报表");
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
            tcHeader[3].ColumnSpan = 7;
            tcHeader[3].Text = "一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[4].ColumnSpan = 7;
            tcHeader[4].Text = "二月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[5].ColumnSpan = 7;
            tcHeader[5].Text = "三月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[6].ColumnSpan = 7;
            tcHeader[6].Text = "四月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[7].ColumnSpan = 7;
            tcHeader[7].Text = "五月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[8].ColumnSpan = 7;
            tcHeader[8].Text = "六月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[9].ColumnSpan = 7;
            tcHeader[9].Text = "七月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[10].ColumnSpan = 7;
            tcHeader[10].Text = "八月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[11].ColumnSpan = 7;
            tcHeader[11].Text = "九月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[12].ColumnSpan = 7;
            tcHeader[12].Text = "十月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[13].ColumnSpan = 7;
            tcHeader[13].Text = "十一月";

            tcHeader.Add(new TableHeaderCell());
            tcHeader[14].ColumnSpan = 7;
            tcHeader[14].Text = "十二月</th></tr><tr>";

            //第二行表头
            int i;
            for (i = 15; i <= 98; )
            {
                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "试用期内";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "三至六月";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "六月至一年";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "一至二年";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "二至五年";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "五至十年";
                i += 1;

                tcHeader.Add(new TableHeaderCell());
                tcHeader[i].Text = "十年以上";
                i += 1;
            }
        }
    }
}